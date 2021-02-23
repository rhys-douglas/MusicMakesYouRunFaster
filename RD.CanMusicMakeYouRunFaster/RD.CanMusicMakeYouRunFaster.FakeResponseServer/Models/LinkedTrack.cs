namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class used to represent a LinkedTrack from the spotify API.
    /// This contains a subset of items used by the real LinkedTrack, as 
    /// not all properties are supported by EntityFrameworkCore.
    /// </summary>
    public class LinkedTrack
    {
        /// <summary>
        /// External URLs of the Linked Track
        /// </summary>
        [NotMapped]
        public Dictionary<string, string> ExternalUrls { get; set; } = default!;

        /// <summary>
        /// Href of the Linked Track.
        /// </summary>
        public string Href { get; set; } = default!;
        
        /// <summary>
        /// Id of the Linked Track.
        /// </summary>
        public string Id { get; set; } = default!;

        /// <summary>
        /// Type of the Linked Track.
        /// </summary>
        public string Type { get; set; } = default!;

        /// <summary>
        /// Uri of the Linked Track.
        /// </summary>
        public string Uri { get; set; } = default!;
    }
}
