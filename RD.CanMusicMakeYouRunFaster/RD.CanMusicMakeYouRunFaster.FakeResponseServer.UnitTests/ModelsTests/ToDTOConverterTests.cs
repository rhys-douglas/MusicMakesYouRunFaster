namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ModelsTests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using FluentAssertions;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Spotify;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.FitBit;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.LastFM;

    public class ToDTOConverterTests
    {
        [Test]
        public void ToDTOOfNull_ReturnsNull()
        {
            var sut = ((PlayHistoryItem)null).ToDTO();
            sut.Should().BeNull();
        }

        [Test]
        public void ToDTOOfPlayHistoryItem_ConvertedToDTO()
        {
            var now = DateTime.UtcNow;
            var sut = new PlayHistoryItem
            {
                Context = new Context
                {
                    ExternalUrls = new Dictionary<string, string>(),
                    Href = "SomeHREF",
                    Type = "SomeType",
                    Uri = "SomeURI"
                },
                Id = "Unneeded value.",
                PlayedAt = now,
                Track = new SimpleTrack
                {
                    Artists = new List<SimpleArtist>(),
                    AvailableMarkets = new List<string>(),
                    DiscNumber = 1,
                    DurationMs = 3600,
                    Explicit = true,
                    ExternalUrls = new Dictionary<string, string>(),
                    Href = "AnotherHref",
                    Id = "12345678",
                    IsPlayable = true,
                    LinkedFrom = new LinkedTrack(),
                    Name = "My favourite song",
                    PreviewUrl = "https://google.com",
                    TrackNumber = 5,
                    Type = ItemType.Track,
                    Uri = "AnotherURI"
                }
            };

            var convertedPlayHistoryItem = new DTO.PlayHistoryItem
            {
                Context = new DTO.Context
                {
                    ExternalUrls = new Dictionary<string, string>(),
                    Href = "SomeHREF",
                    Type = "SomeType",
                    Uri = "SomeURI"
                },
                PlayedAt = now,
                Track = new DTO.SimpleTrack
                {
                    Artists = new List<DTO.SimpleArtist>(),
                    AvailableMarkets = new List<string>(),
                    DiscNumber = 1,
                    DurationMs = 3600,
                    Explicit = true,
                    ExternalUrls = new Dictionary<string, string>(),
                    Href = "AnotherHref",
                    Id = "12345678",
                    IsPlayable = true,
                    LinkedFrom = new DTO.LinkedTrack(),
                    Name = "My favourite song",
                    PreviewUrl = "https://google.com",
                    TrackNumber = 5,
                    Type = ItemType.Track,
                    Uri = "AnotherURI"
                }
            };

            var convertedObject = sut.ToDTO();
            convertedObject.Should().NotBeNull();
            convertedObject.Should().BeOfType<DTO.PlayHistoryItem>();
            convertedObject.Should().BeEquivalentTo(convertedPlayHistoryItem);
        }

        [Test]
        public void ToDTOOfFitBitActivities_ConvertedToDTO()
        {
            var now = DateTime.Now;

            var sut = new Activities()
            {
                ActiveDuration = 5,
                ActivityLevel = new List<ActivityLevel>(),
                ActivityName = "Run 1",
                ActivityTypeId = 5,
                AverageHeartRate = 140,
                Calories = 500,
                DateOfActivity = "17/04/2021",
                Distance = 3500,
                DistanceUnit = "M",
                Duration = 3600,
                ElevationGain = 330,
                HeartRateZones = new List<HeartRateZone>(),
                LastModified = now,
                LogId = 123253464353,
                LogType = "logtype1",
                ManualValuesSpecified = new ManualValuesSpecified(),
                OriginalDuration = 3601,
                OriginalStartTime = now,
                Pace = 16.5,
                Source = new ActivityLogSource(),
                Speed = 18.5,
                StartTime = now,
                Steps = 14000,
                TcxLink = "??"
            };

            var convertedActivity = new DTO.FitBitActivities()
            {
                ActiveDuration = 5,
                ActivityLevel = new List<DTO.ActivityLevel>(),
                ActivityName = "Run 1",
                ActivityTypeId = 5,
                AverageHeartRate = 140,
                Calories = 500,
                DateOfActivity = "17/04/2021",
                Distance = 3500,
                DistanceUnit = "M",
                Duration = 3600,
                ElevationGain = 330,
                HeartRateZones = new List<DTO.HeartRateZone>(),
                LastModified = now,
                LogId = 123253464353,
                LogType = "logtype1",
                ManualValuesSpecified = new DTO.ManualValuesSpecified(),
                OriginalDuration = 3601,
                OriginalStartTime = now,
                Pace = 16.5,
                Source = new DTO.ActivityLogSource(),
                Speed = 18.5,
                StartTime = now,
                Steps = 14000,
                TcxLink = "??"
            };

            var convertedObject = sut.ToDTO();
            convertedObject.Should().NotBeNull();
            convertedObject.Should().BeOfType<DTO.FitBitActivities>();
            convertedObject.Should().BeEquivalentTo(convertedActivity);
        }

        [Test]
        public void ToDTOOfLastFMLastTracks_ConvertedToDTO()
        {
            var now = DateTime.UtcNow;

            var sut = new LastTrack()
            {
                AlbumName = "Some Album Name",
                ArtistImages = new LastImageSet()
                {
                    Small = new Uri("http://localhost/Small"),
                    Medium = new Uri("http://localhost/Medium"),
                    Large = new Uri("http://localhost/Large"),
                    ExtraLarge = new Uri("http://localhost/XL"),
                    Mega = new Uri("http://localhost/Mega"),
                },
                ArtistMbid = "123456789",
                ArtistName = "Some Artist",
                ArtistUrl = new Uri("http://localhost/ArtistURI"),
                Duration = new TimeSpan(0,2,30),
                Id = "23456789",
                Images = new LastImageSet
                {
                    Small = new Uri("http://localhost/Small"),
                    Medium = new Uri("http://localhost/Medium"),
                    Large = new Uri("http://localhost/Large"),
                    ExtraLarge = new Uri("http://localhost/XL"),
                    Mega = new Uri("http://localhost/Mega"),
                },
                IsLoved = true,
                IsNowPlaying = false,
                ListenerCount = 1500,
                Mbid = "3456789",
                Name = "Some Track",
                PlayCount = 300,
                Rank = 1,
                TimePlayed = now,
                TopTags = new List<LastTag>(),
                Url = new Uri("http://localhost/TrackURI"),
                UserPlayCount = 20,
            };

            var convertedTrack = new DTO.LastTrack()
            {
                AlbumName = "Some Album Name",
                ArtistImages = new DTO.LastImageSet()
                {
                    Small = new Uri("http://localhost/Small"),
                    Medium = new Uri("http://localhost/Medium"),
                    Large = new Uri("http://localhost/Large"),
                    ExtraLarge = new Uri("http://localhost/XL"),
                    Mega = new Uri("http://localhost/Mega"),
                },
                ArtistMbid = "123456789",
                ArtistName = "Some Artist",
                ArtistUrl = new Uri("http://localhost/ArtistURI"),
                Duration = new TimeSpan(0, 2, 30),
                Id = "23456789",
                Images = new DTO.LastImageSet
                {
                    Small = new Uri("http://localhost/Small"),
                    Medium = new Uri("http://localhost/Medium"),
                    Large = new Uri("http://localhost/Large"),
                    ExtraLarge = new Uri("http://localhost/XL"),
                    Mega = new Uri("http://localhost/Mega"),
                },
                IsLoved = true,
                IsNowPlaying = false,
                ListenerCount = 1500,
                Mbid = "3456789",
                Name = "Some Track",
                PlayCount = 300,
                Rank = 1,
                TimePlayed = now,
                TopTags = new List<DTO.LastTag>(),
                Url = new Uri("http://localhost/TrackURI"),
                UserPlayCount = 20,
            };

            var convertedObject = sut.ToDTO();
            convertedObject.Should().NotBeNull();
            convertedObject.Should().BeOfType<DTO.LastTrack>();
            convertedObject.Should().BeEquivalentTo(convertedTrack);
        }
    }
}
