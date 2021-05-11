namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
    using System;
    using System.Threading.Tasks;
    using Entity;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Interface for data retrieval sources
    /// </summary>
    public interface IDataRetrievalSource
    {
        /// <summary>
        /// Gets the Spotify authentication token
        /// </summary>
        /// <returns> Json of a valid authentication token. </returns>
        Task<JsonResult> GetSpotifyAuthenticationToken();

        /// <summary>
        /// Gets the spotify recently played history.
        /// </summary>
        /// <param name="authToken">Authentication token to use.</param>
        /// <param name="after">UNIX ms to search after.</param>
        /// <returns> Json of recently played music. </returns>
        Task<JsonResult> GetSpotifyRecentlyPlayed(SpotifyAuthenticationToken authToken, long? after = null, long? activityDuration = null);

        /// <summary>
        /// Gets a list of LastFM recently played songs.
        /// </summary>
        /// <param name="username"> Username to search for.</param>
        /// <returns> A list of songs</returns>
        Task<JsonResult> GetLastFMRecentlyPlayed(string username, DateTimeOffset? after=null);

        /// <summary>
        /// Gets the Strava authentication token
        /// </summary>
        /// <returns> Json of a valid authentication token. </returns>
        Task<JsonResult> GetStravaAuthenticationToken();

        /// <summary>
        /// Gets a list of Strava Activities
        /// </summary>
        /// <param name="authToken">Auth token to use to get activities</param>
        /// <returns> A list of Strava activities in JSON format.</returns>
        Task<JsonResult> GetStravaActivityHistory(StravaAuthenticationToken authToken);

        /// <summary>
        /// Gets a FitBit authentication token
        /// </summary>
        /// <returns> Json of a valid authentication token. </returns>
        Task<JsonResult> GetFitBitAuthenticationToken();

        /// <summary>
        /// Gets a list of FitBit activities
        /// </summary>
        /// <param name="authToken"> Auth token to use to get activities </param>
        /// <returns> A list of FitBit activities in JSON format.</returns>
        Task<JsonResult> GetFitBitActivityHistory(FitBitAuthenticationToken authToken);
    }
}
