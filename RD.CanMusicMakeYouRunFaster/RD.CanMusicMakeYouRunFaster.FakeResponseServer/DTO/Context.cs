namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Context DTO
    /// </summary>
    public class Context
    {
        /// <summary>
        /// External Urls
        /// </summary>
        [JsonProperty("ExternalUrls")]
        public Dictionary<string, string> ExternalUrls { get; set; } = default!;

        /// <summary>
        /// Href of the associated item
        /// </summary>
        [JsonProperty("Href")]
        public string Href { get; set; } = default!;

        /// <summary>
        /// Type of the associated item
        /// </summary>
        [JsonProperty("Type")]
        public string Type { get; set; } = default!;

        /// <summary>
        /// Uri of the associated item.
        /// </summary>
        [JsonProperty("Uri")]
        public string Uri { get; set; } = default!;
    }
}
