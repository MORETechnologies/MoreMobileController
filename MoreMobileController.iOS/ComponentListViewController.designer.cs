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
    [Register ("ComponentListViewController")]
    partial class ComponentListViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton addComponentButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView componentScrollView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint contentHeightConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView contentView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (addComponentButton != null) {
                addComponentButton.Dispose ();
                addComponentButton = null;
            }

            if (componentScrollView != null) {
                componentScrollView.Dispose ();
                componentScrollView = null;
            }

            if (contentHeightConstraint != null) {
                contentHeightConstraint.Dispose ();
                contentHeightConstraint = null;
            }

            if (contentView != null) {
                contentView.Dispose ();
                contentView = null;
            }
        }
    }
}