using System;
using Android.App;
using Android.Runtime;
using MoreMobileController.Core;

namespace MoreMobileController.Android
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
            ConnectViewModel = new ConnectViewModel();
        }

        public ConnectViewModel ConnectViewModel { get; set; }
    }
}
