namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Moq.Protected;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;

    public class ExternalAPICallerTests
    {
        private HttpClient mockHttpClient;
        private Mock<HttpMessageHandler> mockHttpMessageHandler;

        private class FakeContext
        {
            [FromQuery(Name = "href")]
            public string Href { get; set; } = default!;

            /// <summary>
            /// Type of the associated item
            /// </summary>
            [FromQuery(Name = "type")]
            public string Type { get; set; } = default!;

            /// <summary>
            /// Uri of the associated item.
            /// </summary>
            [FromQuery(Name = "uri")]
            public string Uri { get; set; } = default!;
        }

        [SetUp]
        public void SetUp()
        {
            string responseContent = string.Empty;
            var jsonContent = JsonConvert.SerializeObject(responseContent);
            SetUpHTTPClient(HttpStatusCode.OK, jsonContent);
        }

        [Test]
        public void ExternalAPICallerCreatedWithCorrectInputs_SpotifyClientIsNotNull()
        {
            var sut = MakeSut(mockHttpClient);
            sut.Should().NotBeNull();
        }

        [Test]
        public void ExternalAPICallerGet_DataRetrieved()
        {
            var endpoint = new Uri("http://localhost/context");
            SetUpHTTPClient(HttpStatusCode.OK, "{\"href\": \"Some text\", \"type\": \"Some type\", \"uri\": 12345678}");
            var response = MakeSut(mockHttpClient).Get<FakeContext>(endpoint);
            response.Should().NotBeNull();
            response.Href.Should().Be("Some text");
            response.Type.Should().Be("Some type");
            response.Uri.Should().Be("12345678");

            mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                    && req.RequestUri.Equals(new Uri("http://localhost/context"))),
                ItExpr.IsAny<CancellationToken>());

        }

        private ExternalAPICaller MakeSut(HttpClient httpClient)
        {
            return new ExternalAPICaller(httpClient);
        }

        private void SetUpHTTPClient(HttpStatusCode statusCode, string jsonContent)
        {
            var mockReturnContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()).ReturnsAsync(new HttpResponseMessage
                    {
                        StatusCode = statusCode,
                        Content = mockReturnContent
                    })
                .Verifiable();

            mockHttpClient = new HttpClient(mockHttpMessageHandler.Object);
        }
    }
}
