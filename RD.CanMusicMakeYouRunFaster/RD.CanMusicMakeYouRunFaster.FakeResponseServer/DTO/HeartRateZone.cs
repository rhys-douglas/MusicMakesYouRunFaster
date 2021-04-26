namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Heart rate zone info.
    /// </summary>
    public class HeartRateZone
    {
        [JsonProperty(PropertyName = "caloriesOut")]
        public double CaloriesOut { get; set; }

        [JsonProperty(PropertyName = "max")]
        public int Max { get; set; }

        [JsonProperty(PropertyName = "min")]
        public int Min { get; set; }

        [JsonProperty(PropertyName = "minutes")]
        public int Minutes { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
