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

        public void SetUp()
        {
            externalAPIController = new ExternalAPIController();
        }

        /// <inheritdoc/>
        public void GetRecentlyPlayedMusic()
        {
            externalAPIController.GetSpotifyAuthenticationToken();
            var searchResult = externalAPIController.GetSpotifyRecentlyPlayed();
            var resultAsJson = JsonConvert.SerializeObject(searchResult);
            var actualSearchResult = JsonConvert.DeserializeObject<string>(resultAsJson);
            ////queryResults.AddRange(actualSearchResult);
        }
    }
}
