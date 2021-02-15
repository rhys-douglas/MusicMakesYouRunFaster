namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using System.Collections.Generic;
    using Rest.Controllers;

    /// <summary>
    /// Client driver for testing without a front-end.
    /// </summary>
    public class ApiClientDriver : IClientDriver
    {
        private readonly List<Dictionary<string, string>> searchResults = new List<Dictionary<string, string>>();
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
                var listeningHistoryItem = new Dictionary<string, string>
                {
                    { song.Track.Name.ToString(), song.PlayedAt.ToString("dd'/'MM'/'yyyy HH:mm:ss") }
                };
                searchResults.Add(listeningHistoryItem);
            }
        }

        /// <inheritdoc/>
        public List<Dictionary<string, string>> GetFoundItems()
        {
            return searchResults;
        }
    }
}
