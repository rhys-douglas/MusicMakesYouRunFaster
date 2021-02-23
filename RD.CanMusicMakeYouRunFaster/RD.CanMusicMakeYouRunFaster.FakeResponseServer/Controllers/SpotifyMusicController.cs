namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using DbContext;
    using SpotifyAPI.Web;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models;

    /// <summary>
    /// Spotify Controller to get recently played.
    /// </summary>
    [ApiController]
    [Route("/v1/me/player/recently-played")]
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
        public async Task<CursorPaging<DTO.PlayHistoryItem>> GetRecentlyPlayed()
        {
            await Task.Delay(1);
            var musicHistory = context.PlayHistoryItems;
            List<DTO.PlayHistoryItem> listOfRecentlyPlayed = new List<DTO.PlayHistoryItem>();

            foreach (var item in musicHistory)
            {
                listOfRecentlyPlayed.Add(item.ToDTO());
            }

            var listeningHistory = new CursorPaging<DTO.PlayHistoryItem>
            {
                Items = listOfRecentlyPlayed
            };


            return listeningHistory;
        }
    }
}
