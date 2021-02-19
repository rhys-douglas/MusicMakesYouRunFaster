namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using DbContext;
    using System.Threading.Tasks;

    /// <summary>
    /// Fake spotify controller, which act as spotify's auth service.
    /// </summary>
    public class SpotifyAuthController : ControllerBase
    {
        private DataRetrievalContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpotifyAuthController"/> class.
        /// </summary>
        /// <param name="context">Database context </param>
        public SpotifyAuthController(DataRetrievalContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets a PKCE Auth Token
        /// </summary>
        /// <returns> A valid PKCE Auth Token </returns>
        public async Task<JsonResult> GetPKCEAuthToken()
        {

        }
    }
}
