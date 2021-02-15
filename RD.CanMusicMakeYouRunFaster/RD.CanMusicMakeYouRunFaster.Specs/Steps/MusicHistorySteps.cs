namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using System.Collections.Generic;
    using FluentAssertions;
    using RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers;
    using TechTalk.SpecFlow;

    [Binding]
    public class MusicHistorySteps
    {
        private readonly IClientDriver clientDriver;

        public MusicHistorySteps(IClientDriver clientDriver)
        {
            this.clientDriver = clientDriver;
        }

        [Given(@"a list of users")]
        public void GivenAListOfUsers(Table table)
        {
            // Does something with users.
        }

        [Given(@"a user [""]?([^""]*)[""]?")]
        public void GivenAUser(string user)
        {
            // Does something
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
            var actualListeningHistory = new List<Dictionary<string, string>>();

            acquiredListeningHistory.Should().BeEquivalentTo(actualListeningHistory);
        }
    }
}
