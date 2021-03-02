namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models;

    /// <summary>
    /// Strava activity Controller
    /// </summary>
    [ApiController]
    [Route("/v3/athlete/activities")]
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
        /// <returns>Gets a list of activities</returns>
        public async Task<List<DTO.Activity>> GetLoggedInAthleteActivities()
        {
            await Task.Delay(0);
            var activitiyHistory = context.ActivityHistoryItems;
            List<DTO.Activity> listofActivities = new List<DTO.Activity>();

            foreach (var item in activitiyHistory)
            {
                listofActivities.Add(item.ToDTO());
            }
            return listofActivities;
        }
    }
}
