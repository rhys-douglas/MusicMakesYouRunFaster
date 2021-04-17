namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;

    public class StravaAuthControllerTests
    {
        StravaAuthController sut;

        [OneTimeSetUp]
        public void SetUp()
        {
            sut = new StravaAuthController();
        }

        [Test]
        public void GetExchangeToken_ExchangeTokenIsValid()
        {
            var exchangeTokenRequest = new DTO.Request.StravaExchangeTokenRequest
            {
                client_id = 1234567,
                approval_prompt = "force",
                redirect_uri = new System.Uri("localhost:5000/callback"),
                scope = "read,activity:read_all",
                response_type = "code"
            };
            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.code.Should().NotBeNullOrEmpty();
            retrievedExchangeToken.Result.scope.Should().Be(exchangeTokenRequest.scope);
            retrievedExchangeToken.Result.state.Should().Be(null);
        }

        [Test]
        public void GetExchangeTokenWithInvalidClientID_InvalidExchangeTokenReturned()
        {
            var exchangeTokenRequest = new DTO.Request.StravaExchangeTokenRequest
            {
                client_id = null,
                approval_prompt = "force",
                redirect_uri = new System.Uri("localhost:5000/callback"),
                scope = "read,activity:read_all",
                response_type = "code"
            };
            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.code.Should().BeNull();
            retrievedExchangeToken.Result.scope.Should().BeNull();
            retrievedExchangeToken.Result.state.Should().BeNull();
        }

        [Test]
        public void GetAccessTokenWithValidExchangeToken_AccessTokenReturned()
        {
            var exchangeTokenRequest = new DTO.Request.StravaExchangeTokenRequest
            {
                client_id = 1234567,
                approval_prompt = "force",
                redirect_uri = new System.Uri("localhost:5000/callback"),
                scope = "read,activity:read_all",
                response_type = "code"
            };
            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.code.Should().NotBeNullOrEmpty();
            retrievedExchangeToken.Result.scope.Should().Be(exchangeTokenRequest.scope);
            retrievedExchangeToken.Result.state.Should().Be(null);

            var accessTokenRequest = new DTO.Request.StravaAccessTokenRequest
            {
                client_id = 1234567,
                client_secret = "something",
                code = retrievedExchangeToken.Result.code,
                grant_type = "authorization_code"
            };

            var retrievedAccessToken = sut.GetAccessToken(accessTokenRequest);
            retrievedAccessToken.Result.access_token.Should().NotBeNullOrEmpty();
            retrievedAccessToken.Result.refresh_token.Should().NotBeNullOrEmpty();
            retrievedAccessToken.Result.token_type.Should().Be("Bearer");
            retrievedAccessToken.Result.athlete.Should().NotBeNull();
            retrievedAccessToken.Result.expires_at.Should().NotBe(null);
            retrievedAccessToken.Result.expires_in.Should().NotBe(null);
        }

        [Test]
        public void GetAccessTokenWithInvalidExchangeToken_InvalidAccessTokenReturned()
        {
            var exchangeTokenRequest = new DTO.Request.StravaExchangeTokenRequest
            {
                client_id = 1234567,
                approval_prompt = "force",
                redirect_uri = new System.Uri("localhost:5000/callback"),
                scope = "read,activity:read_all",
                response_type = "code"
            };
            var retrievedExchangeToken = sut.GetExchangeToken(exchangeTokenRequest);
            retrievedExchangeToken.Result.code.Should().NotBeNullOrEmpty();
            retrievedExchangeToken.Result.scope.Should().Be(exchangeTokenRequest.scope);
            retrievedExchangeToken.Result.state.Should().Be(null);

            var accessTokenRequest = new DTO.Request.StravaAccessTokenRequest
            {
                client_id = 1234567,
                client_secret = "something",
                code = null,
                grant_type = "authorization_code"
            };

            var retrievedAccessToken = sut.GetAccessToken(accessTokenRequest);
            retrievedAccessToken.Result.access_token.Should().BeNull();
            retrievedAccessToken.Result.refresh_token.Should().BeNull();
            retrievedAccessToken.Result.token_type.Should().BeNull();
            retrievedAccessToken.Result.athlete.Should().BeNull();
            retrievedAccessToken.Result.expires_at.Should().BeNull();
            retrievedAccessToken.Result.expires_in.Should().BeNull();
        }
    }
}
