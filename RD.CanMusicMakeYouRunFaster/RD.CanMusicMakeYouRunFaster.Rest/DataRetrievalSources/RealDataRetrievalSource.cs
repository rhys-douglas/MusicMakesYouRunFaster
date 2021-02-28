﻿namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
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
        private static readonly EmbedIOAuthServer SpotifyAuthServer = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyAuthenticationToken()
        {
            var authToken = string.Empty;

            var (verifier, challenge) = PKCEUtil.GenerateCodes();
            await SpotifyAuthServer.Start();

            // Temporary auth server lsitens for Spotify callback.
            SpotifyAuthServer.AuthorizationCodeReceived += async (sender, response) =>
            {
                await SpotifyAuthServer.Stop();
                PKCETokenResponse token = await new OAuthClient().RequestToken(
                  new PKCETokenRequest(SpotifyClientId, response.Code, SpotifyAuthServer.BaseUri, verifier));
                authToken = JsonConvert.SerializeObject(token);
            };

            // Make spotify auth call.
            var request = new LoginRequest(SpotifyAuthServer.BaseUri, SpotifyClientId, LoginRequest.ResponseType.Code)
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
            var authenticator = new StravaAuthenticator(new RestSharp.RestClient());
            var token = authenticator.GetAuthToken();
            await Task.Delay(0);
            return new JsonResult(JsonConvert.SerializeObject(token));
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
