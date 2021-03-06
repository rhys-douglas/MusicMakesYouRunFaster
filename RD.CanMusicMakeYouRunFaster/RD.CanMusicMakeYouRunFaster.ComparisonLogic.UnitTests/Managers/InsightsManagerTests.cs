namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.UnitTests.Managers
{
    using System.Collections.Generic;
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.ComparisonLogic.Managers;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using SpotifyAPI.Web;

    public class InsightsManagerTests
    {
        private InsightsManager sut;

        [Test]
        public void GetFastestActivitySongs_FastestActivitySongsReturned()
        {
            var activity1 = new Activity
            {

            };
            var listOfActivity1PlayHistory = new List<PlayHistoryItem>
            {
                new PlayHistoryItem
                {

                }
            };

            var activity2 = new Activity
            {

            };

            var listOfActivity2PlayHistory = new List<PlayHistoryItem>
            {
                new PlayHistoryItem
                {

                }
            };
            var sampleData = new Dictionary<Activity, List<PlayHistoryItem>>
            {
                { activity1, listOfActivity1PlayHistory },
                { activity2, listOfActivity2PlayHistory }
            };
            sut = new InsightsManager();
            var result = sut.GetFastestActivityWithListeningHistory(sampleData);

        }
    }
}
