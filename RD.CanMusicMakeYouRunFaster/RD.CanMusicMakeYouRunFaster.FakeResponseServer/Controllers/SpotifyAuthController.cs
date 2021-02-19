namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using DbContext;
    using System.Threading.Tasks;
    using SpotifyAPI.Web;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Fake spotify controller, which act as spotify's auth service.
    /// </summary>
    [ApiController]
    public class SpotifyAuthController : ControllerBase
    {
        private DataRetrievalContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpotifyAuthController"/> class.
        /// </summary>
        /// <param name="context">Database context </param>
        public SpotifyAuthController(DataRetrievalContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets a PKCE Auth Token
        /// </summary>
        /// <returns> A valid PKCE Auth Token </returns>
        public async Task<PKCETokenResponse> GetPKCEAuthToken(PKCETokenRequest request)
        {
            if (request == null)
            {
                throw new System.Exception("Token request is null.");
            }

            var TokenResponse = new PKCETokenResponse
            {
                AccessToken = "",
                CreatedAt = DateTime.Now,
                ExpiresIn = 3600,
                RefreshToken = "other random string",
                Scope = scopes,
                TokenType = "Bearer"
            };

            return TokenResponse;
        }
    }
}
