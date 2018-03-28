using System.Diagnostics;
using MoreMobileController.Core;
using UIKit;

namespace MoreMobileController.iOS
{
    public partial class ControlViewController : UIViewController
    {
        ControlViewModel viewModel;

        public ControlViewController(ControlViewModel viewModel) : base("ControlViewController", null)
        {
            this.viewModel = viewModel;

            viewModel.ModeTextChanged += (sender, e) => {
                modeButton.SetTitle(e, UIControlState.Normal);
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            forwardButton.TouchDown += (sender, e) => {
                viewModel.OnButtonPressed(ControlButton.Forward);
            };

            leftButton.TouchDown += (sender, e) => {
                viewModel.OnButtonPressed(ControlButton.Left);
            };

            rightButton.TouchDown += (sender, e) => {
                viewModel.OnButtonPressed(ControlButton.Right);
            };

            backwardButton.TouchDown += (sender, e) => {
                viewModel.OnButtonPressed(ControlButton.Backward);
            };

            modeButton.TouchDown += (sender, e) => {
                viewModel.OnButtonPressed(ControlButton.Mode);
            };

            forwardButton.TouchUpInside += (sender, e) => {
                viewModel.OnButtonReleased();
            };

            leftButton.TouchUpInside += (sender, e) => {
                viewModel.OnButtonReleased();
            };

            rightButton.TouchUpInside += (sender, e) => {
                viewModel.OnButtonReleased();
            };

            backwardButton.TouchUpInside += (sender, e) => {
                viewModel.OnButtonReleased();
            };

            backButton.TouchUpInside += (sender, e) => {
                viewModel.OnBackPressed();
                NavigationController.PopViewController(true);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            Debug.WriteLine("Memory warning received.");
        }
    }
}

