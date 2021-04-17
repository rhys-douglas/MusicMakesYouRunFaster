namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Class to contain the response of an authentication request.
    /// </summary>
    public class FitBitAuthenticationTokenResponse
    {
        /// <summary>
        /// Token type (e.g. Bearer)
        /// </summary>
        [JsonProperty("token_type")]
        public string token_type { get; set; }

        /// <summary>
        /// Expires in (ms)
        /// </summary>
        [JsonProperty("expires_in")]
        public int? expires_in { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string refresh_token { get; set; }

        /// <summary>
        /// Access token string.
        /// </summary>
        [JsonProperty("access_token")]
        public string access_token { get; set; }

        /// <summary>
        /// User ID string.
        /// </summary>
        [JsonProperty("user_id")]
        public string user_id { get; set; }
    }
}
