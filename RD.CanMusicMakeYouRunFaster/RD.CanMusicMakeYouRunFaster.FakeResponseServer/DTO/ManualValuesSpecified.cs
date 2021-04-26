namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Manual values specified class.
    /// </summary>
    public class ManualValuesSpecified
    {
        /// <summary>
        /// Calories burned.
        /// </summary>
        [JsonProperty(PropertyName = "calories")]
        public bool Calories { get; set; }

        /// <summary>
        /// Distance covered.
        /// </summary>
        [JsonProperty(PropertyName = "distance")]
        public bool Distance { get; set; }

        /// <summary>
        /// Steps made.
        /// </summary>
        [JsonProperty(PropertyName = "steps")]
        public bool Steps { get; set; }
    }
}
