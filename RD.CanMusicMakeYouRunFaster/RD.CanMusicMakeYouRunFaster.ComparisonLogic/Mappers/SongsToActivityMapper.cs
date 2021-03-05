namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.Mappers
{
    using System;
    using System.Collections.Generic;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using SpotifyAPI.Web;

    /// <summary>
    /// Class used for mapping songs to an activity.
    /// </summary>
    public class SongsToActivityMapper
    {
        /// <summary>
        /// Maps valid songs to an activity
        /// </summary>
        /// <param name="activity"> Activity to map songs to.</param>
        /// <param name="playHistory"> List of PlayHistoryItems that are used to map to activities</param>
        /// <returns> A 1 item dictionary of an activity to songs that played within the correct time range.</returns>
        public Dictionary<Activity,List<PlayHistoryItem>> MapSongsToActivity(Activity activity, List<PlayHistoryItem> playHistory)
        {
            var startTimeUTC = activity.start_date;
            var endTimeUTC = startTimeUTC.AddSeconds(activity.elapsed_time);

            List<PlayHistoryItem> validPlayHistory = new List<PlayHistoryItem>();

            foreach (var item in playHistory)
            {
                if (item.PlayedAt >= startTimeUTC && item.PlayedAt < endTimeUTC)
                {
                    validPlayHistory.Add(item);
                    continue;
                }

                DateTime itemStartTime = item.PlayedAt.AddMilliseconds(-item.Track.DurationMs);

                if (itemStartTime >= startTimeUTC && itemStartTime < endTimeUTC)
                {
                    validPlayHistory.Add(item);
                    continue;
                }
            }
            return new Dictionary<Activity, List<PlayHistoryItem>>
            {
                { activity, validPlayHistory }
            };
        }
    }
}
