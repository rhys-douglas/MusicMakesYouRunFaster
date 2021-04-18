namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO.Request
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    /// <summary>
    /// Class for holding FitBit Access Token request parameters.
    /// </summary>
    public class FitBitAccessTokenRequest
    {
        /// <summary>
        /// Exchange token to use.
        /// </summary>
        [FromQuery(Name = "code")]
        public string code { get; set; }

        /// <summary>
        /// Client ID.
        /// </summary>
        [FromQuery(Name = "client_id")]
        public string client_id { get; set; }


        /// <summary>
        /// Grant type (e.g. authorization_code).
        /// </summary>
        [FromQuery(Name = "grant_type")]
        public string grant_type { get; set; }

        /// <summary>
        /// Redirect uri.
        /// </summary>
        [FromQuery(Name = "redirect_uri")]
        public Uri redirect_uri { get; set; }
    }
}
