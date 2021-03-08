namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using ClientDrivers;
    using DataSource;
    using TechTalk.SpecFlow;

    [Binding]
    public class ComparisonSteps
    {
        private readonly IClientDriver clientDriver;
        private readonly DataPort dataSource;

        public ComparisonSteps(IClientDriver clientDriver, DataPort dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }

        [When(@"the comparison between running and listening history is made")]
        public void WhenTheComparsionBetweenRunningAndListeningHistoryIsMade()
        {
            clientDriver.MakeRunningAndListeningHistoryComparison();
        }

        [Then(@"the user's top tracks for running faster are produced")]
        public void ThenTheUsersTopTracksForRunningFasterAreProduced()
        {
            var results = clientDriver.GetFastestTracks();
        }
    }
}
