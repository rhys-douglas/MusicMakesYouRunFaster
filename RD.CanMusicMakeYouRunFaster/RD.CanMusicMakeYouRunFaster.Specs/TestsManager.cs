namespace RD.CanMusicMakeYouRunFaster.Specs
{
    using System;
    using System.Threading;
    using BoDi;
    using RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers;
    using RD.CanMusicMakeYouRunFaster.Specs.Utils;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class to set up, tear down and manage specs tests.
    /// </summary>
    [Binding]
    public class TestsManager
    {
        private static IClientDriver clientDriver;

        /// <summary>
        /// Set up precursors to testing.
        /// </summary>
        /// <param name="objectContainer"> Object container </param>
        [BeforeTestRun]
        public static void TestSetup(IObjectContainer objectContainer)
        {
            switch (TestsConfiguration.TestMode)
            {
                case "API":
                    clientDriver = new ApiClientDriver();
                    break;
                default:
                    throw new Exception("Invalid Test Mode");
            }

            clientDriver.SetUp();
            objectContainer.RegisterInstanceAs(clientDriver);
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}
