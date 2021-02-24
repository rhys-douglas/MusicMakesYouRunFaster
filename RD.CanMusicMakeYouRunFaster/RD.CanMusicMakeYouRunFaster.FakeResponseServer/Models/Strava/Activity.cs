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
        public string ExternalId { get; set; }

        /// <summary>
        /// Upload ID of the activity.
        /// </summary>
        public long UploadId { get; set; }

        /// <summary>
        /// Name of the activity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// meta or summary representation of the athlete
        /// </summary>
        public StravaObject<int> Athlete { get; set; }

        /// <summary>
        /// Distance [meters]
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// Moving time [sec]
        /// </summary>
        public int MovingTime { get; set; }
        /// <summary>
        /// seconds
        /// </summary>
        public int ElapsedTime { get; set; }

        /// <summary>
        /// meters
        /// </summary>
        public float TotalElevationGain { get; set; }

        /// <summary>
        /// Activity type, ie.ride, run, swim, etc.
        /// </summary>
        public ActivityType Type { get; set; }

        /// <summary>
        /// Starting date
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Starting time in local time zone
        /// </summary>
        public DateTime StartDateLocal { get; set; }

        /// <summary>
        /// Time zone of the activity.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Start <see cref="LatLng"/>
        /// </summary>
        public LatLng StartLatLng { get; set; }

        /// <summary>
        /// Start <see cref="Latlng"/>
        /// </summary>
        public LatLng EndLatLng { get; set; }

        /// <summary>
        /// Number of achievements gathered from this activity.
        /// </summary>
        public int AchievementCount { get; set; }

        /// <summary>
        /// Number of kudos.
        /// </summary>
        public int KudosCount { get; set; }

        /// <summary>
        /// Number of commen.ts
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// number of athletes taking part in this “group activity”. >= 1 
        /// </summary>
        public int AthleteCount { get; set; }

        /// <summary>
        /// Number of Instagram photos
        /// </summary>
        public int PhotoCount { get; set; }

        /// <summary>
        /// Total number of photos(Instagram and Strava)
        /// </summary>
        public int TotalPhotoCount { get; set; }

        /// <summary>
        /// detailed representation of the route
        /// </summary>
        public Map Map { get; set; }

        /// <summary>
        /// States whether a trainer was used.
        /// </summary>
        public bool Trainer { get; set; }

        /// <summary>
        /// States whether this activity was a commute
        /// </summary>
        public bool Commute { get; set; }

        /// <summary>
        /// States if this activity was manually uploaded.
        /// </summary>
        public bool Manual { get; set; }

        /// <summary>
        /// States if this activity is private.
        /// </summary>
        public bool Private { get; set; }

        /// <summary>
        /// The name of the device used to record the activity.
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// States whether the activity has been flagged or not.
        /// </summary>
        public bool Flagged { get; set; }

        /// <summary>
        /// Average speed [meters per second]
        /// </summary>
        public float AverageSpeed { get; set; }

        /// <summary>
        /// Maximum speed [meters per second]
        /// </summary>
        public float MaxSpeed { get; set; }

        /// <summary>
        /// Average cadence [rpm]
        /// </summary>
        public float AverageCadence { get; set; }

        /// <summary>
        /// degrees Celsius, if provided at upload
        /// </summary>
        public float AverageTemperature { get; set; }

        /// <summary>
        /// Average watts (rides only)
        /// </summary>
        public float AveragePower { get; set; }

        /// <summary>
        /// Maximum watts (rides only)
        /// </summary>
        public int MaxPower { get; set; }

        /// <summary>
        /// weighted_average_watts: integer rides with power meter data only
        /// similar to xPower or Normalized Power
        /// </summary>
        public int NormalizedPower { get; set; }

        /// <summary>
        /// kilojoules: float rides only
        /// uses estimated power if necessary
        /// </summary>
        public float Kilojoules { get; set; }

        /// <summary>
        /// true if the watts are from a power meter, false if estimated
        /// </summary>
        public bool DeviceWatts { get; set; }

        /// <summary>
        /// average_heartrate: float only if recorded with heartrate
        /// average over moving portion
        /// </summary>
        public float AverageHeartRate { get; set; }
        /// <summary>
        /// max_heartrate: integer only if recorded with heartrate
        /// </summary>
        public float MaxHeartRate { get; set; }

        /// <summary>
        /// States if the Oauth'd user has kudoed the activity.
        /// </summary>
        public bool HasKudoed { get; set; }

        /// <summary>
        /// Description of the activity.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// kilocalories, uses kilojoules for rides and speed/pace for runs
        /// </summary>
        public float Calories { get; set; }
    }
}
