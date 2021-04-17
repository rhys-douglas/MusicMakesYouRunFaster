namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// DTO object to represent a FitBit Activity.
    /// </summary>
    public class FitBitActivities
    {
        /// <summary>
        /// Start time of the activity
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Speed throughout the activity
        /// </summary>
        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }

        /// <summary>
        /// Source of the activity.
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public ActivityLogSource Source { get; set; }

        /// <summary>
        /// Average pace of the activity.
        /// </summary>
        [JsonProperty(PropertyName = "pace")]
        public double Pace { get; set; }

        /// <summary>
        /// Original Start Time of activity.
        /// </summary>
        [JsonProperty(PropertyName = "originalStartTime")]
        public DateTimeOffset OriginalStartTime { get; set; }

        /// <summary>
        /// Original duration of activity.
        /// </summary>
        [JsonProperty(PropertyName = "originalDuration")]
        public int OriginalDuration { get; set; }

        /// <summary>
        /// Manual Values specified?
        /// </summary>
        [JsonProperty(PropertyName = "manualValuesSpecified")]
        public ManualValuesSpecified ManualValuesSpecified { get; set; }

        /// <summary>
        /// Log type of the activity.
        /// </summary>
        [JsonProperty(PropertyName = "logType")]
        public string LogType { get; set; }

        /// <summary>
        /// Id of the Log
        /// </summary>
        [JsonProperty(PropertyName = "logId")]
        public long LogId { get; set; }

        /// <summary>
        /// DateTimeOffset of most recent modification.
        /// </summary>
        [JsonProperty(PropertyName = "lastModified")]
        public DateTimeOffset LastModified { get; set; }

        /// <summary>
        /// Steps made during activity.
        /// </summary>
        [JsonProperty(PropertyName = "steps")]
        public int Steps { get; set; }

        /// <summary>
        /// Heart rate zones
        /// </summary>
        [JsonProperty(PropertyName = "heartRateZones")]
        public List<HeartRateZone> HeartRateZones { get; set; } = default!;

        /// <summary>
        /// Activity duration
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Units of distance used (KM etc)
        /// </summary>
        [JsonProperty(PropertyName = "distanceUnit")]
        public string DistanceUnit { get; set; }

        /// <summary>
        /// Distance travelled
        /// </summary>
        [JsonProperty(PropertyName = "distance")]
        public double Distance { get; set; }

        /// <summary>
        /// Date of the activity.
        /// </summary>
        public string DateOfActivity { get; }

        /// <summary>
        /// Calories burned throughout activity.
        /// </summary>
        [JsonProperty(PropertyName = "calories")]
        public int Calories { get; set; }

        /// <summary>
        /// Average heart rate of user.
        /// </summary>
        [JsonProperty(PropertyName = "averageHeartRate")]
        public int AverageHeartRate { get; set; }

        /// <summary>
        /// Activity type ID
        /// </summary>
        [JsonProperty(PropertyName = "activityTypeId")]
        public int ActivityTypeId { get; set; }

        /// <summary>
        /// Name of the activity.
        /// </summary>
        [JsonProperty(PropertyName = "activityName")]
        public string ActivityName { get; set; }

        /// <summary>
        /// ActivityLevel
        /// </summary>
        [JsonProperty(PropertyName = "activityLevel")]
        public List<ActivityLevel> ActivityLevel { get; set; } = default!;

        /// <summary>
        /// Duration user was active.
        /// </summary>
        [JsonProperty(PropertyName = "activeDuration")]
        public int ActiveDuration { get; set; }

        /// <summary>
        /// Activity Elev gain
        /// </summary>
        [JsonProperty(PropertyName = "elevationGain")]
        public double ElevationGain { get; set; }

        /// <summary>
        /// TCX Link
        /// </summary>
        [JsonProperty(PropertyName = "tcxLink")]
        public string TcxLink { get; set; }
    }
}
