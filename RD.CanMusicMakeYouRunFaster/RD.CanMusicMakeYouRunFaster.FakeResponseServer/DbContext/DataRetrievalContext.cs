namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Newtonsoft.Json;
    using SpotifyAPI.Web;
    using System.Collections.Generic;

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
        /// Overrides the model creating, allowing external urls to be ignored.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<PlayHistoryItem>()
                .HasOne(x => x.Context);

            modelBuilder.Entity<PlayHistoryItem>()
                .HasOne(x => x.Track);

            modelBuilder.Entity<SimpleTrack>(b =>
                {
                    b.Property(u => u.ExternalUrls)
                    .HasConversion(
                        d => JsonConvert.SerializeObject(d, Formatting.None),
                        s => JsonConvert.DeserializeObject<Dictionary<string, string>>(s));
                    b.Property(u => u.AvailableMarkets)
                    .HasConversion(
                        d => JsonConvert.SerializeObject(d, Formatting.None),
                        s => JsonConvert.DeserializeObject<List<string>>(s));
            });

            modelBuilder.Entity<Context>(b =>
            {
                b.Property(u => u.ExternalUrls)
                .HasConversion(
                    d => JsonConvert.SerializeObject(d, Formatting.None),
                    s => JsonConvert.DeserializeObject<Dictionary<string, string>>(s));
                b.HasKey(x => x.Uri);
            });

            modelBuilder.Entity<LinkedTrack>(b =>
            {
                b.Property(u => u.ExternalUrls)
                .HasConversion(
                    d => JsonConvert.SerializeObject(d, Formatting.None),
                    s => JsonConvert.DeserializeObject<Dictionary<string, string>>(s));
            });

            modelBuilder.Entity<SimpleArtist>(b =>
            {
                b.Property(u => u.ExternalUrls)
                .HasConversion(
                    d => JsonConvert.SerializeObject(d, Formatting.None),
                    s => JsonConvert.DeserializeObject<Dictionary<string, string>>(s));
            });

            modelBuilder.Ignore("PlayHistoryItem.Context");
            */
        }

        /// <summary>
        /// Gets or sets the Stock Locations Data Set
        /// </summary>
        public DbSet<PlayHistoryItem> PlayHistoryItems { get; set; }
    }
}
