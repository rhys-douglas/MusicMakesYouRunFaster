namespace RD.CanMusicMakeYouRunFaster.Rest.Authenticators
{
    using Newtonsoft.Json;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using RestSharp;
    using SpotifyAPI.Web.Auth;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Strava authenticator class, used for getting Auth tokens.
    /// </summary>
    public class StravaAuthenticator
    {
        private static readonly EmbedIOAuthServer StravaAuthServer = new EmbedIOAuthServer(new Uri("http://localhost:5001/stravatoken"), 5001);
        private StravaAuthenticationToken authToken = new StravaAuthenticationToken();

        /// <summary>
        /// Gets an authentication token from the strava API.
        /// </summary>
        /// <returns> A Strava Authentication token</returns>
        public async Task<StravaAuthenticationToken> GetAuthToken()
        {
            await StravaAuthServer.Start();
            var exchangeToken = string.Empty;
            var authTokenAsString = string.Empty;

            // Temporary auth server lsitens for Strava callback.
            StravaAuthServer.AuthorizationCodeReceived += async (sender, response) =>
            {
                await StravaAuthServer.Stop();
                exchangeToken = response.Code;
                var client = new RestClient("https://www.strava.com/oauth/token?client_id=61391&client_secret=8b0eb19e37bbbeffc8b8ba75efdb1b7f9c2cfc95&grant_type=authorization_code");
                var request = new RestRequest(Method.POST);
                request.AddParameter("code", exchangeToken);
                IRestResponse tokenRequest = client.Execute(request);
                authToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>(tokenRequest.Content);
            };

            // Open page for login request
            var authTokenUri = new Uri("http://www.strava.com/oauth/authorize?client_id=61391&response_type=code&redirect_uri=http://localhost:5001/stravatoken&approval_prompt=force&scope=activity:read_all");
            BrowserUtil.Open(authTokenUri);
            Task.Delay(20000).Wait();
            return authToken;
        }
    }
}