using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using MoreMobileController.Core;

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
        ControlViewModel viewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Control);

            viewModel = ((MainApplication)Application).ConnectViewModel.ControlViewModel;

            forwardButton = FindViewById<ImageButton>(Resource.Id.forwardButton);
            leftButton = FindViewById<ImageButton>(Resource.Id.leftButton);
            rightButton = FindViewById<ImageButton>(Resource.Id.rightButton);
            backwardButton = FindViewById<ImageButton>(Resource.Id.backwardButton);
            modeButton = FindViewById<Button>(Resource.Id.modeButton);

            DisplayMetrics displayMetrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(displayMetrics);
            int size = displayMetrics.WidthPixels / 3;

            MakeSquare(forwardButton, size);
            MakeSquare(leftButton, size);
            MakeSquare(rightButton, size);
            MakeSquare(backwardButton, size);
            MakeSquare(modeButton, size);

            forwardButton.Touch += (sender, e) => {
                OnControlPressed(ControlButton.Forward, e);
            };

            leftButton.Touch += (sender, e) => {
                OnControlPressed(ControlButton.Left, e);
            };

            rightButton.Touch += (sender, e) => {
                OnControlPressed(ControlButton.Right, e);
            };

            backwardButton.Touch += (sender, e) => {
                OnControlPressed(ControlButton.Backward, e);
            };

            modeButton.Click += (sender, e) => {
                viewModel.OnButtonPressed(ControlButton.Mode);
            };

            viewModel.ModeTextChanged += (sender, e) => {
                modeButton.Text = e;
            };
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();

            viewModel.OnBackPressed();
        }

        private void MakeSquare(View view, int size)
        {
            view.LayoutParameters.Width = size;
            view.LayoutParameters.Height = size;
        }

        private void OnControlPressed(ControlButton button, View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down) {
                viewModel.OnButtonPressed(button);
            } else if (e.Event.Action == MotionEventActions.Up) {
                viewModel.OnButtonReleased();
            }

            e.Handled = false;
        }
    }
}
