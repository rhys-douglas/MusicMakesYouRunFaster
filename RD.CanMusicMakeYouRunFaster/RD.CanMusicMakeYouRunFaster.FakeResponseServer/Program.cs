namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Starts the FakeResponseServer.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Called on program startup. The Web API is created and started.
        /// </summary>
        /// <param name="args"> CLI arguments </param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a HostBuilder.
        /// </summary>
        /// <param name="args"> CLI arguments from Main()</param>
        /// <returns>The builder used to build the fake response API.</returns>
        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
