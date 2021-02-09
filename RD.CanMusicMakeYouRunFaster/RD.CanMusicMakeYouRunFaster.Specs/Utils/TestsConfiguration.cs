namespace RD.CanMusicMakeYouRunFaster.Specs.Utils
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// TestsConfiguration class.
    /// </summary>
    public class TestsConfiguration
    {
        static TestsConfiguration()
        {
            var config = BuildConfiguration();
            TestConfig = config.GetSection("TestConfig");
        }

        /// <summary>
        /// Gets the Test Mode
        /// </summary>
        public static string TestMode => GetEnvironmentValue("TestMode");

        /// <summary>
        /// Gets the Test Configuration.
        /// </summary>
        private static IConfigurationSection TestConfig { get; }

        /// <summary>
        /// Builds the application Configuration.
        /// </summary>
        /// <returns>The application Configuration.</returns>
        public static IConfiguration BuildConfiguration()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile("specsConfig.json", false, true);
            return configBuilder.Build();
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
