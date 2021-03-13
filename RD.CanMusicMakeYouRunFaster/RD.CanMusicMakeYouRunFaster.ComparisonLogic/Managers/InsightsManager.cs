namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using SpotifyAPI.Web;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
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
        public Dictionary<Activity,List<PlayHistoryItem>> GetFastestActivityWithListeningHistory(Dictionary<Activity, List<PlayHistoryItem>> activityAndMusicHistory)
        {
            if (activityAndMusicHistory.Count == 0)
            {
                throw new IndexOutOfRangeException("No activities in parsed array dictionary.");
            }

            var fastestActivity = ActivityComparer.FindFastestActivity(activityAndMusicHistory.Keys.ToList());
            return new Dictionary<Activity, List<PlayHistoryItem>>
            {
                {fastestActivity, activityAndMusicHistory[fastestActivity] }
            };
        }
    }
}
