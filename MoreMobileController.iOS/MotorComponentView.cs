using System;
using Foundation;
using MoreMobileController.Core;
using ObjCRuntime;
using UIKit;

namespace MoreMobileController.iOS
{
    public partial class MotorComponentView : UIView
    {
        MotorComponentViewModel viewModel;

        public static MotorComponentView Create(MotorComponentViewModel viewModel)
        {
            var arr = NSBundle.MainBundle.LoadNib("MotorComponentView", null, null);
            var v = Runtime.GetNSObject<MotorComponentView>(arr.ValueAt(0));
            v.AspectRatio = v.Frame.Width / v.Frame.Height;
            v.viewModel = viewModel;

            return v;
        }

        public MotorComponentView(IntPtr handle) : base(handle)
        {
        }

        public event EventHandler DeletePressed;

        public event EventHandler EditingBegan;

        public nfloat AspectRatio { get; private set; }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            speedPinTextField.Text = "";
            directionPin1TextField.Text = "";
            directionPin2TextField.Text = "";

            speedPinTextField.EditingDidBegin += (sender, e) => {
                EditingBegan?.Invoke(sender, e);
            };

            directionPin1TextField.EditingDidBegin += (sender, e) => {
                EditingBegan?.Invoke(sender, e);
            };

            directionPin2TextField.EditingDidBegin += (sender, e) => {
                EditingBegan?.Invoke(sender, e);
            };

            deleteButton.TouchUpInside += (sender, e) => {
                Superview.EndEditing(true);
                viewModel.RemoveMotor();
                DeletePressed?.Invoke(sender, e);
            };

            clockwiseButton.TouchUpInside += (sender, e) => {
                Superview.EndEditing(true);
                viewModel.RotateClockwise();
            };

            counterclockwiseButton.TouchUpInside += (sender, e) => {
                Superview.EndEditing(true);
                viewModel.RotateCounterclockwise();
            };

            updateButton.TouchUpInside += (sender, e) => {
                Superview.EndEditing(true);
                if (!string.IsNullOrEmpty(speedPinTextField.Text) && !string.IsNullOrEmpty(directionPin1TextField.Text) && !string.IsNullOrEmpty(directionPin2TextField.Text)) {
                    viewModel.RemoveMotor();

                    int.TryParse(speedPinTextField.Text, out int speedPin);
                    int.TryParse(directionPin1TextField.Text, out int directionPin1);
                    int.TryParse(directionPin2TextField.Text, out int directionPin2);

                    viewModel.SpeedPin = speedPin;
                    viewModel.DirectionPin1 = directionPin1;
                    viewModel.DirectionPin2 = directionPin2;

                    viewModel.AddMotor();
                }
            };
        }
    }
}