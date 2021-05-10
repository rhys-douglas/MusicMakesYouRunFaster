namespace RD.CanMusicMakeYouRunFaster.Rest.Gateways
{
    using Fitbit.Api.Portable.Models;
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
        /// <summary>
        /// Returns the fastest Strava activity posted to this endpoint.
        /// </summary>
        /// <param name="stravaActivityList">Strava activity list, read from the body of the post request in JSON format.</param>
        /// <returns>Fastest activity in the list.</returns>
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

        /// <summary>
        /// Returns the fastest FitBitActivity posted to this endpoint.
        /// </summary>
        /// <param name="activityLogsList"> FitBit ActivityLogsList, read from the body of the post request in JSON format. </param>
        /// <returns> Fastest activity in the list </returns>
        [HttpPost]
        [Route("postFitBitActivities")]
        [EnableCors("CorsPolicy")]
        public JsonResult PostFastestFitBitActivity([FromBody] ActivityLogsList activityLogsList)
        {
            if (activityLogsList == null || activityLogsList.Activities == null || activityLogsList.Activities.Count == 0)
            {
                return new JsonResult(null);
            }

            Activities kingOfTheHill = activityLogsList.Activities[0];
            foreach (Activities activity in activityLogsList.Activities)
            {
                if (activity.Speed > kingOfTheHill.Speed)
                {
                    kingOfTheHill = activity;
                }
            }
            return new JsonResult(kingOfTheHill);
        }
    }
}
