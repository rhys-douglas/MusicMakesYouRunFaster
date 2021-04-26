namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Page Response DTO, used for LastFM tracks.
    /// </summary>
    public class PageResponse<T>
    {
        /// <summary>
        /// Content of the Page.
        /// </summary>
        [JsonProperty("content")]
        public List<T> Content { get; internal set; }

        /// <summary>
        /// Page number
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        [JsonProperty("pagesize")]
        public int PageSize { get; set; }

        /// <summary>
        /// Total page count
        /// </summary>
        [JsonProperty("totalpages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Total items.
        /// </summary>
        [JsonProperty("totalitems")]
        public int TotalItems { get; set; }
    }
}
