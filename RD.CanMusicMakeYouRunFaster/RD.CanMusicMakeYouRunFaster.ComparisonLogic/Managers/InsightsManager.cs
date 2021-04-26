namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using RD.CanMusicMakeYouRunFaster.ComparisonLogic.Comparers;
    using System;

    /// <summary>
    /// Insights manager, used for managing insights made comparing user data.
    /// </summary>
    public class InsightsManager
    {
        /// <summary>
        /// Finds the fastest activity in the given dictionary, and returns the listening history associated with it.
        /// </summary>
        /// <param name="activityAndMusicHistory"></param>
        /// <returns></returns>
        public Dictionary<object,List<object>> GetFastestActivityWithListeningHistory(Dictionary<object, List<object>> activityAndMusicHistory)
        {
            if (activityAndMusicHistory.Count == 0)
            {
                throw new IndexOutOfRangeException("No activities in parsed array dictionary.");
            }

            var fastestActivity = ActivityComparer.FindFastestActivity(activityAndMusicHistory.Keys.ToList());
            return new Dictionary<object, List<object>>
            {
                {fastestActivity, activityAndMusicHistory[fastestActivity] }
            };
        }
    }
}
