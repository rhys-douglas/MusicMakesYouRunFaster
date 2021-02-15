namespace RD.CanMusicMakeYouRunFaster.Specs
{
    using System;
    using System.Threading;
    using BoDi;
    using ClientDrivers;
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
            clientDriver = new ApiClientDriver();
            clientDriver.SetUp();
            objectContainer.RegisterInstanceAs<IClientDriver>(clientDriver);
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}
