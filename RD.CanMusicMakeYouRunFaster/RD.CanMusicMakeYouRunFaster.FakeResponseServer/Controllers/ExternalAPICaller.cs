namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;

    /// <summary>
    /// Fake spotify client, used for sending requests to the FakeResponse server.
    /// </summary>
    public class ExternalAPICaller
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalAPICaller"/> class.
        /// </summary>
        /// <param name="httpClient"> Http client to use for requests. </param>
        /// <param name="FakeServerUrl">Fake server url to query.</param>
        public ExternalAPICaller(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Sends a HTTP Get request to an endpoint.
        /// </summary>
        /// <typeparam name="TResponse"> Type of object to respond with.</typeparam>
        /// <param name="endpoint"> Target endpoint.</param>
        /// <returns>Tresponse casted object.</returns>
        public TResponse Get<TResponse>(Uri endpoint)
            where TResponse : class
        {
            var result = httpClient.GetAsync(endpoint).Result;
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            try
            {
                return JsonConvert.DeserializeObject<TResponse>(
                jsonResult,
                new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
