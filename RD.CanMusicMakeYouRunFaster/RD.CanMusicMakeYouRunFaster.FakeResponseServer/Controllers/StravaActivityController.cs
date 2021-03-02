namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext;

    /// <summary>
    /// Strava activity Controller
    /// </summary>
    [ApiController]
    public class StravaActivityController : ControllerBase
    {
        private readonly DataRetrievalContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StravaActivityController"/> class.
        /// </summary>
        /// <param name="context">Database context </param>
        public StravaActivityController(DataRetrievalContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the logged in athlete's activtities.
        /// </summary>
        /// <returns></returns>
        public async Task<List<DTO.Activity>> GetLoggedInAthleteActivities()
        {
            await Task.Delay(0);
            return new List<DTO.Activity>();
        }
    }
}
