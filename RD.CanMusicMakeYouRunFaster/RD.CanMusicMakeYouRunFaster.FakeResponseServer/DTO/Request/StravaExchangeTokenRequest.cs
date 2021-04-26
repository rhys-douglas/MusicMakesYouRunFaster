namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO.Request
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class StravaExchangeTokenRequest
    {
        /// <summary>
        /// ClientID
        /// </summary>
        [FromQuery(Name = "client_id")]
        public int? client_id { get; set; }

        /// <summary>
        /// Type of response.
        /// </summary>
        [FromQuery(Name = "response_type")]
        public string response_type { get; set; }

        /// <summary>
        /// Approval prompt required?
        /// </summary>
        [FromQuery(Name = "approval_prompt")]
        public string approval_prompt { get; set; }

        /// <summary>
        /// Scope of the request
        /// </summary>
        [FromQuery(Name = "scope")]
        public string scope { get; set; }

        /// <summary>
        /// Redirect uri.
        /// </summary>
        [FromQuery(Name = "redirect_uri")]
        public Uri redirect_uri { get; set; }
    }
}
