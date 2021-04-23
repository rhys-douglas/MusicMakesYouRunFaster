namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.LastFM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// Last track DTO, used for holding track information from Last.FM
    /// </summary>
    public class LastTrack
    {
        /// <summary>
        /// Track Id.
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Name of the song.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Duration of the song.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Mbid.
        /// </summary>
        public string Mbid { get; set; }

        /// <summary>
        /// ArtistName.
        /// </summary>
        public string ArtistName { get; set; }

        /// <summary>
        /// ArtistMBid
        /// </summary>
        public string ArtistMbid { get; set; }

        /// <summary>
        /// Artist Images
        /// </summary>
        public virtual LastImageSet ArtistImages { get; set; }

        /// <summary>
        /// Artist Url.
        /// </summary>
        public Uri ArtistUrl { get; set; }

        /// <summary>
        /// Url of the track.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Images of the track.
        /// </summary>
        public virtual LastImageSet Images { get; set; }

        /// <summary>
        /// Album name of the track's album.
        /// </summary>
        public string AlbumName { get; set; }

        /// <summary>
        /// Number of listeners of the track.
        /// </summary>
        public int? ListenerCount { get; set; }

        /// <summary>
        /// Number of times the track has been played.
        /// </summary>
        public int? PlayCount { get; set; }

        /// <summary>
        /// Number of times the user has played the track.
        /// </summary>
        public int? UserPlayCount { get; set; }

        /// <summary>
        /// Tags of the track.
        /// </summary>
        [NotMapped]
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
