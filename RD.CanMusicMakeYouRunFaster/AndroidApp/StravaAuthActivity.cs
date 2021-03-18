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
    using System.Linq;
    using System.Text;
    using Xamarin.Essentials;

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
    Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
    DataScheme = "myapp")]
    public class StravaAuthActivity : Xamarin.Essentials.WebAuthenticatorCallbackActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            Button spotifyAuthButton = FindViewById<Button>(Resource.Id.spotifyButton);
            var infoTextVar = FindViewById<TextView>(Resource.Id.runningInfoText);
            var authToken = "";
            spotifyAuthButton.Click += async (sender, o) =>
            {
                var authResult = await WebAuthenticator.AuthenticateAsync(
                    new Uri("https://www.strava.com/oauth/token?client_id=61391&client_secret=8b0eb19e37bbbeffc8b8ba75efdb1b7f9c2cfc95&grant_type=authorization_code"),
                    new Uri("myapp://"));
                authToken = authResult?.AccessToken;
                infoTextVar.Text = authToken;
            };
        }
    }
}