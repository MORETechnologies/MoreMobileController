using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MoreMobileController.Core
{
    public class DebugBotClient : IBotClient
    {
        public event EventHandler Disconnected;

        public async Task<bool> ConnectAsync(string host, int portNumber)
        {
            Debug.WriteLine("Connecting to " + host + ":" + portNumber);
            await Task.Delay(100);
            return true;
        }

        public void Disconnect()
        {
            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        public async Task SendMessage(BotMessage message)
        {
            byte[] data = message.Serialize();
            Debug.WriteLine(Encoding.UTF8.GetString(data));
            await Task.Delay(100);
        }
    }
}
