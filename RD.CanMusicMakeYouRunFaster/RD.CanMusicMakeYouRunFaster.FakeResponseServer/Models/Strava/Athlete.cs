namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Strava
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Fake Athlete model.
    /// </summary>
    public class Athlete
    {
        /// <summary>
        /// Athlete Id
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Athlete username
        /// </summary>
        public object username { get; set; }

        /// <summary>
        /// Athlete resource_state
        /// </summary>
        public int resource_state { get; set; }

        /// <summary>
        /// Athlete first name.
        /// </summary>
        public string firstname { get; set; }

        /// <summary>
        /// Athlete last name.
        /// </summary>
        public string lastname { get; set; }

        /// <summary>
        /// Athlete city.
        /// </summary>
        public object city { get; set; }

        /// <summary>
        /// Athlete state.
        /// </summary>
        public object state { get; set; }

        /// <summary>
        /// Athlete country
        /// </summary>
        public object country { get; set; }

        /// <summary>
        /// Athlete sex
        /// </summary>
        public string sex { get; set; }

        /// <summary>
        /// Athlete premium user check
        /// </summary>
        public bool premium { get; set; }

        /// <summary>
        /// Athlete summit
        /// </summary>
        public bool summit { get; set; }

        /// <summary>
        /// Athlete date time of creation
        /// </summary>
        public DateTime created_at { get; set; }

        /// <summary>
        /// Athlete time of last update.
        /// </summary>
        public DateTime updated_at { get; set; }

        /// <summary>
        /// Type ID of the badge.
        /// </summary>
        public int badge_type_id { get; set; }

        /// <summary>
        /// Medium size profile picture URL.
        /// </summary>
        public string profile_medium { get; set; }

        /// <summary>
        /// Profile URL.
        /// </summary>
        public string profile { get; set; }

        /// <summary>
        /// States if the athlete is a friend with another Athlete.
        /// </summary>
        public object friend { get; set; }

        /// <summary>
        /// States if the athlete is followed by another athlete.
        /// </summary>
        public object follower { get; set; }
    }
}
