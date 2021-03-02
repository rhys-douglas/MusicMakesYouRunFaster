namespace RD.CanMusicMakeYouRunFaster.Specs.DataSource
{
    using System.Collections.Generic;
    using FakeResponseServer.DbContext;
    using Microsoft.EntityFrameworkCore;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Spotify;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Strava;
    using RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;

    /// <summary>
    /// FakeDataSource class. Acts as an area to store fake data for testing, to prove integration.
    /// </summary>
    public class DataPort
    {
        private readonly DbContextOptions<DataRetrievalContext> contextOptions;
        private ExternalAPICaller externalAPICaller { get; } 

        /// <summary>
        /// Initializes a new instance of the <see cref="DataPort"/> class.
        /// </summary>
        /// <param name="contextOptions">Fake backend database context options. </param>
        /// <param name="spotifyClient">Fake spotify client to make API calls with. </param>
        public DataPort(DbContextOptions<DataRetrievalContext> contextOptions, ExternalAPICaller externalAPICaller)
        {
            this.contextOptions = contextOptions;
            this.externalAPICaller = externalAPICaller;
        }

        public ExternalAPIGateway ExternalAPIGateway => new ExternalAPIGateway(
            new FakeDataRetrievalSource(
                externalAPICaller, 
                "http://localhost:2222"));

        /// <summary>
        /// Adds listening history from feature files to the backend.
        /// </summary>
        /// <param name="listOfListeningHistory"> Listening history to add. </param>
        public void AddListeningHistory(List<PlayHistoryItem> listOfListeningHistory)
        {
            using var context = new DataRetrievalContext(contextOptions);
            context.PlayHistoryItems.RemoveRange(context.PlayHistoryItems);
            context.PlayHistoryItems.AddRange(listOfListeningHistory);
            context.SaveChanges();
        }

        public void AddRunningHistory(List<Activity> listOfRunningHistory)
        {
            using var context = new DataRetrievalContext(contextOptions);
            context.ActivityHistoryItems.RemoveRange(context.ActivityHistoryItems);
            context.ActivityHistoryItems.AddRange(listOfRunningHistory);
            context.SaveChanges();
        }
    }
}
