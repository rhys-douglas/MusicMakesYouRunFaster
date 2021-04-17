namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;

    public class FitBitAuthControllerTests
    {
        FitBitAuthController sut;

        [OneTimeSetUp]
        public void SetUp()
        {
            sut = new FitBitAuthController();
        }

        [Test]
        public void GetExchangeToken_ExchangeTokenIsValid()
        {
            var exchangeTokenRequest = new DTO.Request.FitBitExchangeTokenRequest
            {
                client_id = 1234567,
                redirect_uri = new System.Uri("localhost:5000/callback"),
                scope = "activity",
                response_type = "code"
            };
            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.Code.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetExchangeTokenWithInvalidClientID_InvalidExchangeTokenReturned()
        {
            var exchangeTokenRequest = new DTO.Request.FitBitExchangeTokenRequest
            {
                client_id = null,
                redirect_uri = new System.Uri("localhost:5000/callback"),
                scope = "activity",
                response_type = "code"
            };

            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.Code.Should().BeNull();
        }

        [Test]
        public void GetExchangeTokenWithInvalidResponseType_InvalidExchangeTokenReturned()
        {
            var exchangeTokenRequest = new DTO.Request.FitBitExchangeTokenRequest
            {
                client_id = 1234567,
                response_type = null,
                redirect_uri = new System.Uri("localhost:5000/callback"),
                scope = "activity"
            };

            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.Code.Should().BeNull();
        }

        [Test]
        public void GetExchangeTokenWithInvalidScope_InvalidExchangeTokenReturned()
        {
            var exchangeTokenRequest = new DTO.Request.FitBitExchangeTokenRequest
            {
                client_id = 1234567,
                response_type = "code",
                redirect_uri = new System.Uri("localhost:5000/callback"),
                scope = null
            };

            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.Code.Should().BeNull();
        }

        [Test]
        public void GetExchangeTokenWithInvalidRedirectUri_InvalidExchangeTokenReturned()
        {
            var exchangeTokenRequest = new DTO.Request.FitBitExchangeTokenRequest
            {
                client_id = 1234567,
                response_type = "code",
                redirect_uri = null,
                scope = "activity"
            };

            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.Code.Should().BeNull();
        }

        [Test]
        public void GetAccessTokenWithValidExchangeToken_AccessTokenReturned()
        {
            var exchangeTokenRequest = new DTO.Request.FitBitExchangeTokenRequest
            {
                client_id = 1234567,
                redirect_uri = new System.Uri("localhost:5000/callback"),
                scope = "activity",
                response_type = "code"
            };

            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.Code.Should().NotBeNullOrEmpty();

            var accessTokenRequest = new DTO.Request.FitBitAccessTokenRequest
            {
                client_id = 1234567,
                code = retrievedExchangeToken.Result.Code,
                grant_type = "authorization_code",
                redirect_uri = new System.Uri("localhost:5000/callback")
            };

            var retrievedAccessToken = sut.GetAccessToken(accessTokenRequest);
            retrievedAccessToken.Result.access_token.Should().NotBeNullOrEmpty();
            retrievedAccessToken.Result.refresh_token.Should().NotBeNullOrEmpty();
            retrievedAccessToken.Result.token_type.Should().Be("Bearer");
            retrievedAccessToken.Result.user_id.Should().Be("1234");
            retrievedAccessToken.Result.expires_in.Should().NotBe(null);
        }

        [Test]
        public void GetAccessTokenWithInvalidExchangeToken_InvalidAccessTokenReturned()
        {
            var exchangeTokenRequest = new DTO.Request.FitBitExchangeTokenRequest
            {
                client_id = 1234567,
                redirect_uri = new System.Uri("localhost:5000/callback"),
                scope = "activity",
                response_type = "code"
            };
            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.Code.Should().NotBeNullOrEmpty();

            var accessTokenRequest = new DTO.Request.FitBitAccessTokenRequest
            {
                client_id = 1234567,
                code = null,
                grant_type = "authorization_code",
                redirect_uri = new System.Uri("localhost:5000/callback")
            };


            var retrievedAccessToken = sut.GetAccessToken(accessTokenRequest);
            retrievedAccessToken.Result.access_token.Should().BeNull();
            retrievedAccessToken.Result.refresh_token.Should().BeNull();
            retrievedAccessToken.Result.token_type.Should().BeNull();
            retrievedAccessToken.Result.user_id.Should().BeNull();
            retrievedAccessToken.Result.expires_in.Should().BeNull();
        }
    }
}
