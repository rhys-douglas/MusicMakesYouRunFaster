namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using System;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Fake spotify controller, which act as spotify's auth service.
    /// </summary>
    [ApiController]
    [Route("/authorize")]
    public class SpotifyAuthController : ControllerBase
    {
        /// <summary>
        /// Gets a PKCE Auth Token
        /// </summary>
        /// <returns> A valid PKCE Auth Token </returns>
        [HttpGet]
        public async Task<DTO.PKCETokenResponse> GetPKCEAuthToken([FromQuery] DTO.Request.PKCETokenRequest request)
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

            await Task.Delay(0);

            return TokenResponse;
        }
    }
}
