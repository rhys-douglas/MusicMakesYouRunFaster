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
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            stravaLoginButton = FindViewById<Button>(Resource.Id.spotifyButton);
            infoText = FindViewById<TextView>(Resource.Id.runningInfoText);
            stravaLoginButton.Click += StravaButton_Click;
        }

        private void StravaButton_Click(object sender, EventArgs e)
        {
            var auth = new OAuth2Authenticator("61391","SCOPE",new Uri(""), new Uri(""));
            auth.Completed += StravaAuth_Completed;
            var ui = auth.GetUI(this);
            StartActivity(ui);
        }

        private void StravaAuth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var authrequest = new OAuth2Request("GET", new Uri(""), null, e.Account);
            }
        }
    }
}