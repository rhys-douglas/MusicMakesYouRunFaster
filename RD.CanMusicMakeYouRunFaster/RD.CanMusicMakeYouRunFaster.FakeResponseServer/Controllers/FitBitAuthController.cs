namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    /// <summary>
    /// FitBit Auth controller
    /// </summary>
    [ApiController]
    public class FitBitAuthController: ControllerBase
    {
        /// <summary>
        /// Gets the exchange token for authentication.
        /// </summary>
        /// <param name="request"> Request parameters</param>
        /// <returns> A FitBit Exchange token response</returns>
        [HttpGet]
        [Route("/oauth2/authorize")]
        public async Task<DTO.FitBitExchangeTokenResponse> GetExchangeToken([FromQuery] DTO.Request.FitBitExchangeTokenRequest request)
        {
            await Task.Delay(0);
            if (request.client_id == null || request.response_type == null || request.scope == null || request.redirect_uri == null)
            {
                return new DTO.FitBitExchangeTokenResponse();
            }

            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] buffer0 = new byte[100];
            rng.GetBytes(buffer0);
            var exchangeToken = Convert.ToBase64String(buffer0);
            return new DTO.FitBitExchangeTokenResponse
            {
                Code = exchangeToken,
            };
        }

        /// <summary>
        /// Exchanges an exchange token for a request token.
        /// </summary>
        /// <param name="request"> Access token request parameters</param>
        /// <returns> A FitBit Access Token</returns>
        [Route("/oauth2/token")]
        [HttpGet]
        public async Task<DTO.FitBitAuthenticationTokenResponse> GetAccessToken([FromQuery] DTO.Request.FitBitAccessTokenRequest request)
        {
            if (request.code == null || request.grant_type == null || request.redirect_uri == null)
            {
                return new DTO.FitBitAuthenticationTokenResponse();
            }

            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] buffer0 = new byte[100];
            byte[] buffer1 = new byte[100];
            rng.GetBytes(buffer0);
            rng.GetBytes(buffer1);

            await Task.Delay(0);
            return new DTO.FitBitAuthenticationTokenResponse
            {
                access_token = Convert.ToBase64String(buffer0),
                refresh_token = Convert.ToBase64String(buffer1),
                expires_in = 3600,
                token_type = "Bearer",
                user_id = "1234"
            };
        }
    }
}
