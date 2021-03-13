namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using ClientDrivers;
    using DataSource;
    using FluentAssertions;
    using NUnit.Framework;
    using SpotifyAPI.Web;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        [When(@"the user's recently played history based on their running history is requested")]
        public void WhenTheUsersRecentlyPlayedHistoryBasedOnTheirRunningHistoryIsRequested()
        {
            clientDriver.GetRecentlyPlayedMusicForActivities();
        }

        [Then(@"the user's top tracks for running faster are produced")]
        public void ThenTheUsersTopTracksForRunningFasterAreProduced()
        {
            var resultAsDictionary = clientDriver.GetFastestTracks();
            var resultAsSinglePair = resultAsDictionary.First();
            resultAsSinglePair.Should().NotBeNull();
            resultAsSinglePair.Key.name.Should().Be("Cardiff Friday Morning Run");
            resultAsSinglePair.Key.average_speed.Should().Be(4.5);
            resultAsSinglePair.Value.Count.Should().Be(5);
            resultAsSinglePair.Value.First().Track.Name.Should().Be("The Chain - 2004 Remaster");
        }
    }
}
