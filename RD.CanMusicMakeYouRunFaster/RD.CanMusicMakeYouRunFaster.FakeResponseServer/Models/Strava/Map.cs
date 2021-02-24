namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Strava
{
    /// <summary>
    /// Detailed representation of the route
    /// </summary>
    public class Map : StravaObject<string>
    {
        /// <summary>
        /// Polyline with all points
        /// </summary>
        public string Polyline { get; internal set; }

        /// <summary>
        /// Summary polyline
        /// </summary>
        public string SummaryPolyline { get; internal set; }
    }
}
