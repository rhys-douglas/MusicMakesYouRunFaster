namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using ClientDrivers;
    using DataSource;
    using FluentAssertions;
    using SpotifyAPI.Web;
    using TechTalk.SpecFlow;

    [Binding]
    public class MusicHistorySteps
    {
        private readonly IClientDriver clientDriver;
        private readonly DataPort dataSource;
        private readonly List<PlayHistoryItem> listeningHistory = new List<PlayHistoryItem>();

        public MusicHistorySteps(IClientDriver clientDriver, DataPort dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }

        [Given(@"a list of listening history")]
        public void GivenAListOfListeningHistory(Table table)
        {
            var fakeListeningHistory = new List<FakeResponseServer.Models.Spotify.PlayHistoryItem>();
            var count = 0;
            foreach (var row in table.Rows)
            {
                var listeningHistoryItem = new PlayHistoryItem
                {
                    PlayedAt = DateTime.ParseExact(row["Time of listening"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    Track = new SimpleTrack
                    {
                        Artists = new List<SimpleArtist>(),
                        AvailableMarkets = new List<string>(),
                        DiscNumber = 1,
                        DurationMs = 3500,
                        Explicit = false,
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = "https://api.spotify.com/v1/albums/SomeHref",
                        Id = count.ToString(),
                        IsPlayable = true,
                        LinkedFrom = new LinkedTrack
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
                        Type = ItemType.Track,
                        Uri = "SomeURI",
                    },
                    Context = new Context
                    {
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = "https://api.spotify.com/v1/albums/SomeURI",
                        Type = "Album",
                        Uri = "spotify:album:SomeURI" + count.ToString()
                    }
                };
                var fakeHistoryItem = new FakeResponseServer.Models.Spotify.PlayHistoryItem
                {
                    Id = count.ToString(),
                    PlayedAt = DateTime.ParseExact(row["Time of listening"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    Track = new FakeResponseServer.Models.Spotify.SimpleTrack
                    {
                        Artists = new List<FakeResponseServer.Models.Spotify.SimpleArtist>(),
                        AvailableMarkets = new List<string>(),
                        DiscNumber = 1,
                        DurationMs = 3500,
                        Explicit = false,
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = "https://api.spotify.com/v1/albums/SomeHref",
                        Id = count.ToString(),
                        IsPlayable = true,
                        LinkedFrom = new FakeResponseServer.Models.Spotify.LinkedTrack
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
                        Type = FakeResponseServer.Models.Spotify.ItemType.Track,
                        Uri = "SomeURI",
                    },
                    Context = new FakeResponseServer.Models.Spotify.Context
                    {
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = "https://api.spotify.com/v1/albums/SomeURI",
                        Type = "Album",
                        Uri = "spotify:album:SomeURI" + count.ToString()
                    }
                };

                listeningHistory.Add(listeningHistoryItem);
                fakeListeningHistory.Add(fakeHistoryItem);
                count++;
            }
            dataSource.AddListeningHistory(fakeListeningHistory);
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
            acquiredListeningHistory.Should().BeEquivalentTo(listeningHistory);
        }
    }
}
