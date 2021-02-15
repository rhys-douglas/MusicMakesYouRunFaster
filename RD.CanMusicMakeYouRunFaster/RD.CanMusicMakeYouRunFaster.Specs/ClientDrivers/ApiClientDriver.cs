namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Rest.Controllers;

    /// <summary>
    /// Client driver for testing without a front-end.
    /// </summary>
    public class ApiClientDriver : IClientDriver
    {
        private readonly List<string> queryResults = new List<string>();
        private ExternalAPIController externalAPIController;

        /// <inheritdoc/>
        public void SetUp()
        {
            externalAPIController = new ExternalAPIController();
        }

        /// <inheritdoc/>
        public void GetRecentlyPlayedMusic()
        {
            externalAPIController.GetSpotifyAuthenticationToken();
            var searchResult = externalAPIController.GetSpotifyRecentlyPlayed();
            var playHistoryContainer = (SpotifyAPI.Web.CursorPaging<SpotifyAPI.Web.PlayHistoryItem>)searchResult.Value;
            foreach (var song in playHistoryContainer.Items)
            {
                queryResults.Add(song.Track.Name);
            }
        }
    }
}
