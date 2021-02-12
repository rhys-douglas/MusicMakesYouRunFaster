namespace RD.CanMusicMakeYouRunFaster.Rest.DTO
{
    using System;

    /// <summary>
    /// Class used to hold a Spotify Authentication Token.
    /// </summary>
    public class SpotifyAuthenticationToken
    {
        /// <summary>
        /// Gets or sets the access token used to access the remainder of the spotify API.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the access token type e.g. "Bearer".
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the time from createdAt that the token is valid. Default is 1 hour or 3600 seconds.
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the scopes valid for this token.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the token used to refresh this token.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the DateTime of creation.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the access token has expired or not.
        /// </summary>
        public bool IsExpired { get; set; }
    }
}
