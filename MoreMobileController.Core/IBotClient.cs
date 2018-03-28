using System;
using System.Threading.Tasks;

namespace MoreMobileController.Core
{
    public interface IBotClient
    {
        event EventHandler Disconnected;

        Task<bool> ConnectAsync(string host, int portNumber);

        Task SendMessage(BotMessage message);

        void Disconnect();
    }
}
