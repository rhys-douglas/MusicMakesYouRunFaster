namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using DbContext;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models;
    using System;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO;

    /// <summary>
    /// LastFM Music Controller
    /// </summary>
    public class LastFMMusicController : ControllerBase
    {
        private readonly DataRetrievalContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LastFMMusicController"/> class.
        /// </summary>
        /// <param name="context">Database context </param>
        public LastFMMusicController(DataRetrievalContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the user's recently played music.
        /// </summary>
        /// <returns> A PageResponse of LastTrack objects</returns>
        [HttpGet]
        public async Task<PageResponse<LastTrack>> GetRecentTracks([FromQuery] DateTimeOffset? after = null)
        {
            await Task.Delay(0);
            var musicHistory = context.LastTracks;
            List<LastTrack> listOfRecentlyPlayed = new List<LastTrack>();

            if (after == null)
            {
                foreach (var item in musicHistory)
                {
                    listOfRecentlyPlayed.Add(item.ToDTO());
                }
            }
            else
            {
                foreach (var item in musicHistory)
                {
                    if (item.PlayedAt >= after)
                    {
                        listOfRecentlyPlayed.Add(item.ToDTO());
                    }
                }
            }

            var listeningHistory = new PageResponse<LastTrack>
            {
                Content = listOfRecentlyPlayed
            };

            return listeningHistory;
        }

    }
}
