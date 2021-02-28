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
        private const string clientSecret = "8b0eb19e37bbbeffc8b8ba75efdb1b7f9c2cfc95 "; // TO BE CHANGED LATER ON IN DEV
        private RestClient restClient;
        private static readonly EmbedIOAuthServer StravaAuthServer = new EmbedIOAuthServer(new Uri("http://localhost:5001/stravatoken"), 5001);

        public StravaAuthenticator(RestClient restClient)
        {
            this.restClient = restClient;
        }

        /// <summary>
        /// Gets an authentication token from the strava API.
        /// </summary>
        /// <returns> A Strava Authentication token</returns>
        public async Task<StravaAuthenticationToken> GetAuthToken()
        {
            await StravaAuthServer.Start();
            var exchangeToken = string.Empty;

            // Temporary auth server lsitens for Strava callback.
            StravaAuthServer.AuthorizationCodeReceived += async (sender, response) =>
            {
                await StravaAuthServer.Stop();
                StravaExchangeToken token = await new OAuthClient().RequestToken(
                  new PKCETokenRequest(SpotifyClientId, response.Code, SpotifyAuthServer.BaseUri, verifier));
                authToken = JsonConvert.SerializeObject(token);
            };

            // Open page for login request
            var authTokenUri = new Uri("http://www.strava.com/oauth/authorize?client_id=61391&response_type=code&redirect_uri=http://localhost:5001/stravatoken&approval_prompt=force&scope=activity:read_all");
            BrowserUtil.Open(authTokenUri);
            await StravaAuthServer.Stop(); 
            return JsonConvert.DeserializeObject<StravaAuthenticationToken>("");
        }
    }
}