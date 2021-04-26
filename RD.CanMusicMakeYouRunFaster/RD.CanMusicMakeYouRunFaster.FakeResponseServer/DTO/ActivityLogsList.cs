namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// FitBit object containing a list of Activities.
    /// </summary>
    public class ActivityLogsList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityLogsList"/> class.
        /// </summary>
        public ActivityLogsList()
        {
            Activities = new List<FitBitActivities>();
        }
        /// <summary>
        /// List of Activities retrieved.
        /// </summary>
        [JsonProperty(PropertyName = "activities")]
        public List<FitBitActivities> Activities { get; set; }
    }
}
