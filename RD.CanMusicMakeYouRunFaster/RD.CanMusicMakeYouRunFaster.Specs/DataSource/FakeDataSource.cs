namespace RD.CanMusicMakeYouRunFaster.Specs.DataSource
{
    using System.Collections.Generic;
    using FakeResponseServer.DbContext;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// FakeDataSource class. Acts as an area to store fake data for testing, to prove integration.
    /// </summary>
    public class FakeDataSource
    {
        private readonly DbContextOptions<DataRetrievalContext> contextOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDataSource"/> class.
        /// </summary>
        /// <param name="contextOptions">Fake backend database context options. </param>
        public FakeDataSource(DbContextOptions<DataRetrievalContext> contextOptions)
        {
            this.contextOptions = contextOptions;
        }
        #region Component Designer generated code
        /// <summary>
        /// Adds listening history from feature files to the backend.
        /// </summary>
        /// <param name="listOfListeningHistory"> Listening history to add. </param>
        public void AddListeningHistory(List<SpotifyAPI.Web.PlayHistoryItem> listOfListeningHistory)
        {
            using var context = new DataRetrievalContext(contextOptions);
            context.PlayHistoryItems.RemoveRange(context.PlayHistoryItems);
            context.PlayHistoryItems.AddRange(listOfListeningHistory);
            context.SaveChanges();
        }
        #endregion
    }
}
