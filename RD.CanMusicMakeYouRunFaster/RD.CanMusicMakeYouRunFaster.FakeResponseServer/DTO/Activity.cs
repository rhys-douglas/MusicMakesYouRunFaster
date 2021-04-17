namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Strava Activity DTO.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Resource state of the activity.
        /// </summary>
        [JsonProperty]
        public int resource_state { get; set; }

        /// <summary>
        /// Athlete from the activity.
        /// </summary>
        [JsonProperty]
        public Athlete athlete { get; set; }

        /// <summary>
        /// Name of the activity.
        /// </summary>
        [JsonProperty]
        public string name { get; set; }

        /// <summary>
        /// Distance of the activity.
        /// </summary>
        [JsonProperty]
        public double distance { get; set; }

        /// <summary>
        /// Moving time of the activity
        /// </summary>
        [JsonProperty]
        public int moving_time { get; set; }

        /// <summary>
        /// Elapsed time of the activity.
        /// </summary>
        [JsonProperty]
        public int elapsed_time { get; set; }

        /// <summary>
        /// Total elevation gain throughout the activity.
        /// </summary>
        [JsonProperty]
        public double total_elevation_gain { get; set; }

        /// <summary>
        /// Type of the activity e.g. run
        /// </summary>
        [JsonProperty]
        public string type { get; set; }

        /// <summary>
        /// Workout type
        /// </summary>
        [JsonProperty]
        public int workout_type { get; set; }

        /// <summary>
        /// Id of the activity
        /// </summary>
        [JsonProperty]
        public string id { get; set; }

        /// <summary>
        /// External id of the activity.
        /// </summary>
        [JsonProperty]
        public string external_id { get; set; }

        /// <summary>
        /// Upload id of the activity
        /// </summary>
        [JsonProperty]
        public string upload_id { get; set; }

        /// <summary>
        /// Start date of the activity.
        /// </summary>
        [JsonProperty]
        public DateTime start_date { get; set; }

        /// <summary>
        /// Local time start date of the activity.
        /// </summary>
        [JsonProperty]
        public DateTime start_date_local { get; set; }

        /// <summary>
        /// Timezone of the activity
        /// </summary>
        [JsonProperty]
        public string timezone { get; set; }

        /// <summary>
        /// UTC offset of the activity
        /// </summary>
        [JsonProperty]
        public double utc_offset { get; set; }

        /// <summary>
        /// Start latlng position
        /// </summary>
        [JsonProperty]
        public List<double> start_latlng { get; set; }

        /// <summary>
        /// End latlng position
        /// </summary>
        [JsonProperty]
        public List<double> end_latlng { get; set; }

        /// <summary>
        /// City location of activity
        /// </summary>
        [JsonProperty]
        public object location_city { get; set; }

        /// <summary>
        /// State of activity
        /// </summary>
        [JsonProperty]
        public object location_state { get; set; }

        /// <summary>
        /// Country of activity.
        /// </summary>
        [JsonProperty]
        public object location_country { get; set; }

        /// <summary>
        /// Starting latitude.
        /// </summary>
        [JsonProperty]
        public double start_latitude { get; set; }

        /// <summary>
        /// Starting longitude.
        /// </summary>
        [JsonProperty]
        public double start_longitude { get; set; }

        /// <summary>
        /// Number of achievements earned from activity.
        /// </summary>
        [JsonProperty]
        public int achievement_count { get; set; }

        /// <summary>
        /// Number of kudos earned from activity.
        /// </summary>
        [JsonProperty]
        public int kudos_count { get; set; }

        /// <summary>
        /// Number of comments on activity.
        /// </summary>
        [JsonProperty]
        public int comment_count { get; set; }

        /// <summary>
        /// Number of athletes on the activity.
        /// </summary>
        [JsonProperty]
        public int athlete_count { get; set; }

        /// <summary>
        /// Number of photos on activity.
        /// </summary>
        [JsonProperty]
        public int photo_count { get; set; }

        /// <summary>
        /// Map representation of the activity.
        /// </summary>
        public Map map { get; set; }

        /// <summary>
        /// Trainer used?
        /// </summary>
        [JsonProperty]
        public bool trainer { get; set; }

        /// <summary>
        /// Was this a commute?
        /// </summary>
        [JsonProperty]
        public bool commute { get; set; }

        /// <summary>
        /// Was this activity uploaded manually?
        /// </summary>
        [JsonProperty]
        public bool manual { get; set; }

        /// <summary>
        /// Is the activity private?
        /// </summary>
        [JsonProperty("private")]
        public bool Private { get; set; }

        /// <summary>
        /// States the visibility of the activity.
        /// </summary>
        [JsonProperty]
        public string visibility { get; set; }

        /// <summary>
        /// States whether this activity has been flagged.
        /// </summary>
        [JsonProperty]
        public bool flagged { get; set; }

        /// <summary>
        /// Id of the gear used.
        /// </summary>
        [JsonProperty]
        public object gear_id { get; set; }

        /// <summary>
        /// From accepted tag?
        /// </summary>
        [JsonProperty]
        public bool from_accepted_tag { get; set; }

        /// <summary>
        /// Upload Id
        /// </summary>
        [JsonProperty]
        public string upload_id_str { get; set; }

        /// <summary>
        /// Average speed 
        /// </summary>
        [JsonProperty]
        public double average_speed { get; set; }

        /// <summary>
        /// Maximum speed
        /// </summary>
        [JsonProperty]
        public double max_speed { get; set; }

        /// <summary>
        /// Average cadence throughout the activity.
        /// </summary>
        [JsonProperty]
        public double average_cadence { get; set; }

        /// <summary>
        /// Average temperature of the activity.
        /// </summary>
        [JsonProperty]
        public int average_temp { get; set; }

        /// <summary>
        /// Is there heart rate data available?
        /// </summary>
        [JsonProperty]
        public bool has_heartrate { get; set; }

        /// <summary>
        /// Average heart rate 
        /// </summary>
        [JsonProperty]
        public double average_heartrate { get; set; }

        /// <summary>
        /// Maximum heart rate.
        /// </summary>
        [JsonProperty]
        public double max_heartrate { get; set; }

        /// <summary>
        /// Heart rate opted out?
        /// </summary>
        [JsonProperty]
        public bool heartrate_opt_out { get; set; }

        /// <summary>
        /// Display hidden heart rate?
        /// </summary>
        [JsonProperty]
        public bool display_hide_heartrate_option { get; set; }

        /// <summary>
        /// Highest elevation
        /// </summary>
        [JsonProperty]
        public double elev_high { get; set; }

        /// <summary>
        /// Lowest elevation
        /// </summary>
        [JsonProperty]
        public double elev_low { get; set; }

        /// <summary>
        /// PR count
        /// </summary>
        [JsonProperty]
        public int pr_count { get; set; }

        /// <summary>
        /// Total photos uploaded.
        /// </summary>
        [JsonProperty]
        public int total_photo_count { get; set; }

        /// <summary>
        /// Has the activity been kudoed by the authenticated user?
        /// </summary>
        [JsonProperty]
        public bool has_kudoed { get; set; }
    }
}
