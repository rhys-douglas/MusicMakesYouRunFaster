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
    }
}
