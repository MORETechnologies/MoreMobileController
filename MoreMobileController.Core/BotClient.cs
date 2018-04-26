using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoreMobileController.Core
{
    public class BotClient : IBotClient
    {
        const int Timeout = 5000;

        TcpClient client;
        NetworkStream networkStream;
        SemaphoreSlim messageSemaphore;

        public BotClient()
        {
            messageSemaphore = new SemaphoreSlim(1, 1);
        }

        public event EventHandler Disconnected;

        public async Task<bool> ConnectAsync(string host, int portNumber)
        {
            try {
                client = CreatTcpClient();

                var connectTask = client.ConnectAsync(host, portNumber);
                await Task.WhenAny(connectTask, Task.Delay(Timeout));

                if (client.Connected) {
                    networkStream = client.GetStream();
                    return true;
                }

                client.Close();
            } catch (Exception) {

            }

            return false;
        }

        public async Task SendMessage(BotMessage message)
        {
            if (client.Connected) {
                string json = message.Serialize();
                byte[] buffer = Encoding.UTF8.GetBytes(json);

                await messageSemaphore.WaitAsync();
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                await Task.Delay(buffer.Length * 2);

                messageSemaphore.Release();
            } else {
                Disconnected?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Disconnect()
        {
            client.Close();
        }

        private TcpClient CreatTcpClient()
        {
            TcpClient client = new TcpClient();
            client.NoDelay = true;

            return client;
        }
    }
}
