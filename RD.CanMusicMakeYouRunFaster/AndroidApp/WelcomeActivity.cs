namespace AndroidApp
{
    using Android.App;
    using Android.OS;
    using Android.Support.V7.App;
    using Android.Runtime;
    using Android.Widget;
    using Android.Content;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class WelcomeActivity : AppCompatActivity
    {
        /// <summary>
        ///  Welcome acivity OnCreate
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.welcome);
            Button continueButton = FindViewById<Button>(Resource.Id.GetStartedButton);
            continueButton.Click += (sender, e) =>
            {
                var stravaActivity = new Intent(this,typeof(StravaAuthActivity));
                StartActivity(stravaActivity);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}