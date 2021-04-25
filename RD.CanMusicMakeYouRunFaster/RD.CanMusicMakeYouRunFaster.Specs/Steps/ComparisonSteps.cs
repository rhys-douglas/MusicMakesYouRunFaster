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

        [When(@"the user's recently played history based on their running history is requested using multiple data sources")]
        public void WhenTheUsersRecentlyPlayedHistoryBasedOnTheirRunningHistoryIsRequestedUsingMultipleDataSources()
        {
            clientDriver.GetRecentlyPlayedMusicForActivitiesWithMultipleSources();
        }

        [When(@"the comparison between running and listening history is made using a specified date range")]
        public void WhenTheComparsionBetweenRunningAndListeningHistoryIsMadeWithASpecifiedDateRange()
        {
            var startDate = new DateTime(2021, 03, 13);
            var endDate = new DateTime(2021, 03, 15);
            clientDriver.MakeRunningAndListeningHistoryComparisonWithDateRange(startDate, endDate);
        }

        [Then(@"the user's top tracks for running faster are produced")]
        public void ThenTheUsersTopTracksForRunningFasterAreProduced(Table table)
        {
            var resultAsDictionary = clientDriver.GetFastestTracks();
            var resultAsSinglePair = resultAsDictionary.First();
            resultAsSinglePair.Should().NotBeNull();
            var listOfSongNames = new List<string>();
            foreach (var item in resultAsSinglePair.Value)
            {
                listOfSongNames.Add(item.Track.Name);
            }

            var listOfExpectedSongNames = new List<string>();
            foreach(var item in table.Rows)
            {
                listOfExpectedSongNames.Add(item[0]);
            }
            listOfSongNames.Should().BeEquivalentTo(listOfExpectedSongNames);
        }
    }
}
