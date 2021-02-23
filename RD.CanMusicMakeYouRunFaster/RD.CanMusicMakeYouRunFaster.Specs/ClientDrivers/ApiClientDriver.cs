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
        private readonly List<Dictionary<string, string>> searchResults = new List<Dictionary<string, string>>();
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
