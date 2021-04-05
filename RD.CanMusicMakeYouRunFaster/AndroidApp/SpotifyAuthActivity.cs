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

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
    Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
    DataScheme = "myapp")]
    public class SpotifyAuthActivity : Activity
    {
        Button spotifyLoginButton = null;
        TextView infoText = null;

        /// <summary>
        /// SpotifyAuthActivity OnCreate method.
        /// </summary>
        /// <param name="bundle"> Saved instance state. </param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ConnectMusicServices);
            spotifyLoginButton = FindViewById<Button>(Resource.Id.spotifyButton);
            infoText = FindViewById<TextView>(Resource.Id.musicInfoText);
            spotifyLoginButton.Click += SpotifyButton_Click;
        }

        private async void SpotifyButton_Click(object sender, EventArgs e)
        {

        }
    }
}