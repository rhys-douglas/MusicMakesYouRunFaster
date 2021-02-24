namespace RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers
{
    using System.Collections.Generic;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;

    /// <summary>
    /// Interface for client drivers.
    /// </summary>
    public interface IClientDriver
    {
        /// <summary>
        /// Set up client driver.
        /// </summary>
        void SetUp(ExternalAPIGateway externalApiGateway);

        /// <summary>
        /// Request music data from the relevant API.
        /// </summary>
        void GetRecentlyPlayedMusic();

        /// <summary>
        /// Request activity data from the relevant API.
        /// </summary>
        void GetRecentActivities();

        /// <summary>
        /// Returns a list of items found from previous queries.
        /// </summary>
        /// <returns> A list of found items. </returns>
        List<object> GetFoundItems();
    }
}
