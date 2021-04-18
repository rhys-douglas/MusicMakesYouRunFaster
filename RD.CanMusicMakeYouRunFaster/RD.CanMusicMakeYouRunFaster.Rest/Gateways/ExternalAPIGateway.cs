﻿namespace RD.CanMusicMakeYouRunFaster.Rest.Gateways
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
        private LastFMAuthenticationToken lastFMAuthToken;
        private StravaAuthenticationToken stravaAuthToken;
        private FitBitAuthenticationToken fitBitAuthToken;

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
            var stravaAuthenticationTokenAsJson = dataSource.GetStravaAuthenticationToken().Result;
            var temp = JsonConvert.SerializeObject(stravaAuthenticationTokenAsJson.Value);
            stravaAuthToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>(temp);
            return new JsonResult(stravaAuthToken);
        }

        /// <summary>
        /// Gets the FitBit authentication token.
        /// </summary>
        /// <returns>A FitBit auth token.</returns>
        public JsonResult GetFitBitAuthenticationToken()
        {
            var fitBitAuthenticationTokenAsJson = dataSource.GetFitBitAuthenticationToken().Result;
            var tempSerialize = JsonConvert.SerializeObject(fitBitAuthenticationTokenAsJson.Value);
            fitBitAuthToken = JsonConvert.DeserializeObject<FitBitAuthenticationToken>(tempSerialize);
            return new JsonResult(fitBitAuthToken);
        }

        /// <summary>
        /// Gets the Last.FM authentication token.
        /// </summary>
        /// <returns>A Last.FM auth token.</returns>
        public JsonResult GetLastFMAuthenticationToken()
        {
            var lastFMAuthenticationTokenAsJson = dataSource.GetLastFMAuthenticationToken().Result;
            var tempSerialize = JsonConvert.SerializeObject(lastFMAuthenticationTokenAsJson.Value);
            lastFMAuthToken = JsonConvert.DeserializeObject<LastFMAuthenticationToken>(tempSerialize);
            return new JsonResult(fitBitAuthToken);
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
        /// Gets a <see cref="Fitbit.Api.Portable.Models.ActivityLogsList"/> object, containing FitBit runs.
        /// </summary>
        /// <returns> A list of FitBit runs.</returns>
        public JsonResult GetFitBitRecentActivities()
        {
            return this.dataSource.GetFitBitActivityHistory(this.fitBitAuthToken).Result;
        }

        /// <summary>
        /// Gets the spotify recently played tracks
        /// </summary>
        /// <param name="after"> UNIX timestamp to search after </param>
        /// <returns>Spotify recently played tracks</returns>
        public JsonResult GetSpotifyRecentlyPlayed(long? after = null)
        {
            return this.dataSource.GetSpotifyRecentlyPlayed(this.spotifyAuthToken, after).Result;
        }

        public JsonResult GetLastFMRecentlyPlayed(long? after = null)
        {
            return this.dataSource.GetLastFMRecentlyPlayed(this.lastFMAuthToken, after).Result;
        }
    }
}
