namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for client drivers.
    /// </summary>
    public interface IClientDriver
    {
        /// <summary>
        /// Request data from the relevant API.
        /// </summary>
        void GetRecentlyPlayedMusic();

        /// <summary>
        /// Set up client driver.
        /// </summary>
        void SetUp();

        /// <summary>
        /// Returns a list of items found from previous queries.
        /// </summary>
        /// <returns> A list of found items. </returns>
        List<Dictionary<string, string>> GetFoundItems();
    }
}
