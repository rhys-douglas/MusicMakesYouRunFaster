namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;
    using SpotifyAPI.Web;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Android client driver, used for running SpecFlow BDD tests against the Android App.
    /// </summary>
    public class AndroidClientDriver : IClientDriver
    {
        private ExternalAPIGateway externalAPIGateway;

        /// <inheritdoc/>
        public void SetUp(ExternalAPIGateway externalApiGateway)
        {
            this.externalAPIGateway = externalApiGateway;
            
            // Set up app?

        }

        /// <inheritdoc/>
        public Dictionary<Activity, List<PlayHistoryItem>> GetFastestTracks()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public List<object> GetFoundItems()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void GetRecentActivities()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void GetRecentlyPlayedMusic()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void GetRecentlyPlayedMusicForActivities()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void MakeRunningAndListeningHistoryComparison()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void MakeRunningAndListeningHistoryComparisonWithDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
