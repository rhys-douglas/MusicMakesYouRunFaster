namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class used to represent a PlayHistoryItem from the spotify API.
    /// This contains a subset of items used by the real PlayHistoryItem, as 
    /// not all properties are supported by EntityFrameworkCore.
    /// </summary>
    public class PlayHistoryItem
    {
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// DateTime of when the track was played.
        /// </summary>
        public DateTime? PlayedAt { get; set; }

        /// <summary>
        /// SimpleTrack object, holding track information.
        /// </summary>
        public SimpleTrack Track { get; set; } = default!;

        /// <summary>
        /// Context object, holding context information.
        /// </summary>
        public Context Context { get; set; } = default!;
    }
}
