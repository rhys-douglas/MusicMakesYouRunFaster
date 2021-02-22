namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using System.Collections.Generic;

    /// <summary>
    /// Simple Artist DTO.
    /// </summary>
    public class SimpleArtist
    {
        /// <summary>
        /// External URls
        /// </summary>
        public Dictionary<string, string> ExternalUrls { get; set; } = default!;

        /// <summary>
        /// Href
        /// </summary>
        public string Href { get; set; } = default!;

        /// <summary>
        /// Id of the Artist
        /// </summary>
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
