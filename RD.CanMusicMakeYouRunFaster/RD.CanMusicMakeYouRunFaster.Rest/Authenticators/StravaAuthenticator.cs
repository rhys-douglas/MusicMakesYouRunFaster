namespace RD.CanMusicMakeYouRunFaster.Rest.Authenticators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using RestSharp.Portable;
    using RestSharp.Portable.OAuth2;
    using RestSharp.Portable.OAuth2.Infrastructure;

    /// <summary>
    /// Authenticator used for getting a strava authentication token.
    /// </summary>
    public class StravaAuthenticator : OAuth2Authenticator
    {
        /// <summary>
        /// Access token retrieved from Strava servers.
        /// </summary>
        public string AccessToken
        {
            get
            {
                var accessToken = HttpContext.Current.Session["AccessToken"];
                return accessToken == null ? null : accessToken as string;
            }
            set
            {
                HttpContext.Current.Session["AccessToken"] = value;
            }
        }

        /// <summary>
        /// States whether authentication has been made.
        /// </summary>
        public bool IsAuthenticated => AccessToken != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StravaAuthenticator"/> class.
        /// </summary>
        /// <param name="client"></param>
        public StravaAuthenticator(OAuth2Client client) : base(client) 
        { 
        }

        public async Task<Uri> GetLoginLinkUri()
        {
            var uri = await Client.GetLoginLinkUri();
            return new Uri(uri);
        }

        public async Task<bool> OnPageLoaded(Uri uri)
        {
            if (uri.AbsoluteUri.StartsWith(Client.Configuration.RedirectUri))
            {
                Debug.WriteLine("Navigated to redirect url.");
                var parameters = uri.Query.Remove(0, 1).ParseQueryString(); // query portion of the response
                await Client.GetUserInfo(parameters);

                if (!string.IsNullOrEmpty(Client.AccessToken))
                {
                    AccessToken = Client.AccessToken;
                    return true;
                }
            }

            return false;
        }

        public override bool CanPreAuthenticate(IRestClient client, IRestRequest request, ICredentials credentials)
        {
            return true;
        }

        public override bool CanPreAuthenticate(IHttpClient client, IHttpRequestMessage request, ICredentials credentials)
        {
            return false;
        }

        public override async Task PreAuthenticate(IRestClient client, IRestRequest request, ICredentials credentials)
        {
            await Task.Delay(0);
            if (!string.IsNullOrEmpty(AccessToken))
                request.AddHeader("Authorization", "Bearer " + AccessToken);
        }

        public override Task PreAuthenticate(IHttpClient client, IHttpRequestMessage request, ICredentials credentials)
        {
            throw new System.NotImplementedException();
        }
    }
}
