namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// LinkedTrack class.
    /// </summary>
    public class LinkedTrack
    {
        /// <summary>
        /// External URLs
        /// </summary>
        [NotMapped]
        public Dictionary<string, string> ExternalUrls { get; set; } = default!;

        /// <summary>
        /// Href of the Linked Track.
        /// </summary>
        public string Href { get; set; } = default!;
        
        /// <summary>
        /// Id of the linked track.
        /// </summary>
        public string Id { get; set; } = default!;

        /// <summary>
        /// Type of the linked track.
        /// </summary>
        public string Type { get; set; } = default!;

        /// <summary>
        /// Uri of the linked track.
        /// </summary>
        public string Uri { get; set; } = default!;
    }
}
