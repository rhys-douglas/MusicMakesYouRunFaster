namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Data transfer object for PKCE token responses.
    /// </summary>
    public class PKCETokenResponse
    {
        /// <summary>
        /// Access token 
        /// </summary>
        [JsonProperty("AccessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Type of the token e.g. bearer
        /// </summary>
        [JsonProperty("TokenType")]
        public string TokenType { get; set; }
        
        /// <summary>
        /// Expires in MS
        /// </summary>
        [JsonProperty("ExpiresIn")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Scope of the Token
        /// </summary>
        [JsonProperty("Scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Refresh token.
        /// </summary>
        [JsonProperty("RefreshToken")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// DateTime of creation
        /// </summary>
        [JsonProperty("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Bool if expired.
        /// </summary>
        [JsonProperty("IsExpired")]
        public bool IsExpired { get => CreatedAt.AddSeconds(ExpiresIn) <= DateTime.UtcNow;}
    }
}
