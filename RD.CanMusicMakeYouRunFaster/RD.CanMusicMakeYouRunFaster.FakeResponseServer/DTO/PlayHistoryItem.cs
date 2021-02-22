namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// PlayHistoryItem DTO
    /// </summary>
    public class PlayHistoryItem
    {
        /// <summary>
        /// DateTime of when the track was played.
        /// </summary>
        [JsonProperty("PlayedAt")]
        public DateTime? PlayedAt { get; set; }

        /// <summary>
        /// SimpleTrack object, holding track information.
        /// </summary>
        [JsonProperty("Track")]
        public virtual SimpleTrack Track { get; set; } = default!;

        /// <summary>
        /// Context object, holding context information.
        /// </summary>
        [JsonProperty("Context")]
        public virtual Context Context { get; set; } = default!;
    }
}
