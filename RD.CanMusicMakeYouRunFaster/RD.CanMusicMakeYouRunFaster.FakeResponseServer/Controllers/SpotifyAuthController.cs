namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using System;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using DbContext;
    using Microsoft.AspNetCore.Mvc;
    using SpotifyAPI.Web;
    

    /// <summary>
    /// Fake spotify controller, which act as spotify's auth service.
    /// </summary>
    [ApiController]
    public class SpotifyAuthController : ControllerBase
    {
        private readonly DataRetrievalContext context;

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
        public async Task<DTO.PKCETokenResponse> GetPKCEAuthToken(PKCETokenRequest request)
        {
            if (request == null)
            {
                throw new System.Exception("Token request is null.");
            }

            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] buffer0 = new byte[100];
            byte[] buffer1 = new byte[100];
            rng.GetBytes(buffer0);
            string accessToken = Convert.ToBase64String(buffer0);
            rng.GetBytes(buffer1);
            string refreshToken = Convert.ToBase64String(buffer1);


            var TokenResponse = new DTO.PKCETokenResponse
            {
                AccessToken = accessToken,
                CreatedAt = DateTime.UtcNow,
                ExpiresIn = 3600,
                RefreshToken = refreshToken,
                Scope = "UserReadPrivate, UserReadRecentlyPlayed",
                TokenType = "Bearer"
            };

            await Task.Delay(1);

            return TokenResponse;
        }
    }
}
