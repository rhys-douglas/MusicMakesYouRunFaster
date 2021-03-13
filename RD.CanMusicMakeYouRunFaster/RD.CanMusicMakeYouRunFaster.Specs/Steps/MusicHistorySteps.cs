namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using ClientDrivers;
    using DataSource;
    using FluentAssertions;
    using NUnit.Framework;
    using SpotifyAPI.Web;
    using System.Collections.Generic;
    using System.Linq;
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
            var acquiredItems = clientDriver.GetFoundItems();
            var actualListeningHistory = new List<PlayHistoryItem>();

            foreach (var item in acquiredItems)
            {
                if (item is PlayHistoryItem song)
                {
                    actualListeningHistory.Add(song);
                }
            }

            actualListeningHistory.Should().HaveCount(5);
            actualListeningHistory[0].Track.Name.Should().Be("The Chain - 2004 Remaster");
            actualListeningHistory[1].Track.Name.Should().Be("I Want To Break Free - Single Remix");
            actualListeningHistory[2].Track.Name.Should().Be("Good Vibrations - Remastered");
            actualListeningHistory[3].Track.Name.Should().Be("Dreams - 2004 Remaster");
            actualListeningHistory[4].Track.Name.Should().Be("Stayin Alive");
        }
    }
}
