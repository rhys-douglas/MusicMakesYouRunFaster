namespace RD.CanMusicMakeYouRunFaster.Rest.Entity
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Activity from Strava.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Resource state of the activity.
        /// </summary>
        public int resource_state { get; set; }

        /// <summary>
        /// Athlete from the activity.
        /// </summary>
        public Athlete athlete { get; set; }

        /// <summary>
        /// Name of the activity.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Distance of the activity.
        /// </summary>
        public double distance { get; set; }

        /// <summary>
        /// Moving time of the activity
        /// </summary>
        public int moving_time { get; set; }

        /// <summary>
        /// Elapsed time of the activity.
        /// </summary>
        public int elapsed_time { get; set; }

        /// <summary>
        /// Total elevation gain throughout the activity.
        /// </summary>
        public double total_elevation_gain { get; set; }

        /// <summary>
        /// Type of the activity e.g. run
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Workout type
        /// </summary>
        public int workout_type { get; set; }

        /// <summary>
        /// Id of the activity
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// External id of the activity.
        /// </summary>
        public string external_id { get; set; }

        /// <summary>
        /// Upload id of the activity
        /// </summary>
        public string upload_id { get; set; }

        /// <summary>
        /// Start date of the activity.
        /// </summary>
        public DateTime start_date { get; set; }

        /// <summary>
        /// Local time start date of the activity.
        /// </summary>
        public DateTime start_date_local { get; set; }

        /// <summary>
        /// Timezone of the activity
        /// </summary>
        public string timezone { get; set; }

        /// <summary>
        /// UTC offset of the activity
        /// </summary>
        public double utc_offset { get; set; }

        /// <summary>
        /// Start latlng position
        /// </summary>
        public List<double> start_latlng { get; set; }

        /// <summary>
        /// End latlng position
        /// </summary>
        public List<double> end_latlng { get; set; }

        /// <summary>
        /// City location of activity
        /// </summary>
        public object location_city { get; set; }

        /// <summary>
        /// State of activity
        /// </summary>
        public object location_state { get; set; }

        /// <summary>
        /// Country of activity.
        /// </summary>
        public object location_country { get; set; }

        /// <summary>
        /// Starting latitude.
        /// </summary>
        public double start_latitude { get; set; }

        /// <summary>
        /// Starting longitude.
        /// </summary>
        public double start_longitude { get; set; }

        /// <summary>
        /// Number of achievements earned from activity.
        /// </summary>
        public int achievement_count { get; set; }

        /// <summary>
        /// Number of kudos earned from activity.
        /// </summary>
        public int kudos_count { get; set; }

        /// <summary>
        /// Number of comments on activity.
        /// </summary>
        public int comment_count { get; set; }

        /// <summary>
        /// Number of athletes on the activity.
        /// </summary>
        public int athlete_count { get; set; }

        /// <summary>
        /// Number of photos on activity.
        /// </summary>
        public int photo_count { get; set; }

        /// <summary>
        /// Map representation of the activity.
        /// </summary>
        public Map map { get; set; }

        /// <summary>
        /// Trainer used?
        /// </summary>
        public bool trainer { get; set; }

        /// <summary>
        /// Was this a commute?
        /// </summary>
        public bool commute { get; set; }

        /// <summary>
        /// Was this activity uploaded manually?
        /// </summary>
        public bool manual { get; set; }

        /// <summary>
        /// Is the activity private?
        /// </summary>
        [JsonProperty("private")]
        public bool Private { get; set; }

        /// <summary>
        /// States the visibility of the activity.
        /// </summary>
        public string visibility { get; set; }

        /// <summary>
        /// States whether this activity has been flagged.
        /// </summary>
        public bool flagged { get; set; }

        /// <summary>
        /// Id of the gear used.
        /// </summary>
        public object gear_id { get; set; }

        /// <summary>
        /// From accepted tag?
        /// </summary>
        public bool from_accepted_tag { get; set; }

        /// <summary>
        /// Upload Id
        /// </summary>
        public string upload_id_str { get; set; }
        
        /// <summary>
        /// Average speed 
        /// </summary>
        public double average_speed { get; set; }

        /// <summary>
        /// Maximum speed
        /// </summary>
        public double max_speed { get; set; }

        /// <summary>
        /// Average cadence throughout the activity.
        /// </summary>
        public double average_cadence { get; set; }

        /// <summary>
        /// Average temperature of the activity.
        /// </summary>
        public int average_temp { get; set; }

        /// <summary>
        /// Is there heart rate data available?
        /// </summary>
        public bool has_heartrate { get; set; }

        /// <summary>
        /// Average heart rate 
        /// </summary>
        public double average_heartrate { get; set; }

        /// <summary>
        /// Maximum heart rate.
        /// </summary>
        public double max_heartrate { get; set; }

        /// <summary>
        /// Heart rate opted out?
        /// </summary>
        public bool heartrate_opt_out { get; set; }

        /// <summary>
        /// Display hidden heart rate?
        /// </summary>
        public bool display_hide_heartrate_option { get; set; }

        /// <summary>
        /// Highest elevation
        /// </summary>
        public double elev_high { get; set; }

        /// <summary>
        /// Lowest elevation
        /// </summary>
        public double elev_low { get; set; }

        /// <summary>
        /// PR count
        /// </summary>
        public int pr_count { get; set; }

        /// <summary>
        /// Total photos uploaded.
        /// </summary>
        public int total_photo_count { get; set; }

        /// <summary>
        /// Has the activity been kudoed by the authenticated user?
        /// </summary>
        public bool has_kudoed { get; set; }
    }
}
