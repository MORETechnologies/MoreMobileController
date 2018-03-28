using System;
using System.Threading.Tasks;

namespace MoreMobileController.Core
{
    public class ConnectViewModel
    {
        const string DefaultHost = "192.168.4.1";
        const int DefaultPort = 333;

        IBotClient client;

        public ConnectViewModel()
        {
            client = new DebugBotClient();
            HostName = DefaultHost;
            PortNumber = DefaultPort;
        }

        public event EventHandler<string> StatusChanged;

        public string HostName { get; set; }

        public int PortNumber { get; set; }

        public ControlViewModel ControlViewModel { get; private set; }

        public async Task<bool> ConnectAsync()
        {
            StatusChanged?.Invoke(this, "Connecting...");

            if (await client.ConnectAsync(HostName, PortNumber)) {
                ControlViewModel = new ControlViewModel(client);
                StatusChanged?.Invoke(this, "");
                return true;
            }

            ControlViewModel = null;
            StatusChanged?.Invoke(this, "Connect failed.");

            return false;
        }
    }
}
