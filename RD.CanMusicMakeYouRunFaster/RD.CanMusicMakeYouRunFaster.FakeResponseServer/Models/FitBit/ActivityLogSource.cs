namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.FitBit
{
    using Newtonsoft.Json;

    /// <summary>
    /// Activity Log Source.
    /// </summary>
    public class ActivityLogSource
    {
        /// <summary>
        /// Activity log source ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Activity log name
        /// </summary>

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Activity log type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }


        /// <summary>
        /// Activity log url.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
