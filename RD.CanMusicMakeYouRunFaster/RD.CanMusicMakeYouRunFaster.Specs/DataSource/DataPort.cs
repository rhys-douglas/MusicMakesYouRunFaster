namespace RD.CanMusicMakeYouRunFaster.Specs.DataSource
{
    using System.Net.Http;
    using System.Collections.Generic;
    using FakeResponseServer.DbContext;
    using Microsoft.EntityFrameworkCore;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models;
    using RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;

    /// <summary>
    /// FakeDataSource class. Acts as an area to store fake data for testing, to prove integration.
    /// </summary>
    public class DataPort
    {
        private readonly DbContextOptions<DataRetrievalContext> contextOptions;

        public ExternalAPIGateway externalAPIGateway = new ExternalAPIGateway(new FakeDataRetrievalSource(new SpotifyClient(new HttpClient(),""), ""));

        /// <summary>
        /// Initializes a new instance of the <see cref="DataPort"/> class.
        /// </summary>
        /// <param name="contextOptions">Fake backend database context options. </param>
        public DataPort(DbContextOptions<DataRetrievalContext> contextOptions)
        {
            this.contextOptions = contextOptions;
        }

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
    }
}
