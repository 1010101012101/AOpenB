using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;

namespace ApplicationA
{
    [Activity(Label = "ApplicationA", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Intent intent = new Intent();
            intent.SetClassName("ApplicationB.ApplicationB", "ApplicationB.ApplicationB.MainActivity");
            intent.PutExtra("Activity", "BundleActivity");
            intent.PutExtra("Operation", "Task_1");
            StartActivityForResult(intent,1);
           
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                Toast.MakeText(this, " Result.Ok", ToastLength.Short).Show();
                switch (requestCode)
                {
                    case 1:
                        {
                            if (data != null)
                            {
                                string dataReturned = data.GetStringExtra("AppBData");
                                Toast.MakeText(this, dataReturned, ToastLength.Short).Show();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

