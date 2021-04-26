namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.FitBit
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Heart rate zone info.
    /// </summary>
    public class HeartRateZone
    {
        /// <summary>
        /// Calories out
        /// </summary>
        [JsonProperty(PropertyName = "caloriesOut")]
        public double CaloriesOut { get; set; }

        /// <summary>
        /// Max heart rate.
        /// </summary>
        [JsonProperty(PropertyName = "max")]
        public int Max { get; set; }

        /// <summary>
        /// Minimum heart rate
        /// </summary>
        [JsonProperty(PropertyName = "min")]
        public int Min { get; set; }

        /// <summary>
        /// Minutes of heart rate zone
        /// </summary>
        [JsonProperty(PropertyName = "minutes")]
        public int Minutes { get; set; }

        /// <summary>
        /// Name of heart rate zone
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        [Key]
        public string Name { get; set; }
    }
}
