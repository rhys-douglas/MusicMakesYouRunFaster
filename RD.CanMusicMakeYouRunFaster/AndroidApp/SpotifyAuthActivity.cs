namespace AndroidApp
{
    using Android.App;
    using Android.Content;
    using Android.Content.PM;
    using Android.OS;
    using Android.Widget;
    using SpotifyAPI.Web.Auth;
    using System;
    using Xamarin.Auth;

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
    Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
    DataScheme = "myapp")]
    public class SpotifyAuthActivity : Activity
    {
        private static readonly EmbedIOAuthServer StravaAuthServer = new EmbedIOAuthServer(new Uri("http://localhost:5000/spotifytoken"), 5000);

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
            await StravaAuthServer.Start();
            var auth = new OAuth2Authenticator(
                "1580ff80db9a43e589eee411deba30b0",
                "a325e33f157345ca90d9477b5a7f2f7e",
                "user-read-private,user-read-recently-played",
                new Uri("https://accounts.spotify.com/authorize"),
                new Uri("http://localhost:5000/spotifytoken"),
                new Uri("https://accounts.spotify.com/api/token"));
            auth.Completed += SpotifyAuth_Completed;
            var ui = auth.GetUI(this);
            StartActivity(ui);
        }

        private async void SpotifyAuth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                await StravaAuthServer.Stop();
                var request = new OAuth2Request(
                    "GET",
                    new Uri("https://api.spotify.com/v1/me/player/recently-played"),
                    null,
                    e.Account);

                var stravaResponse = await request.GetResponseAsync();
                var json = stravaResponse.GetResponseText();
                infoText.Text += json;
            }
        }
    }
}