namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class used to represent a Context from the spotify API.
    /// This contains a subset of items used by the real Context, as 
    /// not all properties are supported by EntityFrameworkCore.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// External Urls
        /// </summary>
        [NotMapped]
        public Dictionary<string, string> ExternalUrls { get; set; } = default!;

        /// <summary>
        /// Href of the associated item
        /// </summary>
        public string Href { get; set; } = default!;

        /// <summary>
        /// Type of the associated item
        /// </summary>
        public string Type { get; set; } = default!;

        /// <summary>
        /// Uri of the associated item.
        /// </summary>
        public string Uri { get; set; } = default!;
    }
}
