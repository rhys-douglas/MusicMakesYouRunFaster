namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using SpotifyAPI.Web;
    using SpotifyAPI.Web.Auth;
    using Json.Net;


    /// <summary>
    /// Real data retrieval source, that will be used in the app itself.
    /// </summary>
    public class RealDataRetrievalSource : IDataRetrievalSource
    {
        private static readonly string clientId = "1580ff80db9a43e589eee411deba30b0";
        private static readonly EmbedIOAuthServer AuthServer = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
        /// <summary>
        /// Gets a Spotify OAuth Token
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetSpotifyOAuthToken()
        {
            var (verifier, challenge) = PKCEUtil.GenerateCodes(256);
            var tokenreturned = "";

            await AuthServer.Start();
            AuthServer.AuthorizationCodeReceived += async (sender, response) =>
            {
                await AuthServer.Stop();
                PKCETokenResponse token = await new OAuthClient().RequestToken(
                    new PKCETokenRequest(clientId!, response.Code, AuthServer.BaseUri, verifier));
                tokenreturned = JsonConvert.SerializeObject(token);
            };
            return null;
            //return Json(JsonConvert.SerializeObject(tokenreturned));
        }
    }
}
