namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Strava Authentication Token Response.
    /// </summary>
    public class StravaAuthenticationTokenResponse
    {
        /// <summary>
        /// Token type (e.g. Bearer)
        /// </summary>
        [JsonProperty("token_type")]
        public string token_type { get; set; }

        /// <summary>
        /// Expires at (ms)
        /// </summary>
        [JsonProperty("expires_at")]
        public int? expires_at { get; set; }

        /// <summary>
        /// Expires in (Ms)
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
        /// Athlete 
        /// </summary>
        public Athlete athlete { get; set; }
    }
}
