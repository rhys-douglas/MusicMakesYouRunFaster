namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.FitBit
{
    using Newtonsoft.Json;

    /// <summary>
    /// Activity Level information.
    /// </summary>
    public class ActivityLevel
    {
        /// <summary>
        /// Activity level minutes
        /// </summary>
        [JsonProperty(PropertyName = "minutes")]
        public int Minutes { get; set; }

        /// <summary>
        /// Activity level name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
