namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Net.Http;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;

    /// <summary>
    /// Fake data source used for tests.
    /// </summary>
    public class FakeDataRetrievalSource : IDataRetrievalSource
    {
        private readonly SpotifyClient spotifyClient;
        private readonly Uri fakeSpotifyAuthUrl = new Uri("localhost:8080");

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDataRetrievalSource"/> class.
        /// </summary>
        public FakeDataRetrievalSource(SpotifyClient spotifyClient)
        {
            this.spotifyClient = spotifyClient;
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyAuthenticationToken()
        {
            await Task.Delay(1);
            var authTokenResponse = spotifyClient.Get<SpotifyAuthenticationToken>(new Uri("http://localhost/authorize"));
            return new JsonResult(authTokenResponse);

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
