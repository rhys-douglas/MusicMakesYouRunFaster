namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Spotify
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class used to represent a SimpleArtist from the spotify API.
    /// This contains a subset of items used by the real SimpleArtist, as 
    /// not all properties are supported by EntityFrameworkCore.
    /// </summary>
    public class SimpleArtist
    {
        /// <summary>
        /// External URls
        /// </summary>
        [NotMapped]
        public Dictionary<string, string> ExternalUrls { get; set; } = default!;

        /// <summary>
        /// Href
        /// </summary>
        public string Href { get; set; } = default!;

        /// <summary>
        /// Id of the Artist
        /// </summary>
        [Key]
        public string Id { get; set; } = default!;

        /// <summary>
        /// Name of the artist
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Type of the artist
        /// </summary>
        public string Type { get; set; } = default!;

        /// <summary>
        /// Artist URI.
        /// </summary>
        public string Uri { get; set; } = default!;
    }
}
