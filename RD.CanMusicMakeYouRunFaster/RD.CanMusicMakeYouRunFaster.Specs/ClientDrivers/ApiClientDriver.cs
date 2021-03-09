namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using System.Collections.Generic;
    using System.Linq;
    using SpotifyAPI.Web;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;
    using RD.CanMusicMakeYouRunFaster.ComparisonLogic.Mappers;
    using RD.CanMusicMakeYouRunFaster.ComparisonLogic.Managers;

    /// <summary>
    /// Client driver for testing without a front-end.
    /// </summary>
    public class ApiClientDriver : IClientDriver
    {
        private readonly List<object> searchResults = new List<object>();
        private Dictionary<Rest.Entity.Activity, List<PlayHistoryItem>> activitiesAndSongs = new Dictionary<Rest.Entity.Activity, List<PlayHistoryItem>>();
        private Dictionary<Rest.Entity.Activity, List<PlayHistoryItem>> fastestActivity = new Dictionary<Rest.Entity.Activity, List<PlayHistoryItem>>();
        private ExternalAPIGateway externalAPIGateway;

        /// <inheritdoc/>
        public void SetUp(ExternalAPIGateway externalAPIGateway)
        {
            this.externalAPIGateway = externalAPIGateway;
        }

        /// <inheritdoc/>
        public void GetRecentlyPlayedMusic()
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
        public void GetRecentlyPlayedMusicForActivities()
        {
            externalAPIGateway.GetSpotifyAuthenticationToken();
            var activitiesAndSongs = new Dictionary<Rest.Entity.Activity, List<PlayHistoryItem>>();
            foreach (var item in searchResults)
            {
                if (item is Rest.Entity.Activity activity)
                {
                    var searchResult = externalAPIGateway.GetSpotifyRecentlyPlayed(activity.start_date.Ticks);
                    var playHistoryContainer = (CursorPaging<PlayHistoryItem>)searchResult.Value;
                    var listOfSongs = playHistoryContainer.Items.ToList();
                    activitiesAndSongs.Add(activity, listOfSongs);
                }
            }
        }

        /// <inheritdoc/>
        public void GetRecentActivities()
        {
            externalAPIGateway.GetStravaAuthenticationToken();
            var searchresult = externalAPIGateway.GetStravaRecentActivities();
            var activityHistoryContainer = (List<Rest.Entity.Activity>)searchresult.Value;
            foreach (var activity in activityHistoryContainer)
            {
                searchResults.Add(activity);
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
            var runningHistory = new List<Rest.Entity.Activity>();
            var listeningHistory = new List<PlayHistoryItem>();
            foreach (var item in searchResults)
            {
                if (item is Rest.Entity.Activity activity)
                {
                    runningHistory.Add(activity);
                }

                if (item is PlayHistoryItem playHistoryItem)
                {
                    listeningHistory.Add(playHistoryItem);
                }
            }

            var mappedSongsToActivities = new Dictionary<Rest.Entity.Activity, List<PlayHistoryItem>>();

            foreach (var run in runningHistory)
            {
                var tempDict = SongsToActivityMapper.MapSongsToActivity(run, listeningHistory);
                tempDict.ToList().ForEach(x => mappedSongsToActivities.Add(x.Key, x.Value));
            }

            // Determine what date to search on...
            var dateToSearchOn = runningHistory[0].start_date;
            var subsetMappedSongsToActivities = mappedSongsToActivities.Where(s => s.Key.start_date.Date == dateToSearchOn)
                .ToDictionary(dict => dict.Key, dict => dict.Value);

            // Then make comparison
            var insightsManager = new InsightsManager();
            fastestActivity = insightsManager.GetFastestActivityWithListeningHistory(subsetMappedSongsToActivities);
        }

        /// <inheritdoc/>
        public Dictionary<Rest.Entity.Activity, List<PlayHistoryItem>> GetFastestTracks()
        {
            return fastestActivity;
        }
    }
}
