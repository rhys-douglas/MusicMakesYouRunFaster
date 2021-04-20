namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO.Request
{
    using Newtonsoft.Json;

    /// <summary>
    /// Request class for holding params to the Last FM "Get recent tracks" controller.
    /// </summary>
    public class LastFMGetRecentTracksRequest
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("from")]
        public long? From { get; set; } = default!;
    }
}
