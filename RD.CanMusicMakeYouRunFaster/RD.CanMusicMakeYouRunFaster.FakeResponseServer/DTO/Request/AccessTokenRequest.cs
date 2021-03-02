namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO.Request
{
    using Microsoft.AspNetCore.Mvc;

    public class AccessTokenRequest
    {
        /// <summary>
        /// Client ID.
        /// </summary>
        [FromQuery(Name = "client_id")]
        public int? client_id { get; set; }

        /// <summary>
        /// Client secret 
        /// </summary>
        [FromQuery(Name = "client_secret")]
        public string client_secret { get; set; }

        /// <summary>
        /// Exchange token to use.
        /// </summary>
        [FromQuery(Name = "code")]
        public string code { get; set; }

        /// <summary>
        /// Grant type (e.g. authorization_code).
        /// </summary>
        [FromQuery(Name = "grant_type")]
        public string grant_type { get; set; }
    }
}
