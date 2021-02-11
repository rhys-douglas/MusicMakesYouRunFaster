namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using SpotifyAPI.Web;
    using SpotifyAPI.Web.Auth;

    /// <summary>
    /// Real data retrieval source, that will be used in the app itself.
    /// </summary>
    public class RealDataRetrievalSource : IDataRetrievalSource
    {
        private static readonly string ClientId = "1580ff80db9a43e589eee411deba30b0";
        private static readonly EmbedIOAuthServer AuthServer = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
        
        /// <summary>
        /// Gets a Spotify OAuth Token
        /// </summary>
        /// <returns> A spotify OAuth token wrapped in JSON.</returns>
        public async Task<JsonResult> GetSpotifyOAuthToken()
        {
            var (verifier, challenge) = PKCEUtil.GenerateCodes();
            var tokenreturned = string.Empty;

            await AuthServer.Start();
            AuthServer.AuthorizationCodeReceived += async (sender, response) =>
            {
                await AuthServer.Stop();
                PKCETokenResponse token = await new OAuthClient().RequestToken(
                    new PKCETokenRequest(ClientId, response.Code, AuthServer.BaseUri, verifier));
                tokenreturned = JsonConvert.SerializeObject(token);
            };
            ////return Json(JsonConvert.SerializeObject(tokenreturned));
            return null;
        }
    }
}
