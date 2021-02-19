namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
    using System.Security.Cryptography;
    using System;
    using Microsoft.AspNetCore.Mvc;
    using RD.CanMusicMakeYouRunFaster.Rest.DTO;
    using System.Threading.Tasks;
    using SpotifyAPI.Web;
    using SpotifyAPI.Web.Auth;
    using static SpotifyAPI.Web.Scopes;
    using Newtonsoft.Json;

    /// <summary>
    /// Fake data source used for tests.
    /// </summary>
    public class FakeDataRetrievalSource : IDataRetrievalSource
    {

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyAuthenticationToken()
        {
            var token = string.Empty;

            await Task.Run(() =>
            {
                RandomNumberGenerator rng = new RNGCryptoServiceProvider();
                byte[] buffer = new byte[100];
                rng.GetBytes(buffer);
                string unqiueString = Convert.ToBase64String(buffer);
                var token = JsonConvert.SerializeObject(unqiueString);
            });

            return new JsonResult(token);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyRecentlyPlayed(SpotifyAuthenticationToken authToken)
        {
            // gets something
            var musicHistory = "";

            await Task.Run(() =>
            {
                musicHistory = JsonConvert.SerializeObject("Yayeet");
            });

            return new JsonResult(musicHistory);
        }
    }
}
