namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.Comparers
{
    using System;
    using System.Collections.Generic;
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
        public static StravaActivity FindFastestActivity(List<StravaActivity> listOfActivities)
        {
            if (listOfActivities.Count == 0)
            {
                throw new IndexOutOfRangeException("Empty activity list");
            }
            var kingOfTheHill = listOfActivities[0];
            foreach(var activity in listOfActivities)
            {
                if ( activity.average_speed > kingOfTheHill.average_speed)
                {
                    kingOfTheHill = activity;
                };
            }
            return kingOfTheHill;
        }
    }
}
