﻿namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using System.Collections.Generic;
    using System.Linq;
    using SpotifyAPI.Web;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;
    using RD.CanMusicMakeYouRunFaster.ComparisonLogic.Mappers;
    using RD.CanMusicMakeYouRunFaster.ComparisonLogic.Managers;
    using System;
    using IF.Lastfm.Core.Objects;
    using IF.Lastfm.Core.Api.Helpers;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using Newtonsoft.Json;

    /// <summary>
    /// Client driver for testing without a front-end.
    /// </summary>
    public class ApiClientDriver : IClientDriver
    {
        private List<object> searchResults = new List<object>();
        private Dictionary<object, List<object>> activitiesAndSongs = new Dictionary<object, List<object>>();
        private Dictionary<object, List<object>> fastestActivityAndSongs = new Dictionary<object, List<object>>();
        private ExternalAPIGateway externalAPIGateway;
        private InferenceAPIGateway inferenceAPIGateway;
        private string userName;

        /// <inheritdoc/>
        public void SetUp(ExternalAPIGateway externalAPIGateway)
        {
            this.externalAPIGateway = externalAPIGateway;
            this.inferenceAPIGateway = new InferenceAPIGateway();
        }

        /// <inheritdoc/>
        public void TearDown()
        {
            searchResults = new List<object>();
            activitiesAndSongs = new Dictionary<object, List<object>>();
            fastestActivityAndSongs = new Dictionary<object, List<object>>();
        }

        /// <inheritdoc/>
        public void RegisterUser(string user)
        {
            userName = user;
        }


        /// <inheritdoc/>
        public void GetSpotifyRecentlyPlayedMusic()
        {
            string authToken = (string)externalAPIGateway.GetSpotifyAuthenticationToken().Value;
            var searchResult = externalAPIGateway.GetSpotifyRecentlyPlayed(authToken);
            var playHistoryContainer = (CursorPaging<PlayHistoryItem>)searchResult.Value;
            foreach (var song in playHistoryContainer.Items)
            {
                searchResults.Add(song);
            }
        }

        /// <inheritdoc/>
        public void GetLastFMRecentlyPlayedMusic()
        {
            var searchResult = externalAPIGateway.GetLastFMRecentlyPlayed(userName);
            var playHistoryContainer = (PageResponse<LastTrack>)searchResult.Value;
            foreach (var song in playHistoryContainer.Content)
            {
                searchResults.Add(song);
            }
        }

        /// <inheritdoc/>
        public void GetRecentStravaActivities()
        {
            var authToken = externalAPIGateway.GetStravaAuthenticationToken().Value;
            var actualToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>((string)authToken);
            var searchresult = externalAPIGateway.GetStravaRecentActivities(actualToken.access_token);
            var activityHistoryContainer = (List<StravaActivity>)searchresult.Value;
            foreach (var activity in activityHistoryContainer)
            {
                searchResults.Add(activity);
            }
        }

        /// <inheritdoc/>
        public void GetRecentFitBitActivities()
        {
            var authToken = externalAPIGateway.GetFitBitAuthenticationToken().Value;
            var actualToken = JsonConvert.DeserializeObject<FitBitAuthenticationToken>((string)authToken);
            var searchResult = externalAPIGateway.GetFitBitRecentActivities(actualToken.AccessToken);
            var activityHistoryContainer = (Fitbit.Api.Portable.Models.ActivityLogsList)searchResult.Value;
            foreach (var activity in activityHistoryContainer.Activities)
            {
                searchResults.Add(activity);
            }
        }

        /// <inheritdoc/>
        public void GetRecentlyPlayedMusicForActivities()
        {
            var tokenAsJson = externalAPIGateway.GetSpotifyAuthenticationToken();
            var spotifyAuthToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)tokenAsJson.Value);
            foreach (var item in searchResults)
            {
                if (item is StravaActivity activity)
                {
                    DateTimeOffset startDateAsDateTime = activity.start_date;

                    // Get Spotify songs
                    var spotifySearchResult = externalAPIGateway.GetSpotifyRecentlyPlayed(spotifyAuthToken.AccessToken, startDateAsDateTime);
                    CursorPaging<PlayHistoryItem> playHistoryContainer = (CursorPaging<PlayHistoryItem>)spotifySearchResult.Value;
                    List<PlayHistoryItem> spotifyFoundSongs = playHistoryContainer.Items.ToList();
                    // Get Last.FM songs
                    var lastFMSearchResult = externalAPIGateway.GetLastFMRecentlyPlayed(userName, startDateAsDateTime);
                    PageResponse<LastTrack> lastTrackHistoryContainer = (PageResponse<LastTrack>)lastFMSearchResult.Value;
                    List<LastTrack> lastFMFoundSongs = lastTrackHistoryContainer.Content.ToList();
                    // Map songs to activity
                    var tempDict = SongsToActivityMapper.MapSongsToActivity(activity, spotifyFoundSongs, lastFMFoundSongs);
                    tempDict.ToList().ForEach(x => activitiesAndSongs.Add(x.Key, x.Value));
                }

                if (item is Fitbit.Api.Portable.Models.Activities fitbitActivity)
                {
                    DateTimeOffset startDateAsDateTime = fitbitActivity.StartTime;
                    // Get Spotify songs
                    var spotifySearchResult = externalAPIGateway.GetSpotifyRecentlyPlayed(spotifyAuthToken.AccessToken, startDateAsDateTime);
                    CursorPaging<PlayHistoryItem> playHistoryContainer = (CursorPaging<PlayHistoryItem>)spotifySearchResult.Value;
                    List<PlayHistoryItem> spotifyFoundSongs = playHistoryContainer.Items.ToList();
                    // Get Last.FM songs
                    var lastFMSearchResult = externalAPIGateway.GetLastFMRecentlyPlayed(userName, fitbitActivity.StartTime);
                    PageResponse<LastTrack> lastTrackHistoryContainer = (PageResponse<LastTrack>)lastFMSearchResult.Value;
                    List<LastTrack> lastFMFoundSongs = lastTrackHistoryContainer.Content.ToList();
                    // Map songs to activity
                    var tempDict = SongsToActivityMapper.MapSongsToActivity(fitbitActivity, spotifyFoundSongs, lastFMFoundSongs);
                    tempDict.ToList().ForEach(x => activitiesAndSongs.Add(x.Key, x.Value));
                }
            }
        }

        /// <inheritdoc/>
        public void GetRecentlyPlayedMusicForActivitiesWithMultipleSources()
        {
            var tokenAsJson = externalAPIGateway.GetSpotifyAuthenticationToken();
            var spotifyAuthToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)tokenAsJson.Value);
            foreach (var item in searchResults)
            {
                if (item is StravaActivity activity)
                {
                    DateTimeOffset startDateAsDateTime = activity.start_date;

                    // Get Spotify songs
                    var spotifySearchResult = externalAPIGateway.GetSpotifyRecentlyPlayed(spotifyAuthToken.AccessToken, startDateAsDateTime);
                    CursorPaging<PlayHistoryItem> playHistoryContainer = (CursorPaging<PlayHistoryItem>)spotifySearchResult.Value;
                    List<PlayHistoryItem> spotifyFoundSongs = playHistoryContainer.Items.ToList();
                    // Get Last.FM songs
                    var lastFMSearchResult = externalAPIGateway.GetLastFMRecentlyPlayed(userName, startDateAsDateTime);
                    PageResponse<LastTrack> lastTrackHistoryContainer = (PageResponse<LastTrack>)lastFMSearchResult.Value;
                    List<LastTrack> lastFMFoundSongs = lastTrackHistoryContainer.Content.ToList();
                    // Map songs to activity
                    var tempDict = SongsToActivityMapper.MapSongsToActivity(activity, spotifyFoundSongs, lastFMFoundSongs);
                    tempDict.ToList().ForEach(x => activitiesAndSongs.Add(x.Key, x.Value));
                }

                if (item is Fitbit.Api.Portable.Models.Activities fitbitActivity)
                {
                    DateTimeOffset startDateAsDateTime = fitbitActivity.StartTime;
                    // Get Spotify songs
                    var spotifySearchResult = externalAPIGateway.GetSpotifyRecentlyPlayed(spotifyAuthToken.AccessToken, startDateAsDateTime);
                    CursorPaging<PlayHistoryItem> playHistoryContainer = (CursorPaging<PlayHistoryItem>)spotifySearchResult.Value;
                    List<PlayHistoryItem> spotifyFoundSongs = playHistoryContainer.Items.ToList();
                    // Get Last.FM songs
                    var lastFMSearchResult = externalAPIGateway.GetLastFMRecentlyPlayed(userName, fitbitActivity.StartTime);
                    PageResponse<LastTrack> lastTrackHistoryContainer = (PageResponse<LastTrack>)lastFMSearchResult.Value;
                    List<LastTrack> lastFMFoundSongs = lastTrackHistoryContainer.Content.ToList();
                    // Map songs to activity
                    var tempDict = SongsToActivityMapper.MapSongsToActivity(fitbitActivity, spotifyFoundSongs, lastFMFoundSongs);
                    tempDict.ToList().ForEach(x => activitiesAndSongs.Add(x.Key, x.Value));
                }
            }
        }

        /// <inheritdoc/>
        public List<object> GetFoundItems()
        {
            return searchResults;
        }

        /// <inheritdoc/>
        public void MakeRunningAndListeningHistoryComparison()
        {
            // Determine what date to search on...
            DateTime dateToSearchOn = new DateTime();
            if (activitiesAndSongs.Keys.First() is StravaActivity stravaActivity)
            {
                dateToSearchOn = stravaActivity.start_date;
            }
            else if (activitiesAndSongs.Keys.First() is Fitbit.Api.Portable.Models.Activities fitBitActivity)
            {
                dateToSearchOn = fitBitActivity.StartTime.DateTime;
            }

            Dictionary<object, List<object>> subsetMappedSongsToActivities = new Dictionary<object, List<object>>();

            foreach (var item in activitiesAndSongs.Keys)
            {
                if (item is StravaActivity stravaRun)
                {
                    if (stravaRun.start_date.Date == dateToSearchOn.Date)
                    {
                        subsetMappedSongsToActivities.Add(stravaRun, activitiesAndSongs[stravaRun]);
                    }
                }
                else if (item is Fitbit.Api.Portable.Models.Activities fitBitRun)
                {
                    if (fitBitRun.StartTime.DateTime.Date == dateToSearchOn.Date)
                    {
                        subsetMappedSongsToActivities.Add(fitBitRun, activitiesAndSongs[fitBitRun]);
                    }
                }
            }
            // Then make comparison
            var insightsManager = new InsightsManager();
            fastestActivityAndSongs = insightsManager.GetFastestActivityWithListeningHistory(subsetMappedSongsToActivities);
        }

        /// <inheritdoc/>
        public void MakeRunningAndListeningHistoryComparisonWithDateRange(DateTime startDate, DateTime endDate)
        {
            var subsetMappedSongsToActivities = new Dictionary<object, List<object>>();
            foreach (var item in activitiesAndSongs.Keys)
            {
                if (item is StravaActivity stravaRun)
                {
                    if (stravaRun.start_date.Date >= startDate.Date && stravaRun.start_date.Date <= endDate)
                    {
                        subsetMappedSongsToActivities.Add(stravaRun, activitiesAndSongs[stravaRun]);
                    }
                }
                else if (item is Fitbit.Api.Portable.Models.Activities fitBitRun)
                {
                    if (fitBitRun.StartTime.Date >= startDate.Date && fitBitRun.StartTime.Date <= endDate)
                    {
                        subsetMappedSongsToActivities.Add(fitBitRun, activitiesAndSongs[fitBitRun]);
                    }
                }
            }

            var insightsManager = new InsightsManager();
            fastestActivityAndSongs = insightsManager.GetFastestActivityWithListeningHistory(subsetMappedSongsToActivities);
        }

        /// <inheritdoc/>
        public Dictionary<object, List<object>> GetFastestTracks()
        {
            return fastestActivityAndSongs;
        }
    }
}
