namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.Mappers
{
    using System;
    using System.Collections.Generic;
    using Fitbit.Api.Portable.Models;
    using IF.Lastfm.Core.Objects;
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
        /// <param name="activity">Activity to map songs to.</param>
        /// <param name="spotifyPlayHistory">List of PlayHistoryItems that are used to map to activities</param>
        /// <param name="lastFMPlayHistory">List of LastTracks that are used to map to activities</param>
        /// <returns>A 1 item dictionary of an activity to songs that played within the correct time range.</returns>
        public static Dictionary<StravaActivity, List<object>> MapSongsToActivity(StravaActivity activity, List<PlayHistoryItem> spotifyPlayHistory, List<LastTrack> lastFMPlayHistory)
        {
            var startTimeUTC = activity.start_date;
            var endTimeUTC = startTimeUTC.AddSeconds(activity.elapsed_time);

            List<object> validPlayHistory = new List<object>();

            foreach (var item in spotifyPlayHistory)
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

            foreach (var item in lastFMPlayHistory)
            {
                if (item.TimePlayed >= startTimeUTC && item.TimePlayed < endTimeUTC)
                {
                    validPlayHistory.Add(item);
                    continue;
                }

                DateTime itemStartTime = item.TimePlayed.Value.DateTime.Subtract((TimeSpan)item.Duration);

                if (itemStartTime >= startTimeUTC && itemStartTime < endTimeUTC)
                {
                    validPlayHistory.Add(item);
                    continue;
                }
            }

            return new Dictionary<StravaActivity, List<object>>
            {
                { activity, validPlayHistory }
            };
        }

        /// <summary>
        /// Maps valid songs to an activity
        /// </summary>
        /// <param name="activity">Activity to map songs to.</param>
        /// <param name="spotifyPlayHistory">List of PlayHistoryItems that are used to map to activities</param>
        /// <param name="lastFMPlayHistory">List of LastTracks that are used to map to activities</param>
        /// <returns>A 1 item dictionary of an activity to songs that played within the correct time range.</returns>
        public static Dictionary<Activities, List<object>> MapSongsToActivity(Activities activity, List<PlayHistoryItem> spotifyPlayHistory, List<LastTrack> lastFMPlayHistory)
        {
            var startTimeUTC = activity.StartTime;
            var endTimeUTC = startTimeUTC.AddSeconds(activity.Duration);

            List<object> validPlayHistory = new List<object>();

            foreach (var item in spotifyPlayHistory)
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

            foreach (var item in lastFMPlayHistory)
            {
                if (item.TimePlayed >= startTimeUTC && item.TimePlayed < endTimeUTC)
                {
                    validPlayHistory.Add(item);
                    continue;
                }

                DateTime itemStartTime = item.TimePlayed.Value.DateTime.Subtract((TimeSpan)item.Duration);

                if (itemStartTime >= startTimeUTC && itemStartTime < endTimeUTC)
                {
                    validPlayHistory.Add(item);
                    continue;
                }
            }

            return new Dictionary<Activities, List<object>>
            {
                { activity, validPlayHistory }
            };
        }
    }
}
