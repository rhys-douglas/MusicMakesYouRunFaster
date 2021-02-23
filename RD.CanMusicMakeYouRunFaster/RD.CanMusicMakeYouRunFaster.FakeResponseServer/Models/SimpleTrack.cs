namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Class used to represent a SimpleTrack from the spotify API.
    /// This contains a subset of items used by the real SimpleTrack, as 
    /// not all properties are supported by EntityFrameworkCore.
    /// </summary>
    public class SimpleTrack
    {
        /// <summary>
        /// List of Artists on the track.
        /// </summary>
        [NotMapped]
        public List<SimpleArtist> Artists { get; set; } = default!;

        /// <summary>
        /// List of available markets.
        /// </summary>
        [NotMapped]
        public List<string> AvailableMarkets { get; set; } = default!;

        /// <summary>
        /// Disc number that the track features on.
        /// </summary>
        public int DiscNumber { get; set; }

        /// <summary>
        /// Duration of the track in Ms
        /// </summary>
        public int DurationMs { get; set; }

        /// <summary>
        /// Explicit rating of track.
        /// </summary>
        public bool Explicit { get; set; }

        /// <summary>
        /// External URls
        /// </summary>
        [NotMapped]
        public Dictionary<string, string> ExternalUrls { get; set; } = default!;

        /// <summary>
        /// Href of the track
        /// </summary>
        public string Href { get; set; } = default!;

        /// <summary>
        /// Track ID
        /// </summary>
        [Key]
        public string Id { get; set; } = default!;

        /// <summary>
        /// Track playability.
        /// </summary>
        public bool IsPlayable { get; set; }

        /// <summary>
        /// Track from which the track was linked from
        /// </summary>
        public virtual LinkedTrack LinkedFrom { get; set; } = default!;

        /// <summary>
        /// Name of the track
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Preview URL of the track.
        /// </summary>
        public string PreviewUrl { get; set; } = default!;

        /// <summary>
        /// Track number.
        /// </summary>
        public int TrackNumber { get; set; }

        /// <summary>
        /// Type of the Track.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType Type { get; set; }
        
        /// <summary>
        /// Track URI.
        /// </summary>
        public string Uri { get; set; } = default!;
    }
}
