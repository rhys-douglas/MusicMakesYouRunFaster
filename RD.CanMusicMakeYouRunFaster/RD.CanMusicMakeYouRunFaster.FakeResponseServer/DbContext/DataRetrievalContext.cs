namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.FitBit;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.LastFM;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Spotify;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Strava;

    /// <summary>
    /// Database context for storing the session's data set
    /// </summary>
    public class DataRetrievalContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRetrievalContext"/> class
        /// </summary>
        /// <param name="options">DB Context Options </param>
        public DataRetrievalContext(DbContextOptions<DataRetrievalContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Overrides the OnConfiguring method.
        /// </summary>
        /// <param name="optionsBuilder">Options builder input</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies();

        /// <summary>
        /// Gets or sets the PlayHistoryItems data set
        /// </summary>
        public DbSet<PlayHistoryItem> PlayHistoryItems { get; set; }

        /// <summary>
        /// Gets or sets the ActivityHistoryItems data set.
        /// </summary>
        public DbSet<Activity> ActivityHistoryItems { get; set; }

        /// <summary>
        /// Gets or sets the FitBitActivityItems data set.
        /// </summary>
        public DbSet<Activities> FitBitActivityItems { get; set; }

        /// <summary>
        /// Gets or sets the LastFM LastTracks data set.
        /// </summary>
        public DbSet<LastTrack> LastTracks { get; set; }
    }
}
