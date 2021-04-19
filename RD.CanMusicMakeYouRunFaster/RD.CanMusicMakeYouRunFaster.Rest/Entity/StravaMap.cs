namespace RD.CanMusicMakeYouRunFaster.Rest.Entity
{
    /// <summary>
    /// Map used in an <see cref="StravaActivity"/>
    /// </summary>
    public class StravaMap
    {
        /// <summary>
        /// Id of the map.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Polyline summary.
        /// </summary>
        public string summary_polyline { get; set; }

        /// <summary>
        /// Resource state 
        /// </summary>
        public int resource_state { get; set; }
    }
}
