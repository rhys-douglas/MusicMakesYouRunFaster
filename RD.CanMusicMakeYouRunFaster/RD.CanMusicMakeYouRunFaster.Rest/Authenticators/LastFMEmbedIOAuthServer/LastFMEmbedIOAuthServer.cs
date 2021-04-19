namespace RD.CanMusicMakeYouRunFaster.Rest.Authenticators.LastFMEmbedIOAuthServer
{
    using System.Reflection;
    using System.Threading;
    using System.Web;
    using System.Globalization;
    using System.Text;
    using System;
    using System.Threading.Tasks;
    using EmbedIO;
    using EmbedIO.Actions;
    using SpotifyAPI.Web.Auth;

    /// <summary>
    /// Last FM implementation of <see cref="IAuthServer"/>
    /// </summary>
    public class LastFMEmbedIOAuthServer
    {
        public event Func<object, AuthorizationCodeResponse, Task> AuthorizationCodeReceived;
        public event Func<object, ImplictGrantResponse, Task> ImplictGrantReceived;
        public event Func<object, string, string, Task> ErrorReceived;

        private const string AssetsResourcePath = "RD.CanMusicMakeYouRunFaster.Rest.Authenticators.LastFMEmbedIOAuthServer.Resources.auth_assets";
        private const string DefaultResourcePath = "RD.CanMusicMakeYouRunFaster.Rest.Authenticators.LastFMEmbedIOAuthServer.Resources.default_site";

        private CancellationTokenSource cancelTokenSource;
        private readonly WebServer webServer;

        public LastFMEmbedIOAuthServer(Uri baseUri, int port)
          : this(baseUri, port, Assembly.GetExecutingAssembly(), DefaultResourcePath) { }

        public LastFMEmbedIOAuthServer(Uri baseUri, int port, Assembly resourceAssembly, string resourcePath)
        {
            BaseUri = baseUri;
            Port = port;

            webServer = new WebServer(port)
              .WithModule(new ActionModule("/", HttpVerbs.Post, (ctx) =>
              {
                  var query = ctx.Request.QueryString;
                  var error = query["error"];
                  if (error != null)
                  {
                      ErrorReceived?.Invoke(this, error, query["state"]);
                      throw new AuthException(error, query["state"]);
                  }

                  var requestType = query.Get("request_type");
                  if (requestType == "token")
                  {
                      ImplictGrantReceived?.Invoke(this, new ImplictGrantResponse(
                  query["access_token"]!, query["token_type"]!, int.Parse(query["expires_in"]!)
                )
                      {
                          State = query["state"]
                      });
                  }
                  if (requestType == "code")
                  {
                      AuthorizationCodeReceived?.Invoke(this, new AuthorizationCodeResponse(query["code"]!)
                      {
                          State = query["state"]
                      });
                  }

                  return ctx.SendStringAsync("OK", "text/plain", Encoding.UTF8);
              }))
              .WithEmbeddedResources("/auth_assets", Assembly.GetExecutingAssembly(), AssetsResourcePath)
              .WithEmbeddedResources(baseUri.AbsolutePath, resourceAssembly, resourcePath);
        }

        public Uri BaseUri { get; }
        public int Port { get; }

        public Task Start()
        {
            cancelTokenSource = new CancellationTokenSource();
            webServer.Start(cancelTokenSource.Token);
            return Task.CompletedTask;
        }

        public Task Stop()
        {
            cancelTokenSource?.Cancel();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                webServer?.Dispose();
            }
        }
    }
}
