namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;

    /// <summary>
    /// Fake spotify client, used for sending requests to the FakeResponse server.
    /// </summary>
    public class SpotifyClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpotifyClient"/> class.
        /// </summary>
        /// <param name="httpClient"> Http client to use for requests. </param>
        /// <param name="FakeServerUrl">Fake server url to query.</param>
        public SpotifyClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Sends a HTTP Get request to an endpoint.
        /// </summary>
        /// <typeparam name="TResponse"> Type of object to respond with.</typeparam>
        /// <param name="endpoint"> Target endpoint.</param>
        /// <param name="queryparams"> Query params.</param>
        /// <returns></returns>
        public TResponse Get<TResponse>(Uri endpoint, string queryparams = null)
            where TResponse : class
        {
            var result = httpClient.GetAsync(endpoint).Result;
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            
            return JsonConvert.DeserializeObject<TResponse>(
                jsonResult,
                new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });
        }
    }
}
