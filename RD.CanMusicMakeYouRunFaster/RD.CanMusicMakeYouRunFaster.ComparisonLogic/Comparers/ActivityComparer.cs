namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.Comparers
{
    using System;
    using System.Collections.Generic;
    using Fitbit.Api.Portable.Models;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;

    /// <summary>
    /// Activity comparer class, used for finding differences between <see cref="StravaActivity"/> objects.
    /// </summary>
    public static class ActivityComparer
    {
        /// <summary>
        /// Function that returns the activity with the fastest average pace.
        /// </summary>
        /// <param name="listOfActivities">List of activities to compare</param>
        /// <returns>The activity with the fastest average pace.</returns>
        public static object FindFastestActivity(List<object> listOfActivities)
        {
            if (listOfActivities.Count == 0)
            {
                throw new NullReferenceException("FindFastestActivity: No Activities Parsed.");
            }

            object kingOfTheHill = listOfActivities[0];
            double kingOfTheHillSpeed = 0;

            foreach(var activity in listOfActivities)
            {
                if (activity is Activities fitbitActivity)
                {
                    if (fitbitActivity.Speed > kingOfTheHillSpeed)
                    {
                        kingOfTheHill = fitbitActivity;
                        kingOfTheHillSpeed = fitbitActivity.Speed;
                    }
                }
                else if (activity is StravaActivity stravaActivity)
                {
                    if (stravaActivity.average_speed > kingOfTheHillSpeed)
                    {
                        kingOfTheHill = stravaActivity;
                        kingOfTheHillSpeed = stravaActivity.average_speed;
                    };
                }
            }
            return kingOfTheHill;
        }
    }
}
