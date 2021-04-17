namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models;
    using System.Threading.Tasks;

    [ApiController]
    [Route("/1/user/-/activities")]
    public class FitBitActivityLogsListController : ControllerBase
    {
        private readonly DataRetrievalContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FitBitActivityLogsListController"/> class.
        /// </summary>
        /// <param name="context">Database context </param>
        public FitBitActivityLogsListController(DataRetrievalContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the logged in users's activity logs list.
        /// </summary>
        /// <returns>Gets a list of activities</returns>
        [HttpGet]
        public async Task<DTO.ActivityLogsList> GetLoggedInAthleteActivities()
        {
            await Task.Delay(0);
            var fitBitActivities = context.FitBitActivityItems;
            var activityLogsList = new ActivityLogsList();
            foreach (var item in fitBitActivities)
            {
                activityLogsList.Activities.Add(item.ToDTO());
            }
            return activityLogsList;
        }
    }
}
