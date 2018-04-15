using System;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;

namespace MoreMobileController.iOS
{
    public partial class ComponentListViewController : UIViewController
    {
        List<MotorComponentView> componentViews;

        public ComponentListViewController() : base("ComponentListViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            componentViews = new List<MotorComponentView>();

            addComponentButton.TouchUpInside += (sender, e) => {
                MotorComponentView componentView = MotorComponentView.Create();
                componentView.AutoresizingMask = UIViewAutoresizing.None;
                componentView.Layer.ShadowOffset = new CGSize(3f, 3f);
                componentView.Layer.ShadowOpacity = 0.1f;
                componentView.Layer.ShadowRadius = 1f;
                componentViews.Add(componentView);
                contentView.Add(componentView);
                PositionComponents();
            };

            PositionComponents();
        }

        private void PositionComponents()
        {
            nfloat y = 8;

            foreach (var component in componentViews) {
                CGRect frame = component.Frame;

                frame.Width = contentView.Frame.Width - 8;
                frame.Height = frame.Width / component.AspectRatio;
                frame.Y = y;
                frame.X = 4;

                component.Frame = frame;

                y += frame.Height + 8;
            }

            y += addComponentButton.Frame.Height;

            if (y < componentScrollView.Frame.Height) {
                y = componentScrollView.Frame.Height;
            }

            contentHeightConstraint.Constant = y;
        }
    }
}

