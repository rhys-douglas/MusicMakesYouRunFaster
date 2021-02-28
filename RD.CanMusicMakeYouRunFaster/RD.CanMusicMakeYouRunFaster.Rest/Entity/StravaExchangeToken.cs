namespace RD.CanMusicMakeYouRunFaster.Rest.Entity
{
    /// <summary>
    /// Strava Exchange token class.
    /// </summary>
    public class StravaExchangeToken
    {
        // http://localhost:5001/stravatoken?state=&code=aa355bd0ab69ec74252c8bf69386cf835920d28a&scope=read,activity:read_all

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Exchange token code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Scope of the code.
        /// </summary>
        public string Scope { get; set; }
    }
}
