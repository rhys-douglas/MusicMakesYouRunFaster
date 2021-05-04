namespace RD.CanMusicMakeYouRunFaster.Rest.Entity
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class used to represent a strava authentication token
    /// </summary>
    public class StravaAuthenticationToken
    {
        /// <summary>
        /// Token type (e.g. Bearer)
        /// </summary>
        [FromQuery(Name = "token_type")]
        public string token_type { get; set; }

        /// <summary>
        /// Expires at (ms)
        /// </summary>
        [FromQuery(Name = "expires_at")]
        public int expires_at { get; set; }

        /// <summary>
        /// Expires in (Ms)
        /// </summary>
        [FromQuery(Name = "expires_in")]
        public int expires_in { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        [FromQuery(Name = "refresh_token")]
        public string refresh_token { get; set; }

        /// <summary>
        /// Access token string.
        /// </summary>
        [FromQuery(Name = "access_token")]
        public string access_token { get; set; }

        /// <summary>
        /// Athlete 
        /// </summary>
        [FromQuery(Name = "athlete")]
        public StravaAthlete athlete { get; set; }
    }
}
