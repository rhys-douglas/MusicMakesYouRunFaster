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
            //             base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SimpleTrack>(b =>
                {
                    b.Property(u => u.ExternalUrls)
                    .HasConversion(
                        d => JsonConvert.SerializeObject(d, Formatting.None),
                        s => JsonConvert.DeserializeObject<Dictionary<string, string>>(s));
            });
            
            /*
            modelBuilder.Entity<PlayHistoryItem>(b =>
            {
                b.Property(u => u.Track)
                .HasConversion<string>();
                });
            */

            /*
            modelBuilder.Entity<SimpleTrack>().Ignore(e => e.ExternalUrls);
            modelBuilder.Entity<PlayHistoryItem>().Ignore(t => t.Track);
            modelBuilder.Ignore("ExternalUrls");
            modelBuilder.Ignore("Context.ExternalUrls");
            modelBuilder.Entity<SimpleTrack>()
                .Property(e => e.ExternalUrls)
                .HasConversion(
                e => JsonConvert.SerializeObject(e),
                e => JsonConvert.DeserializeObject<Dictionary<string, string>>(e));
            base.OnModelCreating(modelBuilder);
            */
        }

        /// <summary>
        /// Gets or sets the Stock Locations Data Set
        /// </summary>
        public DbSet<PlayHistoryItem> PlayHistoryItems { get; set; }
    }
}
