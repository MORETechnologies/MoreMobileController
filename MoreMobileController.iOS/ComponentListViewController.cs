using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using MoreMobileController.Core;
using UIKit;

namespace MoreMobileController.iOS
{
    public partial class ComponentListViewController : UIViewController
    {
        ComponentListViewModel viewModel;
        List<MotorComponentView> componentViews;
        NSObject keyboardShownObserver;
        NSObject keyboardHiddenObserver;
        MotorComponentView activeComponent;

        public ComponentListViewController(ComponentListViewModel viewModel) : base("ComponentListViewController", null)
        {
            this.viewModel = viewModel;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            componentViews = new List<MotorComponentView>();

            addComponentButton.TouchUpInside += (sender, e) => {
                var componentViewModel = viewModel.AddComponent();

                MotorComponentView componentView = MotorComponentView.Create(componentViewModel);
                componentView.AutoresizingMask = UIViewAutoresizing.None;
                componentView.Layer.ShadowOffset = new CGSize(3f, 3f);
                componentView.Layer.ShadowOpacity = 0.1f;
                componentView.Layer.ShadowRadius = 1f;
                componentViews.Add(componentView);
                contentView.Add(componentView);
                PositionComponents();

                componentView.DeletePressed += (sender2, e2) => {
                    componentView.RemoveFromSuperview();
                    componentViews.Remove(componentView);
                    PositionComponents();
                };

                componentView.EditingBegan += (sender2, e2) => {
                    activeComponent = componentView;
                };
            };

            PositionComponents();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            keyboardShownObserver = UIKeyboard.Notifications.ObserveDidShow(OnKeyboardShown);
            keyboardHiddenObserver = UIKeyboard.Notifications.ObserveWillHide(OnKeyboardHidden);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            keyboardShownObserver.Dispose();
            keyboardHiddenObserver.Dispose();
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

        private void OnKeyboardShown(object sender, UIKeyboardEventArgs e)
        {
            CGSize keyboardSize = e.FrameEnd.Size;
            UIEdgeInsets inset = new UIEdgeInsets(0, 0, keyboardSize.Height, 0);
            componentScrollView.ContentInset = inset;
            componentScrollView.ScrollIndicatorInsets = inset;

            ScrollToActiveComponent();
        }

        private void OnKeyboardHidden(object sender, UIKeyboardEventArgs e)
        {
            componentScrollView.ContentInset = UIEdgeInsets.Zero;
            componentScrollView.ScrollIndicatorInsets = UIEdgeInsets.Zero;
        }

        private async Task ScrollToActiveComponent()
        {
            // Bug with keyboard shown interferes with this so need delay
            await Task.Delay(10);
            if (activeComponent != null) {
                CGRect frame = activeComponent.Frame;
                componentScrollView.ScrollRectToVisible(frame, true);
            }
        }
    }
}

