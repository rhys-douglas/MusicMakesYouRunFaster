namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entity;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using RD.CanMusicMakeYouRunFaster.Rest.Authenticators;
    using SpotifyAPI.Web;
    using SpotifyAPI.Web.Auth;
    using static SpotifyAPI.Web.Scopes;

    /// <summary>
    /// Real data retrieval source, that will be used in the app itself.
    /// </summary>
    public class RealDataRetrievalSource : IDataRetrievalSource
    {
        private static readonly string SpotifyClientId = "1580ff80db9a43e589eee411deba30b0";
        private static readonly EmbedIOAuthServer AuthServer = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
        private int stravaClientId = 61391;
        private const string stravaClientSecret = "???"; // TO BE CHANGED LATER ON IN DEV
        private de.schumacher_bw.Strava.StravaApiV3Sharp stravaClient;

        public RealDataRetrievalSource()
        {
            string serializedApi = System.IO.File.Exists(stravaAuth) ? System.IO.File.ReadAllText(stravaAuth) : null;
            stravaClient = new de.schumacher_bw.Strava.StravaApiV3Sharp(stravaClientId, stravaClientSecret, serializedApi);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyAuthenticationToken()
        {
            var authToken = string.Empty;

            var (verifier, challenge) = PKCEUtil.GenerateCodes();
            await AuthServer.Start();

            // Temporary auth server lsitens for Spotify callback.
            AuthServer.AuthorizationCodeReceived += async (sender, response) =>
            {
                await AuthServer.Stop();
                PKCETokenResponse token = await new OAuthClient().RequestToken(
                  new PKCETokenRequest(SpotifyClientId, response.Code, AuthServer.BaseUri, verifier));
                authToken = JsonConvert.SerializeObject(token);
            };

            // Make spotify auth call.
            var request = new LoginRequest(AuthServer.BaseUri, SpotifyClientId, LoginRequest.ResponseType.Code)
            {
                CodeChallenge = challenge,
                CodeChallengeMethod = "S256",
                Scope = new List<string> { UserReadPrivate, UserReadRecentlyPlayed }
            };

            Uri uri = request.ToUri();
            try
            {
                BrowserUtil.Open(uri);
                Task.Delay(10000).Wait();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to open URL, manually open: {0}", uri);
            }

            return new JsonResult(authToken);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetStravaAuthenticationToken()
        {
            await Task.Delay(0);
            /*
            // var authUrl = @"https://www.strava.com/oauth/authorize";
            string stravaAuth = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "stravaApi.txt");
            stravaClient.SerializedObjectChanged += (s, e) => System.IO.File.WriteAllText(stravaAuth, stravaApi.Serialize());

            if (stravaApi.Authentication.Scope == de.schumacher_bw.Strava.Model.Scopes.None_Unknown)
            {
                // ensure to be called again once the authentication is done. 
                // We will be forewared to a not existing url and catch this event
                webView.NavigationStarting += (s, e) =>
                {
                    if (e.Uri?.AbsoluteUri.StartsWith(callbackUrl) ?? false) // in case we are forewarded to the callback URL
                    {
                        api.Authentication.DoTokenExchange(e.Uri); // do the token exchange with the stava api
                        ShowInfoInBrowser(api, webView);
                    }
                };

                // navigate to the strava auth page to get read access 
                webView.Navigate(api.Authentication.GetAuthUrl(new Uri(callbackUrl), de.schumacher_bw.Strava.Model.Scopes.Read));
            }
            else // the api is allready connected and the information have been loaded from the stravaAuth-file
            {
                ShowInfoInBrowser(api, webView);
            }

            */
            var settings = new Pepperoni.Strava.Models.StravaClientSettings(stravaClientId.ToString(), stravaClientSecret, "", "");
            var client = new Pepperoni.Strava.StravaClient(settings);
            return new JsonResult("");
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyRecentlyPlayed(SpotifyAuthenticationToken authToken)
        {
            var spotifyClient = new SpotifyClient(authToken.AccessToken);

            var listeningHistory = await spotifyClient.Player.GetRecentlyPlayed();
            return new JsonResult(listeningHistory);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetStravaActivityHistory(StravaAuthenticationToken authToken)
        {
            // var activityHistory = stravaClient.Activities.GetLoggedInAthleteActivities();
            await Task.Delay(0);
            return new JsonResult("some object");
        }
    }
}
