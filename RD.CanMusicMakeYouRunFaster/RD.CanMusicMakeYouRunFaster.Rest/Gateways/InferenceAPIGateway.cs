namespace RD.CanMusicMakeYouRunFaster.Rest.Gateways
{
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using System.Collections.Generic;

    /// <summary>
    /// Inference API gateway, used for inferences.
    /// </summary>
    [ApiController]
    [Route("/CMMYRFI")]
    public class InferenceAPIGateway : ControllerBase
    {

        [HttpPost]
        [Route("postStravaActivities")]
        [EnableCors("CorsPolicy")]
        public JsonResult PostFastestStravaActivity([FromBody]List<StravaActivity> stravaActivityList)
        {
            if (stravaActivityList == null || stravaActivityList.Count == 0)
            {
                return new JsonResult(null);
            }

            StravaActivity kingOfTheHill = stravaActivityList[0];

            foreach (StravaActivity activity in stravaActivityList)
            {
                if (activity.average_speed > kingOfTheHill.average_speed)
                {
                    kingOfTheHill = activity;
                }
            }

            return new JsonResult(kingOfTheHill);
        }
    }
}
