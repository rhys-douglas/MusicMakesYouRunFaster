namespace RD.CanMusicMakeYouRunFaster.Rest.Entity
{
    using Newtonsoft.Json;

    /// <summary>
    /// Class used to hold FitBit Authentication tokens.
    /// </summary>
    public class FitBitAuthenticationToken
    {
        /// <summary>
        /// Access token.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Expiry time of the token.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Refresh token.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Type of token (usually Bearer)
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// User Id of the authenticated user.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; }

    }
}
