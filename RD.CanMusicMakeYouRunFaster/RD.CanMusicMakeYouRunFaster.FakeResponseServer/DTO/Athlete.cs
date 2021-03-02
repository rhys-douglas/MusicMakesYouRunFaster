namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Athlete DTO
    /// </summary>
    public class Athlete
    {
        /// <summary>
        /// Athlete Id
        /// </summary>
        [JsonProperty("id")]
        public int id { get; set; }

        /// <summary>
        /// Athlete username
        /// </summary>
        [JsonProperty("username")]
        public string username { get; set; }

        /// <summary>
        /// Athlete resource_state
        /// </summary>
        [JsonProperty("resource_state")]
        public int resource_state { get; set; }

        /// <summary>
        /// Athlete first name.
        /// </summary>
        [JsonProperty("firstname")]
        public string firstname { get; set; }

        /// <summary>
        /// Athlete last name.
        /// </summary>
        [JsonProperty("lastname")]
        public string lastname { get; set; }

        /// <summary>
        /// Athlete city.
        /// </summary>
        [JsonProperty("city")]
        public string city { get; set; }

        /// <summary>
        /// Athlete state.
        /// </summary>
        [JsonProperty("state")]
        public string state { get; set; }

        /// <summary>
        /// Athlete country
        /// </summary>
        [JsonProperty("country")]
        public object country { get; set; }

        /// <summary>
        /// Athlete sex
        /// </summary>
        [JsonProperty("sex")]
        public string sex { get; set; }

        /// <summary>
        /// Athlete premium user check
        /// </summary>
        [JsonProperty("premium")]
        public bool premium { get; set; }

        /// <summary>
        /// Athlete summit subscription?
        /// </summary>
        [JsonProperty("summit")]
        public bool summit { get; set; }

        /// <summary>
        /// Athlete date time of creation
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        /// <summary>
        /// Athlete time of last update.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }

        /// <summary>
        /// Type ID of the badge.
        /// </summary>
        [JsonProperty("bade_type_id")]
        public int badge_type_id { get; set; }

        /// <summary>
        /// Medium size profile picture URL.
        /// </summary>
        [JsonProperty("profile_medium")]
        public string profile_medium { get; set; }

        /// <summary>
        /// Profile URL.
        /// </summary>
        [JsonProperty("profile")]
        public string profile { get; set; }

        /// <summary>
        /// States if the athlete is a friend with another Athlete.
        /// </summary>
        [JsonProperty("friend")]
        public object friend { get; set; }

        /// <summary>
        /// States if the athlete is followed by another athlete.
        /// </summary>
        [JsonProperty("follower")]
        public object follower { get; set; }
    }
}
