namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    /// <summary>
    /// Strava Auth controller
    /// </summary>
    [ApiController]
    public class StravaAuthController
    {
        /// <summary>
        /// Gets the exchange token for authentication.
        /// </summary>
        /// <param name="request"> Request parameters</param>
        /// <returns> A Strava Exchange token response</returns>
        [Route("/oauth/authorize")]
        [HttpGet]
        public async Task<DTO.StravaExchangeTokenResponse> GetExchangeToken([FromQuery] DTO.Request.ExchangeTokenRequest request)
        {
            await Task.Delay(0);
            if (request.client_id == null)
            {
                return new DTO.StravaExchangeTokenResponse();
            }

            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] buffer0 = new byte[100];
            rng.GetBytes(buffer0);
            var exchangeToken = Convert.ToBase64String(buffer0);
            return new DTO.StravaExchangeTokenResponse
            {
                code = exchangeToken,
                scope = request.scope,
                state = null
            };
        }

        /// <summary>
        /// Exchanges an exchange token for a request token.
        /// </summary>
        /// <param name="request"> Access token request parameters</param>
        /// <returns> A Strava Access Token</returns>
        [Route("/oauth/token")]
        public async Task<DTO.StravaAuthenticationTokenResponse> GetAccessToken([FromQuery] DTO.Request.AccessTokenRequest request)
        {
            if (request.code == null || request.client_id == null || request.client_secret == null)
            {
                return new DTO.StravaAuthenticationTokenResponse();
            }

            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] buffer0 = new byte[100];
            byte[] buffer1 = new byte[100];
            rng.GetBytes(buffer0);
            rng.GetBytes(buffer1);

            await Task.Delay(0);
            return new DTO.StravaAuthenticationTokenResponse
            {
                access_token = Convert.ToBase64String(buffer0),
                refresh_token = Convert.ToBase64String(buffer1),
                expires_at = 543773478,
                expires_in = 3600,
                token_type = "Bearer",
                athlete = new DTO.Athlete
                {
                    id = 123456789,
                    resource_state = 2
                }
            };
        }
    }
}
