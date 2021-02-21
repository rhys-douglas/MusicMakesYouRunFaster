namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using System.Net.Http;

    /// <summary>
    /// Fake spotify client, used for sending requests to the FakeResponse server.
    /// </summary>
    public class SpotifyClient
    {
        private HttpClient httpClient;

        public SpotifyClient(HttpClient httpClient, string FakeServerUrl)
        {

        }
    }
}
