namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
    using System.Security.Cryptography;
    using System;
    using Microsoft.AspNetCore.Mvc;
    using RD.CanMusicMakeYouRunFaster.Rest.DTO;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Net.Http;

    /// <summary>
    /// Fake data source used for tests.
    /// </summary>
    public class FakeDataRetrievalSource : IDataRetrievalSource
    {
        private readonly HttpClient httpClient;
        private readonly Uri fakeSpotifyAuthUrl = new Uri("localhost:8080");

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDataRetrievalSource"/> class.
        /// </summary>
        public FakeDataRetrievalSource()
        {
            httpClient = new HttpClient();
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyAuthenticationToken()
        {
            await Task.Delay(1);
            var httpClientResponse = httpClient.GetAsync(fakeSpotifyAuthUrl).Result;
            var tokenAsJson = httpClientResponse.Content.ReadAsStringAsync().Result;
            var token = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>(tokenAsJson,
                new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });
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
