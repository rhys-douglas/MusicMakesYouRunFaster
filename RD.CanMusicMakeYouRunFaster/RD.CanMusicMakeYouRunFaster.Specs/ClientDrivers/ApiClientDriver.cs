namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    /// <summary>
    /// Client driver for testing without a front-end.
    /// </summary>
    public class ApiClientDriver : IClientDriver
    {
        /// <inheritdoc/>
        public void GetRecentlyPlayedMusic()
        {
            // Get Oauth token and authenticate.
            // backendManager.spotify.getOAuthToken();

            // then request recently played music.
            // backendManager.spotify.getRecentlyPlayedMusic();
        }
    }
}
