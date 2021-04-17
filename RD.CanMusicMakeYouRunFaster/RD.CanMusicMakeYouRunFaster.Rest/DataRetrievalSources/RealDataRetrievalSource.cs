namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entity;
    using Fitbit.Api.Portable;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using RD.CanMusicMakeYouRunFaster.Rest.Authenticators;
    using RestSharp;
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
            await Task.Delay(0);
            var authenticator = new OAuth2Authenticator();
            var token = authenticator.GetStravaAuthToken();
            return new JsonResult(token.Result.access_token);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetFitBitAuthenticationToken()
        {
            await Task.Delay(0);
            var authenticator = new OAuth2Authenticator();
            var token = authenticator.GetFitBitAuthToken();
            return new JsonResult(token.Result.AccessToken);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyRecentlyPlayed(SpotifyAuthenticationToken authToken, long? after = null)
        {
            var request = new PlayerRecentlyPlayedRequest
            {
                After = after,
                Limit = 50
            };

            var spotifyClient = new SpotifyClient(authToken.AccessToken);
            var listeningHistory = await spotifyClient.Player.GetRecentlyPlayed(request);
            return new JsonResult(listeningHistory);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetStravaActivityHistory(StravaAuthenticationToken authToken)
        {
            await Task.Delay(0);
            var client = new RestClient("https://www.strava.com/api/v3/athlete/activities");
            var request = new RestRequest(Method.GET);
            request.AddParameter("access_token", authToken.access_token);
            IRestResponse response = client.Execute(request);
            var retrievedActivites = JsonConvert.DeserializeObject<List<Activity>>((string)response.Content);
            List<Activity> listOfRuns = new List<Activity>();
            foreach (var activity in retrievedActivites)
            {
                if (activity.type == "Run")
                {
                    listOfRuns.Add(activity);
                }
            }
            return new JsonResult(listOfRuns);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetFitBitActivityHistory(FitBitAuthenticationToken authToken)
        {
            await Task.Delay(0);
            FitbitAppCredentials credentials = new FitbitAppCredentials() 
            { 
                ClientId= "22CCZ8", 
                ClientSecret= "d73f338b7121d347da36be95000c959b" 
            };

            Fitbit.Api.Portable.OAuth2.OAuth2AccessToken accessToken = new Fitbit.Api.Portable.OAuth2.OAuth2AccessToken()
            {
                Token = authToken.AccessToken,
                ExpiresIn = authToken.ExpiresIn,
                RefreshToken = authToken.RefreshToken,
                TokenType = authToken.TokenType,
                UserId = authToken.UserId,
            };

            var client = new FitbitClient(credentials, accessToken);
            var lastWeek = DateTime.UtcNow;
            lastWeek.AddDays(-7);
            var retrievedActivities = await client.GetActivityLogsListAsync(null,lastWeek,20);
            return new JsonResult(retrievedActivities);
        }
    }
}
