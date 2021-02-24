namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Strava
{
    using System;

    /// <summary>
    /// Fake activity model for a Strava activity.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// External ID of the activity.
        /// </summary>
        public string ExternalId { get; internal set; }

        /// <summary>
        /// Upload ID of the activity.
        /// </summary>
        public long UploadId { get; internal set; }

        /// <summary>
        /// Name of the activity.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// meta or summary representation of the athlete
        /// </summary>
        public StravaObject<int> Athlete { get; internal set; }

        /// <summary>
        /// Distance [meters]
        /// </summary>
        public float Distance { get; internal set; }

        /// <summary>
        /// Moving time [sec]
        /// </summary>
        public int MovingTime { get; internal set; }
        /// <summary>
        /// seconds
        /// </summary>
        public int ElapsedTime { get; internal set; }

        /// <summary>
        /// meters
        /// </summary>
        public float TotalElevationGain { get; internal set; }

        /// <summary>
        /// Activity type, ie.ride, run, swim, etc.
        /// </summary>
        public ActivityType Type { get; internal set; }

        /// <summary>
        /// Starting date
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate { get; internal set; }

        /// <summary>
        /// Starting time in local time zone
        /// </summary>
        public DateTime StartDateLocal { get; internal set; }

        /// <summary>
        /// Time zone of the activity.
        /// </summary>
        public string TimeZone { get; internal set; }

        /// <summary>
        /// Start <see cref="LatLng"/>
        /// </summary>
        public LatLng StartLatLng { get; internal set; }

        /// <summary>
        /// Start <see cref="Latlng"/>
        /// </summary>
        public LatLng EndLatLng { get; internal set; }

        /// <summary>
        /// Number of achievements gathered from this activity.
        /// </summary>
        public int AchievementCount { get; internal set; }

        /// <summary>
        /// Number of kudos.
        /// </summary>
        public int KudosCount { get; internal set; }

        /// <summary>
        /// Number of commen.ts
        /// </summary>
        public int CommentCount { get; internal set; }

        /// <summary>
        /// number of athletes taking part in this “group activity”. >= 1 
        /// </summary>
        public int AthleteCount { get; internal set; }

        /// <summary>
        /// Number of Instagram photos
        /// </summary>
        public int PhotoCount { get; internal set; }

        /// <summary>
        /// Total number of photos(Instagram and Strava)
        /// </summary>
        public int TotalPhotoCount { get; internal set; }

        /// <summary>
        /// detailed representation of the route
        /// </summary>
        public Map Map { get; internal set; }

        /// <summary>
        /// States whether a trainer was used.
        /// </summary>
        public bool Trainer { get; internal set; }

        /// <summary>
        /// States whether this activity was a commute
        /// </summary>
        public bool Commute { get; internal set; }

        /// <summary>
        /// States if this activity was manually uploaded.
        /// </summary>
        public bool Manual { get; internal set; }

        /// <summary>
        /// States if this activity is private.
        /// </summary>
        public bool Private { get; internal set; }

        /// <summary>
        /// The name of the device used to record the activity.
        /// </summary>
        public string DeviceName { get; internal set; }

        /// <summary>
        /// States whether the activity has been flagged or not.
        /// </summary>
        public bool Flagged { get; internal set; }

        /// <summary>
        /// Average speed [meters per second]
        /// </summary>
        public float AverageSpeed { get; internal set; }

        /// <summary>
        /// Maximum speed [meters per second]
        /// </summary>
        public float MaxSpeed { get; internal set; }

        /// <summary>
        /// Average cadence [rpm]
        /// </summary>
        public float AverageCadence { get; internal set; }

        /// <summary>
        /// degrees Celsius, if provided at upload
        /// </summary>
        public float AverageTemperature { get; internal set; }

        /// <summary>
        /// Average watts (rides only)
        /// </summary>
        public float AveragePower { get; internal set; }

        /// <summary>
        /// Maximum watts (rides only)
        /// </summary>
        public int MaxPower { get; internal set; }

        /// <summary>
        /// weighted_average_watts: integer rides with power meter data only
        /// similar to xPower or Normalized Power
        /// </summary>
        public int NormalizedPower { get; internal set; }

        /// <summary>
        /// kilojoules: float rides only
        /// uses estimated power if necessary
        /// </summary>
        public float Kilojoules { get; internal set; }

        /// <summary>
        /// true if the watts are from a power meter, false if estimated
        /// </summary>
        public bool DeviceWatts { get; internal set; }

        /// <summary>
        /// average_heartrate: float only if recorded with heartrate
        /// average over moving portion
        /// </summary>
        public float AverageHeartRate { get; internal set; }
        /// <summary>
        /// max_heartrate: integer only if recorded with heartrate
        /// </summary>
        public float MaxHeartRate { get; internal set; }

        /// <summary>
        /// States if the Oauth'd user has kudoed the activity.
        /// </summary>
        public bool HasKudoed { get; internal set; }

        /// <summary>
        /// Description of the activity.
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// kilocalories, uses kilojoules for rides and speed/pace for runs
        /// </summary>
        public float Calories { get; internal set; }
    }
}
