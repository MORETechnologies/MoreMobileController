// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MoreMobileController.iOS
{
    [Register ("MotorComponentView")]
    partial class MotorComponentView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton clockwiseButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton counterclockwiseButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton deleteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField directionPin1TextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField directionPin2TextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel speedLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField speedPinTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider speedSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton updateButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (clockwiseButton != null) {
                clockwiseButton.Dispose ();
                clockwiseButton = null;
            }

            if (counterclockwiseButton != null) {
                counterclockwiseButton.Dispose ();
                counterclockwiseButton = null;
            }

            if (deleteButton != null) {
                deleteButton.Dispose ();
                deleteButton = null;
            }

            if (directionPin1TextField != null) {
                directionPin1TextField.Dispose ();
                directionPin1TextField = null;
            }

            if (directionPin2TextField != null) {
                directionPin2TextField.Dispose ();
                directionPin2TextField = null;
            }

            if (speedLabel != null) {
                speedLabel.Dispose ();
                speedLabel = null;
            }

            if (speedPinTextField != null) {
                speedPinTextField.Dispose ();
                speedPinTextField = null;
            }

            if (speedSlider != null) {
                speedSlider.Dispose ();
                speedSlider = null;
            }

            if (updateButton != null) {
                updateButton.Dispose ();
                updateButton = null;
            }
        }
    }
}