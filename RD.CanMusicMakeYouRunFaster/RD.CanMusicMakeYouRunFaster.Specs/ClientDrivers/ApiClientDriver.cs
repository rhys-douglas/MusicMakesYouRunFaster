namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using RD.CanMusicMakeYouRunFaster.Rest.Controllers;

    /// <summary>
    /// Client driver for testing without a front-end.
    /// </summary>
    public class ApiClientDriver : IClientDriver
    {
        private ExternalAPIController externalAPIController;

        public void SetUp()
        {
            externalAPIController = new ExternalAPIController();
        }

        /// <inheritdoc/>
        public void GetRecentlyPlayedMusic()
        {
            // Get Oauth token and authenticate.
            externalAPIController.GetSpotifyOAuthToken();
            //// backendManager.spotify.getOAuthToken();

            // then request recently played music.
            ////externalAPIController.GetSpotifyRecentlyPlayed();
            // backendManager.spotify.getRecentlyPlayedMusic();
        }
    }
}
