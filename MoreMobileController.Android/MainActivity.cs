using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace MoreMobileController.Android
{
    [Activity(Label = "MORE Controller", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.SensorPortrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Connect);

            EditText hostText = FindViewById<EditText>(Resource.Id.hostEditText);
            EditText portText = FindViewById<EditText>(Resource.Id.portEditText);
            TextView statusText = FindViewById<TextView>(Resource.Id.statusTextView);
            Button connectButton = FindViewById<Button>(Resource.Id.connectButton);

            MainApplication main = (MainApplication)ApplicationContext;

            hostText.Text = main.ConnectViewModel.HostName;
            portText.Text = main.ConnectViewModel.PortNumber.ToString();

            main.ConnectViewModel.StatusChanged += (sender, e) => {
                statusText.Text = e;
            };

            connectButton.Click += async (sender, e) => {
                connectButton.Enabled = false;

                main.ConnectViewModel.HostName = hostText.Text;
                int.TryParse(portText.Text, out int port);
                main.ConnectViewModel.PortNumber = port;

                if (await main.ConnectViewModel.ConnectAsync()) {
                    StartActivity(typeof(ControlActivity));
                }

                connectButton.Enabled = true;
            };
        }
    }
}

