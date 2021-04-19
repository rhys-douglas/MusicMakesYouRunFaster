namespace RD.CanMusicMakeYouRunFaster.Rest.Authenticators
{
    using Newtonsoft.Json;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using RestSharp;
    using SpotifyAPI.Web.Auth;
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// Authenticator class used for acquiring OAUTH2 access tokens from various APIs.
    /// </summary>
    public class OAuth2Authenticator
    {
        private static readonly EmbedIOAuthServer StravaAuthServer = new EmbedIOAuthServer(new Uri("http://localhost:5001/stravatoken"), 5001);
        private static readonly EmbedIOAuthServer FitBitAuthServer = new EmbedIOAuthServer(new Uri("http://localhost:5002/fitbittoken"), 5002);
        private static readonly EmbedIOAuthServer LastFMAuthServer = new EmbedIOAuthServer(new Uri("http://localhost:5003/lastfmtoken/"), 5003);
        private StravaAuthenticationToken stravaAuthToken = new StravaAuthenticationToken();
        private FitBitAuthenticationToken fitBitAuthToken = new FitBitAuthenticationToken();
        private LastFMAuthenticationToken lastFMAuthToken = new LastFMAuthenticationToken();

        /// <summary>
        /// Gets an authentication token from the strava API.
        /// </summary>
        /// <returns> A Strava Authentication token</returns>
        public async Task<StravaAuthenticationToken> GetStravaAuthToken()
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
                IRestResponse accessTokenResponse = client.Execute(request);
                stravaAuthToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>(accessTokenResponse.Content);
            };

            // Open page for login request
            var authTokenUri = new Uri("http://www.strava.com/oauth/authorize?client_id=61391&response_type=code&redirect_uri=http://localhost:5001/stravatoken&approval_prompt=force&scope=activity:read_all");
            BrowserUtil.Open(authTokenUri);
            Task.Delay(20000).Wait();
            return stravaAuthToken;
        }

        /// <summary>
        /// Authenticates a FitBit user using the FitBit Web API.
        /// </summary>
        /// <returns> A FitBit Authentication token </returns>
        public async Task<FitBitAuthenticationToken> GetFitBitAuthToken()
        {
            await FitBitAuthServer.Start();
            var exchangeToken = string.Empty;
            var authTokenAsString = string.Empty;

            FitBitAuthServer.AuthorizationCodeReceived += async (sender, response) =>
            {
                await StravaAuthServer.Stop();
                exchangeToken = response.Code;
                var client = new RestClient("https://api.fitbit.com/oauth2/token?client_id=22CCZ8&grant_type=authorization_code&redirect_uri=http://localhost:5002/fitbittoken");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic MjJDQ1o4OmQ3M2YzMzhiNzEyMWQzNDdkYTM2YmU5NTAwMGM5NTli");
                request.AddParameter("code", exchangeToken);
                IRestResponse accessTokenResponse = client.Execute(request);
                fitBitAuthToken = JsonConvert.DeserializeObject<FitBitAuthenticationToken>(accessTokenResponse.Content);
            };

            var authTokenUri = new Uri("https://www.fitbit.com/oauth2/authorize?response_type=code&client_id=22CCZ8&redirect_uri=http://localhost:5002/fitbittoken&scope=activity%20heartrate");
            BrowserUtil.Open(authTokenUri);
            Task.Delay(20000).Wait();
            return fitBitAuthToken;
        }

        /// <summary>
        /// Authenticates a LastFM user using the LastFM web api.
        /// </summary>
        /// <returns> A LastFM authentication Token. </returns>
        public async Task<LastFMAuthenticationToken> GetLastFMAuthToken()
        {
            await LastFMAuthServer.Start();
            var exchangeToken = string.Empty;
            var authTokenAsString = string.Empty;

            FitBitAuthServer.AuthorizationCodeReceived += async (sender, response) =>
            {
                await StravaAuthServer.Stop();
                exchangeToken = response.Code;
                var client = new RestClient("http://www.last.fm/api/auth?api_key=d3cf196e63d20375eb8d6729ebb982b3&api_sig=");
                var request = new RestRequest(Method.POST);
                string concatenatedParams = "api_keyd3cf196e63d20375eb8d6729ebb982b3methodauth.getSessiontoken" + exchangeToken + "3b2dd16f5d94f119aa724dd3efe3b393";
                var md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(concatenatedParams);
                byte[] api_sigAsBytes = md5.ComputeHash(inputBytes);
                md5.Dispose();
                request.AddParameter("token", exchangeToken);
                request.AddParameter("api_sig", api_sigAsBytes);
                IRestResponse accessTokenResponse = client.Execute(request);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(LastFMAuthenticationToken));
                using (TextReader reader = new StringReader(accessTokenResponse.Content))
                {
                    lastFMAuthToken = (LastFMAuthenticationToken)xmlSerializer.Deserialize(reader);
                }
            };

            var authTokenUri = new Uri("http://www.last.fm/api/auth/?api_key=d3cf196e63d20375eb8d6729ebb982b3&cb=http://localhost:5003/lastfmtoken");
            BrowserUtil.Open(authTokenUri);
            Task.Delay(20000).Wait();
            return lastFMAuthToken;
        }
    }
}