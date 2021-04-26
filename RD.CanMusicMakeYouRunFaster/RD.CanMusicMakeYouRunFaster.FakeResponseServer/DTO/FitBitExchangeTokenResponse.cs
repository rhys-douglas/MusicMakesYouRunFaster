namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// A FitBit Exchange Token Response 
    /// </summary>
    public class FitBitExchangeTokenResponse
    {
        /// <summary>
        /// Exchange token code. 
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
