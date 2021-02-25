namespace RD.CanMusicMakeYouRunFaster.Rest.Authenticators
{
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using RestSharp;
    using System.Collections.Generic;
    using System.Net.Http;

    /// <summary>
    /// Strava authenticator class, used for getting Auth tokens.
    /// </summary>
    public class StravaAuthenticator
    {
        private int  clientId = 61391;
        private string  clientSecret = ""; // TO BE CHANGED LATER ON IN DEV
        private RestClient restClient;

        public StravaAuthenticator(RestClient restClient)
        {
            this.restClient = restClient;
        }

        /// <summary>
        /// Gets an authentication token from the strava API.
        /// </summary>
        /// <returns> A Strava Authentication token</returns>
        public async StravaAuthenticationToken GetAuthToken()
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("client_id", clientId.ToString());
            request.AddHeader("redirect_uri","localhost:5001");
            request.AddHeader("response_type","ReplaceWithCode");
            request.AddHeader("scope","activity:read"); // comma seperated for each scope.

        }
    }
}