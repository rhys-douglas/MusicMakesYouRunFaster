namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using System.Collections.Generic;

    /// <summary>
    /// Page Response DTO, used for LastFM tracks.
    /// </summary>
    public class PageResponse<T>
    {
        /// <summary>
        /// Content of the Page.
        /// </summary>
        public List<T> Content { get; internal set; }

        /// <summary>
        /// Page number
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total page count
        /// </summary>
        public int TotalPages { get; set;  }

        /// <summary>
        /// Total items.
        /// </summary>
        public int TotalItems { get; set; }
    }
}
