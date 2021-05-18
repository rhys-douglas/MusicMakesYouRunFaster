namespace RD.CanMusicMakeYouRunFaster.Rest.Gateways
{
    using DataRetrievalSources;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using SpotifyAPI.Web;
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
        public JsonResult GetStravaRecentActivities(string access_token, DateTimeOffset? start_date= null, DateTimeOffset? end_date = null)
        {
            var tempToken = new StravaAuthenticationToken { access_token = access_token };
            var activityHistoryJsonResult = this.dataSource.GetStravaActivityHistory(tempToken).Result;
            if (start_date == null && end_date == null)
            {
                return activityHistoryJsonResult;
            }

            List<StravaActivity> rawActivityHistory = (List<StravaActivity>)activityHistoryJsonResult.Value;
            List<StravaActivity> correctActivityHistory = new List<StravaActivity>();

            if (start_date == null && end_date != null)
            {
                // Start date is null, but there is an end date.
                // return all activities before the end date.
                DateTimeOffset extractedEndDate = (DateTimeOffset)end_date;
                foreach (var item in rawActivityHistory)
                {
                    if (item.start_date <= extractedEndDate)
                    {
                        correctActivityHistory.Add(item);
                    }
                }
                return new JsonResult(correctActivityHistory);
            }

            if (start_date != null && end_date == null)
            {
                // End date is null but there is a start date.
                // return all activities from start date until now.
                DateTimeOffset extractedStartDate = (DateTimeOffset)start_date;
                foreach (var item in rawActivityHistory)
                {
                    if (item.start_date >= extractedStartDate)
                    {
                        correctActivityHistory.Add(item);
                    }
                }
                return new JsonResult(correctActivityHistory);
            }
            // Assume that start and end date are both not null.
            DateTimeOffset startDate = (DateTimeOffset)start_date;
            DateTimeOffset endDate = (DateTimeOffset)end_date;

            foreach(var activity in rawActivityHistory)
            {
                if (activity.start_date >= startDate && activity.start_date <= endDate)
                {
                    correctActivityHistory.Add(activity);
                }
            }

            return new JsonResult(correctActivityHistory);
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
        /// <param name="access_token"> Access token </param>
        /// <param name="after"> UNIX timestamp to search after </param>
        /// <param name="duration"> Duration of activity </param>
        /// <returns>Spotify recently played tracks</returns>
        [HttpGet]
        [Route("getSpotifyRecentlyPlayed")]
        [EnableCors("CorsPolicy")]
        public JsonResult GetSpotifyRecentlyPlayed(string access_token, DateTimeOffset? after = null, double? duration = null)
        {
            CursorPaging<PlayHistoryItem> playHistory = new CursorPaging<PlayHistoryItem>();
            var tempToken = new SpotifyAuthenticationToken { AccessToken = access_token };
            if (after != null)
            {
                DateTimeOffset actualAfter = (DateTimeOffset)after;
                var afterAsUnix = actualAfter.ToUnixTimeMilliseconds();
                playHistory = (CursorPaging<PlayHistoryItem>)this.dataSource.GetSpotifyRecentlyPlayed(tempToken, afterAsUnix).Result.Value;

                if (duration != null)
                {
                    var actualDuration = (double)duration;
                    var end = actualAfter.AddSeconds(actualDuration);
                    var validSongs = new List<PlayHistoryItem>();
                    foreach (var track in playHistory.Items)
                    {
                        if (track.PlayedAt >= actualAfter && track.PlayedAt < end)
                        {
                            validSongs.Add(track);
                        }
                    }
                    playHistory.Items = validSongs;
                    return new JsonResult(playHistory);
                }

                return new JsonResult(playHistory);
            }
            else
            {
                playHistory = (CursorPaging<PlayHistoryItem>)this.dataSource.GetSpotifyRecentlyPlayed(tempToken, null).Result.Value;
                return new JsonResult(playHistory);
            }
        }

        /// <summary>
        /// Gets the Last.FM recently played tracks.
        /// </summary>
        /// <param name="username">Username to query for.</param>
        /// <param name="after"> DateTime to search after.</param>
        /// <param name="duration"> Duration of activity.</param>
        /// <returns> Recently played LastFM tracks.</returns>
        [HttpGet]
        [Route("getLastFMRecentlyPlayed")]
        [EnableCors("CorsPolicy")]
        public JsonResult GetLastFMRecentlyPlayed(string user_name, DateTimeOffset? after = null, double duration = 0)
        {
            List<IF.Lastfm.Core.Objects.LastTrack> validListeningHistory = new List<IF.Lastfm.Core.Objects.LastTrack>();
            IF.Lastfm.Core.Api.Helpers.PageResponse<IF.Lastfm.Core.Objects.LastTrack> returnedHistory = (IF.Lastfm.Core.Api.Helpers.PageResponse<IF.Lastfm.Core.Objects.LastTrack>)this.dataSource.GetLastFMRecentlyPlayed(user_name, after).Result.Value;
            if (duration != 0)
            {
                double actualDuration = (double)duration;
                var actualAfter = (DateTimeOffset)after;
                var end = actualAfter.AddSeconds(actualDuration);
                foreach (var item in returnedHistory.Content)
                {
                    if (item.TimePlayed >= actualAfter && item.TimePlayed < end)
                    {
                        validListeningHistory.Add(item);
                    }
                }
                return new JsonResult(new IF.Lastfm.Core.Api.Helpers.PageResponse<IF.Lastfm.Core.Objects.LastTrack>(validListeningHistory));
            }
            else
            {
                return new JsonResult(returnedHistory);
            }

        }
    }
}
