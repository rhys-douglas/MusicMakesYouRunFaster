namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using ClientDrivers;
    using DataSource;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class MusicHistorySteps
    {
        private readonly IClientDriver clientDriver;
        private readonly DataPort dataSource;

        public MusicHistorySteps(IClientDriver clientDriver, DataPort dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }

        [Given(@"their listening history")]
        public void GivenTheirListeningHistory()
        {
            // Do something
        }

        [When(@"the user's recently played history is requested")]
        public void WhenTheUserSRecentlyPlayedHistoryIsRequested()
        {
            clientDriver.GetRecentlyPlayedMusic();
        }

        [Then(@"the user's recently played history is produced")]
        public void ThenTheUserSRecentlyPlayedHistoryIsProduced()
        {
            var acquiredListeningHistory = clientDriver.GetFoundItems();

            // need to read in table and compare.
            // acquiredListeningHistory.Should().BeEquivalentTo(listeningHistory);
            Assert.Fail();
        }
    }
}
