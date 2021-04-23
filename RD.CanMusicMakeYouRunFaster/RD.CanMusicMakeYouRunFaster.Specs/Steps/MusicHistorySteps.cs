namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using ClientDrivers;
    using DataSource;
    using FluentAssertions;
    using IF.Lastfm.Core.Objects;
    using NUnit.Framework;
    using SpotifyAPI.Web;
    using System.Collections.Generic;
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

        [Given(@"their Spotify listening history")]
        public void GivenTheirSpotifyListeningHistory()
        {
            // Do nothing.
        }

        [Given(@"their Last\.FM listening history")]
        public void GivenTheirLast_FMListeningHistory()
        {
            // Do nothing.
        }


        [When(@"the user's Spotify recently played history is requested")]
        public void WhenTheUsersSpotifyRecentlyPlayedHistoryIsRequested()
        {
            clientDriver.GetSpotifyRecentlyPlayedMusic();
        }

        [When(@"the user's Last.FM recently played history is requested")]
        public void WhenTheUsersLastFMRecentlyPlayedHistoryIsRequested()
        {
            clientDriver.GetLastFMRecentlyPlayedMusic();
        }

        [Then(@"the user's Last\.FM recently played history is produced")]
        public void ThenTheUsersLast_FMRecentlyPlayedHistoryIsProduced()
        {
            var acquiredItems = clientDriver.GetFoundItems();
            var actualListeningHistory = new List<LastTrack>();

            foreach (var item in acquiredItems)
            {
                if (item is LastTrack song)
                {
                    actualListeningHistory.Add(song);
                }
            }

            actualListeningHistory.Should().HaveCount(5);
            actualListeningHistory[0].Name.Should().Be("The Chain - 2004 Remaster");
            actualListeningHistory[1].Name.Should().Be("I Want To Break Free - Single Remix");
            actualListeningHistory[2].Name.Should().Be("Good Vibrations - Remastered");
            actualListeningHistory[3].Name.Should().Be("Dreams - 2004 Remaster");
            actualListeningHistory[4].Name.Should().Be("Stayin Alive");
        }

        [Then(@"the user's Spotify recently played history is produced")]
        public void ThenTheUsersSpotifyRecentlyPlayedHistoryIsProduced()
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
