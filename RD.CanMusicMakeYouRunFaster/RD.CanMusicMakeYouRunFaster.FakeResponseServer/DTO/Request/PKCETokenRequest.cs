using Microsoft.AspNetCore.Mvc;
using System;

namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO.Request
{
    /// <summary>
    /// PKCE Token request class.
    /// </summary>
    public class PKCETokenRequest
    {
        /// <summary>
        /// ClientID
        /// </summary>
        [FromQuery(Name = "ClientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// Code verifier
        /// </summary>
        [FromQuery(Name = "CodeVerifier")]
        public string CodeVerifier { get; set; }

        /// <summary>
        /// Response code
        /// </summary>
        [FromQuery(Name = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// Redirect uri.
        /// </summary>
        [FromQuery(Name = "RedirectUri")]
        public Uri RedirectUri { get; set; }
    }
}
