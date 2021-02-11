namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    public interface IClientDriver
    {
        /// <summary>
        /// Request data from the relevant API.
        /// </summary>
        void GetRecentlyPlayedMusic();

        /// <summary>
        /// Set up client driver
        /// </summary>
        void SetUp();
    }
}
