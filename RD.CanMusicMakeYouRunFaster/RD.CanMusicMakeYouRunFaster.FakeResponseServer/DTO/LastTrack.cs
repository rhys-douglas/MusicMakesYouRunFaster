namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Last track DTO, used for holding track information from Last.FM
    /// </summary>
    public class LastTrack
    {
        /// <summary>
        /// Track Id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the song.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Duration of the song.
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public long? Duration { get; set; }

        /// <summary>
        /// Mbid.
        /// </summary>
        [JsonProperty(PropertyName = "mbid")]
        public string Mbid { get; set; }

        /// <summary>
        /// ArtistName.
        /// </summary>
        [JsonProperty(PropertyName = "artistName")]
        public string ArtistName { get; set; }

        /// <summary>
        /// ArtistMBid
        /// </summary>
        [JsonProperty(PropertyName = "artistMbid")]
        public string ArtistMbid { get; set; }

        /// <summary>
        /// Artist Images
        /// </summary>
        [JsonProperty(PropertyName = "artistImages")]
        public LastImageSet ArtistImages { get; set; }

        /// <summary>
        /// Artist Url.
        /// </summary>
        [JsonProperty(PropertyName = "artistUrl")]
        public Uri ArtistUrl { get; set; }

        /// <summary>
        /// Url of the track.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Images of the track.
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public LastImageSet Images { get; set; }

        /// <summary>
        /// Album name of the track's album.
        /// </summary>
        [JsonProperty(PropertyName = "albumName")]
        public string AlbumName { get; set; }

        /// <summary>
        /// Number of listeners of the track.
        /// </summary>
        [JsonProperty(PropertyName = "listenerCount")]
        public int? ListenerCount { get; set; }

        /// <summary>
        /// Number of times the track has been played.
        /// </summary>
        [JsonProperty(PropertyName = "playCount")]
        public int? PlayCount { get; set; }

        /// <summary>
        /// Number of times the user has played the track.
        /// </summary>
        [JsonProperty(PropertyName = "userPlayCount")]
        public int? UserPlayCount { get; set; }

        /// <summary>
        /// Tags of the track.
        /// </summary>
        public IEnumerable<LastTag> TopTags { get; set; }

        /// <summary>
        /// Time track was played.
        /// </summary>
        public DateTimeOffset? TimePlayed { get; set; }

        /// <summary>
        /// Is the track loved by the user?
        /// </summary>
        public bool? IsLoved { get; set; }

        /// <summary>
        /// Is the track now playing?
        /// </summary>
        public bool? IsNowPlaying { get; set; }

        /// <summary>
        /// Ranking of the track.
        /// </summary>
        public int? Rank { get; set; }
    }
}
