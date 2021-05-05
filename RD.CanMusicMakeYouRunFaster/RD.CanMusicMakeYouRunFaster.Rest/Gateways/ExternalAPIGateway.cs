namespace RD.CanMusicMakeYouRunFaster.Rest.Gateways
{
    using DataRetrievalSources;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Controller used to handle HTTP requests to the backend / external API's.
    /// </summary>
    [ApiController]
    [Route("/CMMYRF")]
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
        /// Gets the spotify authentication token.
        /// </summary>
        /// <returns>Spotify authentication token</returns>
        [HttpGet]
        [Route("getSpotifyAuthToken")]
        [EnableCors("CorsPolicy")]
        public JsonResult GetSpotifyAuthenticationToken()
        {
            var retrievedTokenJson = this.dataSource.GetSpotifyAuthenticationToken().Result;
            spotifyAuthToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)retrievedTokenJson.Value);
            return retrievedTokenJson;
        }

        /// <summary>
        /// Gets the strava authentication token.
        /// </summary>
        /// <returns> Strava authentication token</returns>
        [HttpGet]
        [Route("getStravaAuthToken")]
        [EnableCors("CorsPolicy")]
        public JsonResult GetStravaAuthenticationToken()
        {
            var stravaAuthenticationTokenAsJson = dataSource.GetStravaAuthenticationToken().Result;
            return stravaAuthenticationTokenAsJson;
        }

        /// <summary>
        /// Gets the FitBit authentication token.
        /// </summary>
        /// <returns>A FitBit auth token.</returns>
        [HttpGet]
        [Route("getFitBitAuthToken")]
        [EnableCors("CorsPolicy")]
        public JsonResult GetFitBitAuthenticationToken()
        {
            var fitBitAuthenticationTokenAsJson = dataSource.GetFitBitAuthenticationToken().Result;
            return fitBitAuthenticationTokenAsJson;
        }

        /// <summary>
        /// Gets the strava recent activties.
        /// </summary>
        /// <returns> Strava recent activities </returns>
        [HttpGet]
        [Route("getStravaActivities")]
        [EnableCors("CorsPolicy")]
        public JsonResult GetStravaRecentActivities(string access_token)
        {
            var tempToken = new StravaAuthenticationToken { access_token = access_token };
            return this.dataSource.GetStravaActivityHistory(tempToken).Result;
        }

        /// <summary>
        /// Gets a <see cref="Fitbit.Api.Portable.Models.ActivityLogsList"/> object, containing FitBit runs.
        /// </summary>
        /// <returns> A list of FitBit runs.</returns>
        [HttpGet]
        [Route("getFitBitActivities")]
        [EnableCors("CorsPolicy")]
        public JsonResult GetFitBitRecentActivities(string access_token)
        {
            var tempToken = new FitBitAuthenticationToken { AccessToken = access_token };
            return this.dataSource.GetFitBitActivityHistory(tempToken).Result;
        }

        /// <summary>
        /// Gets the Spotify recently played tracks
        /// </summary>
        /// <param name="after"> UNIX timestamp to search after </param>
        /// <returns>Spotify recently played tracks</returns>
        public JsonResult GetSpotifyRecentlyPlayed(long? after = null)
        {
            return this.dataSource.GetSpotifyRecentlyPlayed(this.spotifyAuthToken, after).Result;
        }

        /// <summary>
        /// Gets the Last.FM recently played tracks.
        /// </summary>
        /// <param name="username">Username to query for. </param>
        /// <param name="after"> DateTime to search after.</param>
        /// <returns></returns>
        public JsonResult GetLastFMRecentlyPlayed(string username, DateTimeOffset? after = null)
        {
            return this.dataSource.GetLastFMRecentlyPlayed(username, after).Result;
        }
    }
}
