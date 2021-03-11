namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
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
        /// <returns> Json of a valid Authentication Token</returns>
        Task<JsonResult> GetSpotifyAuthenticationToken();

        /// <summary>
        /// Gets the spotify recently played history.
        /// </summary>
        /// <param name="authToken">Authentication token to use.</param>
        /// <param name="after">Ticks to search after.</param>
        /// <returns> Json of recently played music. </returns>
        Task<JsonResult> GetSpotifyRecentlyPlayed(SpotifyAuthenticationToken authToken, long? after = null);

        /// <summary>
        /// Gets the Strava authentication token
        /// </summary>
        /// <returns> Json of a valid Authentication Token</returns>
        Task<JsonResult> GetStravaAuthenticationToken();

        /// <summary>
        /// Gets the Strava activity history
        /// </summary>
        /// <returns> Json of activity history </returns>
        Task<JsonResult> GetStravaActivityHistory(StravaAuthenticationToken authToken);
    }
}
