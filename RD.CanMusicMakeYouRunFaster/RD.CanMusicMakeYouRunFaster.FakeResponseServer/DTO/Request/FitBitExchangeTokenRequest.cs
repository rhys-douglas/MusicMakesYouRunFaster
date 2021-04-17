namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO.Request
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    /// <summary>
    /// FitBit Exchange Token Request object.
    /// </summary>
    public class FitBitExchangeTokenRequest
    {
        /// <summary>
        /// ClientID
        /// </summary>
        [FromQuery(Name = "client_id")]
        public string client_id { get; set; }

        /// <summary>
        /// Type of response (usually "code").
        /// </summary>
        [FromQuery(Name = "response_type")]
        public string response_type { get; set; }

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
