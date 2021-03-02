namespace RD.CanMusicMakeYouRunFaster.Rest.Entity
{
    /// <summary>
    /// Class used to represent a strava authentication token
    /// </summary>
    public class StravaAuthenticationToken
    {
        /// <summary>
        /// Token type (e.g. Bearer)
        /// </summary>
        public string token_type { get; set; }

        /// <summary>
        /// Expires at (ms)
        /// </summary>
        public int expires_at { get; set; }

        /// <summary>
        /// Expires in (Ms)
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// Access token string.
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Athlete 
        /// </summary>
        public Athlete athlete { get; set; }
    }
}
