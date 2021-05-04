namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.DataRetrievalSourcesTests
{
    using DataRetrievalSources;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using SpotifyAPI.Web;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RealDataRetrievalSourceTests
    {
        private SpotifyAuthenticationToken spotifyAuthenticationToken;
        private StravaAuthenticationToken stravaAuthenticationToken;
        private FitBitAuthenticationToken fitBitAuthenticationToken;
        private RealDataRetrievalSource sut;

        [OneTimeSetUp]
        public void SetUpTests()
        {
            sut = new RealDataRetrievalSource();
        }

        [Test]
        public void GetSpotifyListeningHistory_ListeningHistoryRetrieved()
        {
            // Get spotify auth token
            var spotifyTokenAsJson = sut.GetSpotifyAuthenticationToken();
            spotifyTokenAsJson.Result.Should().NotBeNull();
            spotifyTokenAsJson.Result.Value.Should().NotBe(string.Empty);
            spotifyAuthenticationToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)spotifyTokenAsJson.Result.Value);
            spotifyAuthenticationToken.AccessToken.Should().NotBeNullOrEmpty();

            // Get listening history
            var listeningHistory = sut.GetSpotifyRecentlyPlayed(spotifyAuthenticationToken);
            listeningHistory.Result.Value.Should().NotBeNull();
            listeningHistory.Result.Value.Should().NotBe(string.Empty);
        }

        [Test]
        public void GetSpotifyListeningHistoryWithAfterParameter_CorrectListeningHistoryReturned()
        {
            // Get spotify auth token
            var spotifyTokenAsJson = sut.GetSpotifyAuthenticationToken();
            spotifyTokenAsJson.Result.Should().NotBeNull();
            spotifyTokenAsJson.Result.Value.Should().NotBe(string.Empty);
            spotifyAuthenticationToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)spotifyTokenAsJson.Result.Value);
            spotifyAuthenticationToken.AccessToken.Should().NotBeNullOrEmpty();

            // Get listening history with after parameter
            var listeningHistory0Task = sut.GetSpotifyRecentlyPlayed(spotifyAuthenticationToken);
            var listeningHistory0Json = JsonConvert.SerializeObject(listeningHistory0Task.Result.Value);
            var listeningHistory0 = JsonConvert.DeserializeObject<CursorPaging<PlayHistoryItem>>(listeningHistory0Json);
            listeningHistory0.Items.Should().NotBeNull();

            var nowMinus7Days = DateTime.UtcNow.AddHours(-5);
            var after = ((DateTimeOffset)nowMinus7Days).ToUnixTimeMilliseconds();
            var listeningHistory1Task = sut.GetSpotifyRecentlyPlayed(spotifyAuthenticationToken, after);
            var listeningHistory1Json = JsonConvert.SerializeObject(listeningHistory1Task.Result.Value);
            var listeningHistory1 = JsonConvert.DeserializeObject<CursorPaging<PlayHistoryItem>>(listeningHistory1Json);
            listeningHistory1.Items.Should().NotBeNull();
            listeningHistory1.Items.Should().NotBeEquivalentTo(listeningHistory0.Items);
        }

        [Test]
        public void GetLastFMListeningHistoryWithAfterParam_ListeningHistoryRetrieved()
        {
            var now = DateTime.UtcNow;
            now = now.AddDays(-7);
            // Get listening history
            var listeningHistory = sut.GetLastFMRecentlyPlayed("TheRealDougie1",now);
            listeningHistory.Result.Value.Should().NotBeNull();
            listeningHistory.Result.Value.Should().NotBe(string.Empty);
        }

        [Test]
        public void GetStravaRecentActivities_RunningActivitiesRetrieved()
        {
            // Get Strava Token
            var stravaTokenAsJson = sut.GetStravaAuthenticationToken();
            stravaTokenAsJson.Result.Should().NotBeNull();
            stravaTokenAsJson.Result.Value.Should().NotBe(string.Empty);
            stravaAuthenticationToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>((string)stravaTokenAsJson.Result.Value);
            stravaAuthenticationToken.access_token.Should().NotBeNullOrEmpty();

            // Get activities
            var runningHistory = sut.GetStravaActivityHistory(stravaAuthenticationToken);
            runningHistory.Result.Value.Should().NotBeNull();
            runningHistory.Result.Value.Should().NotBe(string.Empty);
            List<StravaActivity> retrievedActivites = (List<StravaActivity>)runningHistory.Result.Value;
            retrievedActivites.Should().NotBeEmpty().And.Should().NotBeNull();
            foreach( var activity in retrievedActivites)
            {
                activity.type.Should().Be("Run");
            }
        }

        [Test]
        public void GetFitBitRecentActivities_RunningActivitiesRetrieved()
        {
            var fitBitTokenAsJsonResult = sut.GetFitBitAuthenticationToken();
            fitBitTokenAsJsonResult.Result.Should().NotBeNull();
            fitBitTokenAsJsonResult.Result.Value.Should().NotBe(string.Empty);
            fitBitAuthenticationToken = new FitBitAuthenticationToken
            {
                AccessToken = (string)fitBitTokenAsJsonResult.Result.Value
            };
            fitBitAuthenticationToken.AccessToken.Should().NotBeNullOrEmpty();

            // Get Activities
            Task<JsonResult> activityHistoryResult = sut.GetFitBitActivityHistory(fitBitAuthenticationToken);
            activityHistoryResult.Result.Value.Should().NotBeNull();
            activityHistoryResult.Result.Value.Should().NotBe(string.Empty);
            var actualActivities = activityHistoryResult.Result.Value;
            actualActivities.Should().NotBeNull();
        }
    }
}
