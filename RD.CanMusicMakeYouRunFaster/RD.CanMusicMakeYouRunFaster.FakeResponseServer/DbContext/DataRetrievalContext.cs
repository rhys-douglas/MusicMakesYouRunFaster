namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using SpotifyAPI.Web;

    /// <summary>
    /// Context for storing the session's fake data set.
    /// </summary>
    public class DataRetrievalContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRetrievalContext"/> class
        /// </summary>
        /// <param name="options">Database context options.</param>
        public DataRetrievalContext(DbContextOptions<DataRetrievalContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the PlayHistory data set.
        /// </summary>
        public DbSet<PlayHistoryItem> PlayHistoryItems { get; set; }
    }
}
