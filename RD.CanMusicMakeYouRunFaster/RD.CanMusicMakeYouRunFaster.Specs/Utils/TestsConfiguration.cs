namespace RD.CanMusicMakeYouRunFaster.Specs.Utils
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// TestsConfiguration class.
    /// </summary>
    public static class TestsConfiguration
    {
        /// <summary>
        /// Initializes static members of the <see cref="TestsConfiguration"/> class.
        /// </summary>
        static TestsConfiguration()
        {
            var config = BuildConfiguration();
            TestConfig = config.GetSection("TestConfig");
        }

        // See appsettings.Development.json for where the following values are assigned.

        /// <summary>
        /// Gets the test mode.
        /// </summary>
        public static string TestMode => GetEnvironmentValue("TestMode");

        private static IConfigurationSection TestConfig { get; }

        /// <summary>
        /// Builds the application Configuration.
        /// </summary>
        /// <returns>The application Configuration.</returns>
        public static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.Development.json", false, true);
            return builder.Build();
        }

        /// <summary>
        /// Used to get the values of environment parameters for testing. E.g Browser Width
        /// </summary>
        /// <param name="key"> The name stored in the environment to get the desired value from.</param>
        /// <returns>A value based on the parsed "key" </returns>
        private static string GetEnvironmentValue(string key)
        {
            var env = Environment.GetEnvironmentVariable(key);
            return env ?? TestConfig[key];
        }
    }
}
