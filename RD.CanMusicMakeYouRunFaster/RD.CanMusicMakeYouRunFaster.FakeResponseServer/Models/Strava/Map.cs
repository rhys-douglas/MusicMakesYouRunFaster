using System.ComponentModel.DataAnnotations;

namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Strava
{
    /// <summary>
    /// Map class for fake activity objects.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Id of the map.
        /// </summary>
        [Key]
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
