using System;
using System.Threading.Tasks;

namespace MoreMobileController.Core
{
    public class ControlViewModel
    {
        IBotClient client;
        BotMode currentMode;

        internal ControlViewModel(IBotClient client)
        {
            this.client = client;
        }

        public event EventHandler<string> ModeTextChanged;

        public void OnButtonPressed(ControlButton button)
        {
            if (button == ControlButton.Mode) {
                ToggleMode();
            } else {
                SendMovement(button);
            }
        }

        public void OnButtonReleased()
        {
            BotMessage message = new BotMessage();
            message.Command = "move";
            message.Data = "stop";

            client.SendMessage(message);
        }

        public void OnBackPressed()
        {
            client.Disconnect();
        }

        private Task ToggleMode()
        {
            BotMessage message = new BotMessage();
            message.Command = "mode";
            if (currentMode == BotMode.Manual) {
                currentMode = BotMode.Yoyo;
                message.Data = "yoyo";
                ModeTextChanged?.Invoke(this, "Yoyo");
            } else {
                currentMode = BotMode.Manual;
                message.Data = "manual";
                ModeTextChanged?.Invoke(this, "Manual");
            }

            return client.SendMessage(message);
        }

        private Task SendMovement(ControlButton button)
        {
            BotMessage message = new BotMessage();
            message.Command = "move";
            message.Data = button.ToString().ToLower();

            return client.SendMessage(message);
        }
    }
}
