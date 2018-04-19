using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace ApplicationB
{
    [Activity(Label = "ApplicationB", MainLauncher = true,Name = "ApplicationB.ApplicationB.MainActivity")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            if (Intent != null)
            {
                string operation = Intent.GetStringExtra("Operation");
                string activity = Intent.GetStringExtra("Activity");
                if ("Task_1".Equals(operation))
                {
                    Toast.MakeText(this, operation+"------"+ activity, ToastLength.Short).Show();
                }
            }
            Button bt = FindViewById<Button>(Resource.Id.bt);
            bt.Click += Bt_Click;

        }

        private void Bt_Click(object sender, System.EventArgs e)
        {
            var returnIntent = new Intent();
            returnIntent.PutExtra("AppBData", "AppBData");
            SetResult(Result.Ok, returnIntent);
            Finish();
        }
    }
}

