using MoreMobileController.Core;
using UIKit;

namespace MoreMobileController.iOS
{
    public partial class ConnectViewController : UIViewController
    {
        ConnectViewModel viewModel;

        public ConnectViewController() : base("ConnectViewController", null)
        {
            viewModel = new ConnectViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController?.SetNavigationBarHidden(true, false);

            hostField.Text = viewModel.HostName;
            portField.Text = viewModel.PortNumber.ToString();

            statusLabel.Text = "";

            viewModel.StatusChanged += (sender, text) => {
                statusLabel.Text = text;
            };

            connectButton.TouchUpInside += async (sender, e) => {
                connectButton.Enabled = false;
                if (await viewModel.ConnectAsync()) {
                    NavigationController.PushViewController(new ControlViewController(viewModel.ControlViewModel), true);
                }
                connectButton.Enabled = true;
            };
        }
    }
}

