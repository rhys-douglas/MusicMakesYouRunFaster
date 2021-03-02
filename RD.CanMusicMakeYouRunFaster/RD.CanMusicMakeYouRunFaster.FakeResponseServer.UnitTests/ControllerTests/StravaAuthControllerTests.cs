namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;

    public class StravaAuthControllerTests
    {
        private const string ClientId = "1580ff80db9a43e589eee411deba30b0";
        StravaAuthController sut;

        [OneTimeSetUp]
        public void SetUp()
        {
            sut = new StravaAuthController();
        }

        [Test]
        public void GetExchangeToken_ExchangeTokenIsValid()
        {
            var exchangeTokenRequest = new DTO.Request.ExchangeTokenRequest
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
            var exchangeTokenRequest = new DTO.Request.ExchangeTokenRequest
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
    }
}
