namespace RD.CanMusicMakeYouRunFaster.Rest.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    /// <summary>
    /// Athlete entity, held within a Strava Auth Token.
    /// </summary>
    public class StravaAthlete
    {
        /// <summary>
        /// Athlete Id
        /// </summary>
        [FromQuery(Name = "id")]
        public int id { get; set; }

        /// <summary>
        /// Athlete username
        /// </summary>
        [FromQuery(Name = "username")]
        public object username { get; set; }

        /// <summary>
        /// Athlete resource_state
        /// </summary>
        [FromQuery(Name = "resource_state")]
        public int resource_state { get; set; }

        /// <summary>
        /// Athlete first name.
        /// </summary>
        [FromQuery(Name = "firstname")]
        public string firstname { get; set; }

        /// <summary>
        /// Athlete last name.
        /// </summary>
        [FromQuery(Name = "lastname")]
        public string lastname { get; set; }

        /// <summary>
        /// Athlete city.
        /// </summary>
        [FromQuery(Name = "city")]
        public object city { get; set; }

        /// <summary>
        /// Athlete state.
        /// </summary>
        [FromQuery(Name = "state")]
        public object state { get; set; }

        /// <summary>
        /// Athlete country
        /// </summary>
        [FromQuery(Name = "country")]
        public object country { get; set; }

        /// <summary>
        /// Athlete sex
        /// </summary>
        [FromQuery(Name = "sex")]
        public string sex { get; set; }

        /// <summary>
        /// Athlete premium user check
        /// </summary>
        [FromQuery(Name = "premium")]
        public bool premium { get; set; }

        /// <summary>
        /// Athlete summit
        /// </summary>
        [FromQuery(Name = "summit")]
        public bool summit { get; set; }

        /// <summary>
        /// Athlete date time of creation
        /// </summary>
        [FromQuery(Name = "created_at")]
        public DateTime created_at { get; set; }

        /// <summary>
        /// Athlete time of last update.
        /// </summary>
        [FromQuery(Name = "updated_at")]
        public DateTime updated_at { get; set; }

        /// <summary>
        /// Type ID of the badge.
        /// </summary>
        [FromQuery(Name = "badge_type_id")]
        public int badge_type_id { get; set; }

        /// <summary>
        /// Medium size profile picture URL.
        /// </summary>
        [FromQuery(Name = "profile_medium")]
        public string profile_medium { get; set; }

        /// <summary>
        /// Profile URL.
        /// </summary>
        [FromQuery(Name = "profile")]
        public string profile { get; set; }

        /// <summary>
        /// States if the athlete is a friend with another Athlete.
        /// </summary>
        [FromQuery(Name = "friend")]
        public object friend { get; set; }

        /// <summary>
        /// States if the athlete is followed by another athlete.
        /// </summary>
        [FromQuery(Name = "follower")]
        public object follower { get; set; }
    }
}
