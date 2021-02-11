namespace RD.CanMusicMakeYouRunFaster.Rest.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller used to handle HTTP requests to the backend / external API's.
    /// </summary>
    public class ExternalAPIController : ControllerBase
    {
        /// <summary>
        /// Gets the spotify OAuth Token.
        /// </summary>
        public JsonResult GetSpotifyOAuthToken()
        {
            // data source.spotify.getOAuthToken
        }
    }
}
