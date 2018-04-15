using Foundation;
using ObjCRuntime;
using System;
using UIKit;

namespace MoreMobileController.iOS
{
    public partial class MotorComponentView : UIView
    {
        public static MotorComponentView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("MotorComponentView", null, null);
            var v = Runtime.GetNSObject<MotorComponentView>(arr.ValueAt(0));
            v.AspectRatio = v.Frame.Width / v.Frame.Height;

            return v;
        }

        public MotorComponentView(IntPtr handle) : base(handle)
        {
        }

        public nfloat AspectRatio { get; private set; }
    }
}