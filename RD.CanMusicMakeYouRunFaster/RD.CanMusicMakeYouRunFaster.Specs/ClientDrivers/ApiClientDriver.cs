namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using System.Collections.Generic;
    using SpotifyAPI.Web;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;

    /// <summary>
    /// Client driver for testing without a front-end.
    /// </summary>
    public class ApiClientDriver : IClientDriver
    {
        private readonly List<object> searchResults = new List<object>();
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
    }
}
