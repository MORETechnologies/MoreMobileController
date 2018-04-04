using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MoreMobileController.Android
{
    [Activity(Label = "ControlActivity")]
    public class ControlActivity : Activity
    {
        ImageButton forwardButton;
        ImageButton leftButton;
        ImageButton rightButton;
        ImageButton backwardButton;
        Button modeButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Control);

            forwardButton = FindViewById<ImageButton>(Resource.Id.forwardButton);
            leftButton = FindViewById<ImageButton>(Resource.Id.leftButton);
            rightButton = FindViewById<ImageButton>(Resource.Id.rightButton);
            backwardButton = FindViewById<ImageButton>(Resource.Id.backwardButton);
            modeButton = FindViewById<Button>(Resource.Id.modeButton);
        }
    }
}
