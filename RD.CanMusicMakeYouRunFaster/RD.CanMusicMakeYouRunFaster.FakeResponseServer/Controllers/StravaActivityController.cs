namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Strava activity Controller
    /// </summary>
    [ApiController]
    public class StravaActivityController : ControllerBase
    {
        /// <summary>
        /// Gets the logged in athlete's activtities.
        /// </summary>
        /// <returns></returns>
        public async Task<DTO.Activity> GetLoggedInAthleteActivities()
        {
            await Task.Delay(0);
            return new DTO.Activity();
        }
    }
}
