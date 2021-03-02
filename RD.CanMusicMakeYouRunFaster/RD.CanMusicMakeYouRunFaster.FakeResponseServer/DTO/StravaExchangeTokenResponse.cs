namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Strava Exchange Token response
    /// </summary>
    public class StravaExchangeTokenResponse
    {
        /// <summary>
        /// Exchange token code. 
        /// </summary>
        [JsonProperty("code")]
        public string code { get; set; }

        /// <summary>
        /// Exchange token state. 
        /// </summary>
        [JsonProperty("state")]
        public string state { get; set; }

        /// <summary>
        /// Exchange token state. 
        /// </summary>
        [JsonProperty("scope")]
        public string scope { get; set; }
    }
}
