namespace RD.CanMusicMakeYouRunFaster.Rest.Entity
{
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Last FM Authentication Token, holding session information.
    /// </summary>

    [XmlRoot("session")]
    public class LastFMAuthenticationToken
    {
        /// <summary>
        /// Username of the user's session.
        /// </summary>
        [XmlElement("name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Session key.
        /// </summary>
        [XmlElement("session")]
        [JsonProperty("SessionKey")]
        public string SessionKey { get; set; }

        /// <summary>
        /// Is the user a subscriber?
        /// </summary>
        [XmlElement("subscriber")]
        [JsonProperty("Subscriber")]
        public int Subscriber { get; set; }
    }
}
