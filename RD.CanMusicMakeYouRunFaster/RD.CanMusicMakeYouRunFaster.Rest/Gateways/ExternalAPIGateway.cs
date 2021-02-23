namespace RD.CanMusicMakeYouRunFaster.Rest.Gateways
{
    using DataRetrievalSources;
    using FakeResponseServer.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;

    /// <summary>
    /// Controller used to handle HTTP requests to the backend / external API's.
    /// </summary>
    public class ExternalAPIGateway : ControllerBase
    {
        private readonly IDataRetrievalSource dataSource;
        private SpotifyAuthenticationToken spotifyAuthToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalAPIGateway"/> class.
        /// </summary>
        /// <param name="dataSource"> Data source to use.</param>
        public ExternalAPIGateway(IDataRetrievalSource dataSource = null)
        {
            if (dataSource == null)
            {
                dataSource = new RealDataRetrievalSource();
            }

            this.dataSource = dataSource;
        }

        /// <summary>
        /// Gets the spotify recently played tracks
        /// </summary>
        /// <returns>Spotify recently played tracks</returns>
        public JsonResult GetSpotifyRecentlyPlayed()
        {
            return this.dataSource.GetSpotifyRecentlyPlayed(this.spotifyAuthToken).Result;
        }

        /// <summary>
        /// Gets the spotify authentication token
        /// </summary>
        /// <returns>Spotify authentication token</returns>
        public JsonResult GetSpotifyAuthenticationToken()
        {
            var retrievedTokenJson = this.dataSource.GetSpotifyAuthenticationToken().Result;
            var temp = JsonConvert.SerializeObject(retrievedTokenJson.Value);
            spotifyAuthToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>(temp);
            return retrievedTokenJson;
        }
    }
}
