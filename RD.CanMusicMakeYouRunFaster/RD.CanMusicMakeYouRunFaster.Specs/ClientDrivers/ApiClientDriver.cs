namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
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

    /// <summary>
    /// Client driver for testing without a front-end.
    /// </summary>
    public class ApiClientDriver : IClientDriver
    {
        private readonly List<object> searchResults = new List<object>();
        private readonly Dictionary<object, List<object>> activitiesAndSongs = new Dictionary<object, List<object>>();
        private Dictionary<Rest.Entity.StravaActivity, List<PlayHistoryItem>> fastestActivity = new Dictionary<Rest.Entity.StravaActivity, List<PlayHistoryItem>>();
        private ExternalAPIGateway externalAPIGateway;
        private string userName;

        /// <inheritdoc/>
        public void SetUp(ExternalAPIGateway externalAPIGateway)
        {
            this.externalAPIGateway = externalAPIGateway;
        }

        /// <inheritdoc/>
        public void RegisterUser(string user)
        {
            userName = user;
        }


        /// <inheritdoc/>
        public void GetSpotifyRecentlyPlayedMusic()
        {
            externalAPIGateway.GetSpotifyAuthenticationToken();
            var searchResult = externalAPIGateway.GetSpotifyRecentlyPlayed();
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
            externalAPIGateway.GetStravaAuthenticationToken();
            var searchresult = externalAPIGateway.GetStravaRecentActivities();
            var activityHistoryContainer = (List<Rest.Entity.StravaActivity>)searchresult.Value;
            foreach (var activity in activityHistoryContainer)
            {
                searchResults.Add(activity);
            }
        }

        /// <inheritdoc/>
        public void GetRecentFitBitActivities()
        {
            externalAPIGateway.GetFitBitAuthenticationToken();
            var searchResult = externalAPIGateway.GetFitBitRecentActivities();
            var activityHistoryContainer = (Fitbit.Api.Portable.Models.ActivityLogsList)searchResult.Value;
            foreach (var activity in activityHistoryContainer.Activities)
            {
                searchResults.Add(activity);
            }
        }

        /// <inheritdoc/>
        public void GetRecentlyPlayedMusicForActivities()
        {
            externalAPIGateway.GetSpotifyAuthenticationToken();
            foreach (var item in searchResults)
            {
                if (item is Rest.Entity.StravaActivity activity)
                {
                    var startDateAsDateTime = activity.start_date;
                    var startDateAsUnixTime = ((DateTimeOffset)startDateAsDateTime).ToUnixTimeMilliseconds();

                    // Get Spotify songs
                    var spotifySearchResult = externalAPIGateway.GetSpotifyRecentlyPlayed(startDateAsUnixTime);
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
                    long startDateAsUnixTime = fitbitActivity.OriginalStartTime.ToUnixTimeMilliseconds();
                    // Get Spotify songs
                    var spotifySearchResult = externalAPIGateway.GetSpotifyRecentlyPlayed(startDateAsUnixTime);
                    CursorPaging<PlayHistoryItem> playHistoryContainer = (CursorPaging<PlayHistoryItem>)spotifySearchResult.Value;
                    List<PlayHistoryItem> spotifyFoundSongs = playHistoryContainer.Items.ToList();
                    // Get Last.FM songs
                    var lastFMSearchResult = externalAPIGateway.GetLastFMRecentlyPlayed(userName, fitbitActivity.OriginalStartTime);
                    PageResponse<LastTrack> lastTrackHistoryContainer = (PageResponse<LastTrack>)lastFMSearchResult.Value;
                    List<LastTrack> lastFMFoundSongs = lastTrackHistoryContainer.Content.ToList();
                    // Map songs to activity
                    var tempDict = SongsToActivityMapper.MapSongsToActivity(activity, spotifyFoundSongs, lastFMFoundSongs);
                    tempDict.ToList().ForEach(x => activitiesAndSongs.Add(x.Key, x.Value));
                }
            }
        }

        /// <inheritdoc/>
        public void GetRecentlyPlayedMusicForActivitiesWithMultipleSources()
        {
            externalAPIGateway.GetSpotifyAuthenticationToken();
            foreach (var item in searchResults)
            {
                if (item is Rest.Entity.StravaActivity activity)
                {
                    var startDateAsDateTime = activity.start_date;
                    var startDateAsUnixTime = ((DateTimeOffset)startDateAsDateTime).ToUnixTimeMilliseconds();
                    var searchResult = externalAPIGateway.GetSpotifyRecentlyPlayed(startDateAsUnixTime);
                    var playHistoryContainer = (CursorPaging<PlayHistoryItem>)searchResult.Value;
                    var listOfSongs = playHistoryContainer.Items.ToList();
                    var tempDict = SongsToActivityMapper.MapSongsToActivity(activity, listOfSongs);
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
            var dateToSearchOn = activitiesAndSongs.Keys.First().start_date;
            var subsetMappedSongsToActivities = activitiesAndSongs.Where(s => s.Key.start_date.Date == dateToSearchOn.Date)
                .ToDictionary(dict => dict.Key, dict => dict.Value);

            // Then make comparison
            var insightsManager = new InsightsManager();
            fastestActivity = insightsManager.GetFastestActivityWithListeningHistory(subsetMappedSongsToActivities);
        }

        /// <inheritdoc/>
        public void MakeRunningAndListeningHistoryComparisonWithDateRange(DateTime startDate, DateTime endDate)
        {
            var subsetMappedSongsToActivities = activitiesAndSongs.Where(s => s.Key.start_date.Date >= startDate.Date && s.Key.start_date.Date <= endDate )
                .ToDictionary(dict => dict.Key, dict => dict.Value);
            var insightsManager = new InsightsManager();
            fastestActivity = insightsManager.GetFastestActivityWithListeningHistory(subsetMappedSongsToActivities);
        }

        /// <inheritdoc/>
        public Dictionary<Rest.Entity.StravaActivity, List<PlayHistoryItem>> GetFastestTracks()
        {
            return fastestActivity;
        }
    }
}
