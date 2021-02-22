namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Net.Http;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;
    using SpotifyAPI.Web;
    using System.Web;

    /// <summary>
    /// Fake data source used for tests.
    /// </summary>
    public class FakeDataRetrievalSource : IDataRetrievalSource
    {
        private readonly FakeResponseServer.Controllers.SpotifyClient spotifyClient;
        private readonly Uri fakeSpotifyAuthUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDataRetrievalSource"/> class.
        /// </summary>
        public FakeDataRetrievalSource(FakeResponseServer.Controllers.SpotifyClient spotifyClient, string fakeServerUrl)
        {
            this.spotifyClient = spotifyClient;
            this.fakeSpotifyAuthUrl = new Uri(fakeServerUrl);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyAuthenticationToken()
        {
            var (challenge, verifier) = PKCEUtil.GenerateCodes();
            await Task.Delay(1);
            FakeResponseServer.DTO.Request.PKCETokenRequest tokenRequest = new FakeResponseServer.DTO.Request.PKCETokenRequest
            {
                ClientId = "Some client id",
                Code = "200",
                CodeVerifier = verifier,
                RedirectUri = new Uri("http://localhost:2000/callback/")
            };
            var builder = new UriBuilder(fakeSpotifyAuthUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["ClientId"] = tokenRequest.ClientId;
            query["Code"] = tokenRequest.Code;
            query["CodeVerifier"] = tokenRequest.CodeVerifier;
            query["RedirectUri"] = tokenRequest.RedirectUri.ToString();
            builder.Query = query.ToString();
            var authTokenResponse = spotifyClient.Get<SpotifyAuthenticationToken>(new Uri("http://localhost:2222/authorize?ClientId=Some+client+id&Code=200&CodeVerifier=KmS_2IQWRizX1bXF5G508LjlbdO2P9432WFf7gKEfD4&RedirectUri=http%3a%2f%2flocalhost%3a2000%2fcallback%2f"));
            return new JsonResult(authTokenResponse);

        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyRecentlyPlayed(SpotifyAuthenticationToken authToken)
        {
            // gets something
            var musicHistory = "";

            await Task.Run(() =>
            {
                musicHistory = JsonConvert.SerializeObject("Yayeet");
            });

            return new JsonResult(musicHistory);
        }
    }
}
