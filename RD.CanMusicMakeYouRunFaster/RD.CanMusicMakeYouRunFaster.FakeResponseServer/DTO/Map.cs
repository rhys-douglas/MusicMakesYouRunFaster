namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;
    public class Map
    {
        /// <summary>
        /// Id of the map.
        /// </summary>
        [JsonProperty]
        public string id { get; set; }

        /// <summary>
        /// Polyline summary.
        /// </summary>
        [JsonProperty]
        public string summary_polyline { get; set; }

        /// <summary>
        /// Resource state 
        /// </summary>
        [JsonProperty]
        public int resource_state { get; set; }
    }
}
