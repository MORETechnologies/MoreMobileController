using System;
using System.Threading.Tasks;

namespace MoreMobileController.Core
{
    public class ConnectViewModel
    {
#if DEBUG
        const string DefaultHost = "test";
#else
        const string DefaultHost = "192.168.4.1";
#endif
        const int DefaultPort = 333;

        IBotClient client;

        public ConnectViewModel()
        {
            client = new BotClient();
            HostName = DefaultHost;
            PortNumber = DefaultPort;
        }

        public event EventHandler<string> StatusChanged;

        public string HostName { get; set; }

        public int PortNumber { get; set; }

        public ControlViewModel ControlViewModel { get; private set; }

        public ComponentListViewModel ComponentListViewModel { get; private set; }

        public async Task<bool> ConnectAsync()
        {
            StatusChanged?.Invoke(this, "Connecting...");

            if (HostName == "test") {
                ControlViewModel = new ControlViewModel(new DebugBotClient());
                ComponentListViewModel = new ComponentListViewModel(new DebugBotClient());
                StatusChanged?.Invoke(this, "");
                return true;
            }

            if (await client.ConnectAsync(HostName, PortNumber)) {
                ControlViewModel = new ControlViewModel(client);
                ComponentListViewModel = new ComponentListViewModel(client);
                StatusChanged?.Invoke(this, "");
                return true;
            }

            ControlViewModel = null;
            StatusChanged?.Invoke(this, "Connect failed.");

            return false;
        }
    }
}
