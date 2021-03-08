namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using System.Collections.Generic;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;
    using SpotifyAPI.Web;

    /// <summary>
    /// Interface for client drivers.
    /// </summary>
    public interface IClientDriver
    {
        /// <summary>
        /// Set up client driver.
        /// </summary>
        void SetUp(ExternalAPIGateway externalApiGateway);

        /// <summary>
        /// Request music data from the relevant API.
        /// </summary>
        void GetRecentlyPlayedMusic();

        /// <summary>
        /// Request activity data from the relevant API.
        /// </summary>
        void GetRecentActivities();

        /// <summary>
        /// Returns a list of items found from previous queries.
        /// </summary>
        /// <returns> A list of found items. </returns>
        List<object> GetFoundItems();

        /// <summary>
        /// Makes the comparison between running and listening history.
        /// </summary>
        void MakeRunningAndListeningHistoryComparison();

        /// <summary>
        /// Returns the dictionary of fastest tracks, and the paired activity.
        /// </summary>
        /// <returns>A dictionary with songs that make you run faster.</returns>
        Dictionary<Rest.Entity.Activity, List<PlayHistoryItem>> GetFastestTracks();
    }
}
