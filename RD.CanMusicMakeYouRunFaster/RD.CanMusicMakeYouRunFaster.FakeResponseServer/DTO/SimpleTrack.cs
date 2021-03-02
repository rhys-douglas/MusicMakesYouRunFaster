namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Simple track DTO.
    /// </summary>
    public class SimpleTrack
    {
        /// <summary>
        /// List of Artists
        /// </summary>
        public List<SimpleArtist> Artists { get; set; } = default!;

        /// <summary>
        /// List of available markets.
        /// </summary>
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
        public Dictionary<string, string> ExternalUrls { get; set; } = default!;

        /// <summary>
        /// Href of the track
        /// </summary>
        public string Href { get; set; } = default!;

        /// <summary>
        /// Track ID
        /// </summary>
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
        public Models.Spotify.ItemType Type { get; set; }

        /// <summary>
        /// Track URI.
        /// </summary>
        public string Uri { get; set; } = default!;
    }
}
