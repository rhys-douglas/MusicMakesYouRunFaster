namespace RD.CanMusicMakeYouRunFaster.Rest.Entity
{
    using System;
    using Newtonsoft.Json;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity.Utils;

    /// <summary>
    /// Class used to hold a Spotify Authentication Token.
    /// </summary>
    public class SpotifyAuthenticationToken
    {
        /// <summary>
        /// Gets or sets the access token used to access the remainder of the spotify API.
        /// </summary>
        [JsonProperty("AccessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the access token type e.g. "Bearer".
        /// </summary>
        [JsonProperty("TokenType")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the time from createdAt that the token is valid. Default is 1 hour or 3600 seconds.
        /// </summary>
        [JsonProperty("ExpiresIn")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the scopes valid for this token.
        /// </summary>
        [JsonProperty("Scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the token used to refresh this token.
        /// </summary>
        [JsonProperty("RefreshToken")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the DateTime of creation.
        /// </summary>
        [JsonProperty("CreatedAt")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the access token has expired or not.
        /// </summary>
        [JsonProperty("IsExpired")]
        public bool IsExpired { get; set; }
    }
}
