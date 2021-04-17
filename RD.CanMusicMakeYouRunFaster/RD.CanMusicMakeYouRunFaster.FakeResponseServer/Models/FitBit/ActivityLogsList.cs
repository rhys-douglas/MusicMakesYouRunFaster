namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.FitBit
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// FitBit object containing a list of Activities.
    /// </summary>
    public class ActivityLogsList
    {
        /// <summary>
        /// List of Activities retrieved.
        /// </summary>
        [JsonProperty(PropertyName = "activities")]
        public List<Activities> Activities { get; set; } = default!;
    }
}

