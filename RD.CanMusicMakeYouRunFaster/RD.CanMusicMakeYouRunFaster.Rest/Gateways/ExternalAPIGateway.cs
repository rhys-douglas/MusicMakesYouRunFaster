namespace RD.CanMusicMakeYouRunFaster.Rest.Gateways
{
    using DataRetrievalSources;
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
        private StravaAuthenticationToken stravaAuthToken;

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

        /// <summary>
        /// Gets the strava authentication token
        /// </summary>
        /// <returns> Strava authentication token</returns>
        public JsonResult GetStravaAuthenticationToken()
        {
            var stravaAuthenticationTokenAsJson = this.dataSource.GetStravaAuthenticationToken().Result;
            var temp = JsonConvert.SerializeObject(stravaAuthenticationTokenAsJson.Value);
            stravaAuthToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>(temp);
            return new JsonResult(stravaAuthToken);
        }

        /// <summary>
        /// Gets the strava recent activties
        /// </summary>
        /// <returns> Strava recent activities </returns>
        public JsonResult GetStravaRecentActivities()
        {
            return this.dataSource.GetStravaActivityHistory(this.stravaAuthToken).Result;
        }

        /// <summary>
        /// Gets the spotify recently played tracks
        /// </summary>
        /// <returns>Spotify recently played tracks</returns>
        public JsonResult GetSpotifyRecentlyPlayed(long after = -1)
        {
            if (after == 0)
            {

            }
            return this.dataSource.GetSpotifyRecentlyPlayed(this.spotifyAuthToken).Result;
        }
    }
}
