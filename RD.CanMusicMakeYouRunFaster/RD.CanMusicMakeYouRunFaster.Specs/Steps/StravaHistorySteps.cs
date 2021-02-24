namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers;
    using RD.CanMusicMakeYouRunFaster.Specs.DataSource;
    using System.Collections.Generic;
    using TechTalk.SpecFlow;

    [Binding]
    public class StravaHistorySteps
    {
        private readonly IClientDriver clientDriver;
        private readonly DataPort dataSource;
        private readonly List<StravaSharp.Activity> actualHistory = new List<StravaSharp.Activity>(); 

        public StravaHistorySteps(IClientDriver clientDriver, DataPort dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }

        [Given(@"a list of running history")]
        public void GivenAListOfRunningHistory(Table table)
        {
            var convertedRunningHistory = new List<StravaSharp.Activity>();
            var fakeRunningHistory = new List<FakeResponseServer.Models.Strava.Activity>();

            foreach (var row in table.Rows)
            {
                var fakeHistoryItem = new FakeResponseServer.Models.Strava.Activity
                {
                    
                };
            }

            /*
            var count = 0;
            foreach (var row in table.Rows)
            {
                var rowOfHistory = new Dictionary<string, string>
                {
                    { row["Song name"], row["Time of listening"] }
                };
                listeningHistory.Add(rowOfHistory);

                var listeningHistoryItem = new SpotifyAPI.Web.PlayHistoryItem
                {
                    PlayedAt = DateTime.ParseExact(row["Time of listening"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    Track = new SpotifyAPI.Web.SimpleTrack
                    {
                        Name = row["Song name"]
                    }
                };

                count++;
                var fakeHistoryItem = new FakeResponseServer.Models.PlayHistoryItem
                {
                    Id = count.ToString(),
                    PlayedAt = DateTime.ParseExact(row["Time of listening"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    Track = new FakeResponseServer.Models.SimpleTrack
                    {
                        Artists = new List<FakeResponseServer.Models.SimpleArtist>(),
                        AvailableMarkets = new List<string>(),
                        DiscNumber = 1,
                        DurationMs = 3500,
                        Explicit = false,
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = "https://api.spotify.com/v1/albums/SomeHref",
                        Id = count.ToString(),
                        IsPlayable = true,
                        LinkedFrom = new FakeResponseServer.Models.LinkedTrack
                        {
                            ExternalUrls = new Dictionary<string, string>(),
                            Href = "https://api.spotify.com/v1/albums/SomeOtherHref",
                            Id = count.ToString(),
                            Type = "Track",
                            Uri = "spotify:album:SomeOtherURI"
                        },
                        Name = row["Song name"],
                        PreviewUrl = "https://p.scdn.co/mp3-preview/SomeRef",
                        TrackNumber = 1,
                        Type = FakeResponseServer.Models.ItemType.Track,
                        Uri = "SomeURI",
                    },
                    Context = new FakeResponseServer.Models.Context
                    {
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = "https://api.spotify.com/v1/albums/SomeURI",
                        Type = "Album",
                        Uri = "spotify:album:SomeURI" + count.ToString()
                    }
                };
                convertedListeningHistory.Add(listeningHistoryItem);
                fakeListeningHistory.Add(fakeHistoryItem);
            }
            dataSource.AddListeningHistory(fakeListeningHistory);
            */
        }


        [Given(@"their running history")]
        public void GivenTheirRunningHistory()
        {
            // Do something
        }

        [When(@"the user's recent running history is requested")]
        public void WhenTheUsersRunningHistoryIsRequested()
        {
            
        }

        [Then(@"the user's recent running history is produced")]
        public void ThenTheUsersRunningHistoryIsProduced()
        {

        }
    }
}
