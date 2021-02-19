namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using DbContext;
    using SpotifyAPI.Web;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Spotify Controller to get recently played.
    /// </summary>
    public class SpotifyMusicController : ControllerBase
    {
        private readonly DataRetrievalContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpotifyMusicController"/> class.
        /// </summary>
        /// <param name="context">Database context </param>
        public SpotifyMusicController(DataRetrievalContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the user's recently played music.
        /// </summary>
        /// <returns> A CursorPage of PlayHistoryItems</returns>
        [HttpGet]
        public async Task<CursorPaging<PlayHistoryItem>> GetRecentlyPlayed()
        {
            await Task.Delay(1);
            var musicHistory = context.PlayHistoryItems;
            List<PlayHistoryItem> listOfRecentlyPlayed = new List<PlayHistoryItem>();

            foreach (var item in musicHistory)
            {
                listOfRecentlyPlayed.Add(item);
            }

            var listeningHistory = new CursorPaging<PlayHistoryItem>
            {
                Items = listOfRecentlyPlayed
            };
            return listeningHistory;
        }
    }
}
