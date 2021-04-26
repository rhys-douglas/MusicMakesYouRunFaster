namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.LastFM
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// LastTag class, used in Last.FM to monitor tags on tracks.
    /// </summary>
    public class LastTag
    {
        /// <summary>
        /// Tag name.
        /// </summary>
        [Key]
        public string Name { get; set; }

        /// <summary>
        /// Url of the tag.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Tag count
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// What songs is the track related to?
        /// </summary>
        public string RelatedTo { get; set; }

        /// <summary>
        /// Is the song streamable?
        /// </summary>
        public bool? Streamable { get; set; }

        /// <summary>
        /// The number of users that have used this tag
        /// </summary>
        public int? Reach { get; set; }
    }
}
