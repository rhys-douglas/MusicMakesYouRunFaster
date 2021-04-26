namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using System;
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
        /// Tears down the client driver.
        /// </summary>
        void TearDown();

        /// <summary>
        /// Registers a username.
        /// </summary>
        /// <param name="user">username to register</param>
        void RegisterUser(string user);

        /// <summary>
        /// Request music data from the Spotify API.
        /// </summary>
        void GetSpotifyRecentlyPlayedMusic();

        /// <summary>
        /// Request music data from the LastFM API.
        /// </summary>
        void GetLastFMRecentlyPlayedMusic();

        /// <summary>
        /// Request activity data from the Strava API.
        /// </summary>
        void GetRecentStravaActivities();

        /// <summary>
        /// Request activity data from the FitBit API.
        /// </summary>
        void GetRecentFitBitActivities();

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
        Dictionary<object, List<object>> GetFastestTracks();

        /// <summary>
        /// Makes the comparison between running and listening history using a range to search between.
        /// </summary>
        /// <param name="startDate">Start date to search from (inclusive)</param>
        /// <param name="endDate">End date to search to (inclusive)</param>
        void MakeRunningAndListeningHistoryComparisonWithDateRange(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Request music data from the relevant API, specifically for mapping to activities.
        /// </summary>
        void GetRecentlyPlayedMusicForActivities();

        /// <summary>
        /// Request music data from the relevant APIs, specifically for mapping to activities.
        /// </summary>
        void GetRecentlyPlayedMusicForActivitiesWithMultipleSources();
    }
}
