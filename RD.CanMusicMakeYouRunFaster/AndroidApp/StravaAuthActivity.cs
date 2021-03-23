namespace AndroidApp
{
    using Android.App;
    using Android.Content;
    using Android.Content.PM;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using System;
    using System.Collections.Generic;
    using System.Json;
    using System.Linq;
    using System.Text;
    using Xamarin.Auth;
    using Xamarin.Essentials;

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
    Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
    DataScheme = "myapp")]
    public class StravaAuthActivity : Xamarin.Essentials.WebAuthenticatorCallbackActivity
    {
        Button stravaLoginButton;
        TextView infoText;

        /// <summary>
        /// StravaAuthActivity OnCreate method.
        /// </summary>
        /// <param name="savedInstanceState"> Saved instance state. </param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            stravaLoginButton = FindViewById<Button>(Resource.Id.stravaButton);
            infoText = FindViewById<TextView>(Resource.Id.runningInfoText);
            stravaLoginButton.Click += StravaButton_Click;
        }

        private void StravaButton_Click(object sender, EventArgs e)
        {
            var auth = new OAuth2Authenticator(
                "61391",
                "8b0eb19e37bbbeffc8b8ba75efdb1b7f9c2cfc95",
                "activity:read_all",
                new Uri("https://www.strava.com/oauth/authorize"),
                new Uri("http://localhost:5001/stravatoken"),
                new Uri("https://www.strava.com/oauth/token"));
            auth.Completed += StravaAuth_Completed;
            var ui = auth.GetUI(this);
            StartActivity(ui);
        }

        private async void StravaAuth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var request = new OAuth2Request(
                    "GET",
                    new Uri("https://www.strava.com/api/v3/athlete/activities" 
                    + "&access_token=" + e.Account.Properties["access_token"]), 
                    null, 
                    e.Account);

                var stravaResponse = await request.GetResponseAsync();
                var json = stravaResponse.GetResponseText();
                infoText.Text += json;
            }
        }
    }
}