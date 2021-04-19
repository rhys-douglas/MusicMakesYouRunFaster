namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Last track DTO, used for holding track information from Last.FM
    /// </summary>
    public class LastTrack
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public TimeSpan? Duration { get; set; }

        public string Mbid { get; set; }

        public string ArtistName { get; set; }

        public string ArtistMbid { get; set; }

        public LastImageSet ArtistImages { get; set; }

        public Uri ArtistUrl { get; set; }

        public Uri Url { get; set; }

        public LastImageSet Images { get; set; }

        public string AlbumName { get; set; }

        public int? ListenerCount { get; set; }

        public int? PlayCount { get; set; }

        public int? UserPlayCount { get; set; }

        public IEnumerable<LastTag> TopTags { get; set; }

        public DateTimeOffset? TimePlayed { get; set; }

        public bool? IsLoved { get; set; }

        public bool? IsNowPlaying { get; set; }

        public int? Rank { get; set; }
    }
}
