namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using NUnit.Framework;
    using FakeResponseServer.Controllers;
    using FluentAssertions;
    using System.Collections.Generic;
    using System;
    using DbContext;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO.Request;

    public class LastFMMusicControllerTests
    {
        private LastFMMusicController sut;
        private readonly List<DTO.LastTrack> listeningHistory = new List<DTO.LastTrack>();

        private readonly Models.LastFM.LastTrack item1 = new Models.LastFM.LastTrack
        {
            AlbumName = "Some Album Name",
            ArtistImages = new Models.LastFM.LastImageSet()
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
            Images = new Models.LastFM.LastImageSet
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
            TimePlayed = DateTime.UtcNow,
            TopTags = new List<Models.LastFM.LastTag>(),
            Url = new Uri("http://localhost/TrackURI"),
            UserPlayCount = 20
        };

        private readonly Models.LastFM.LastTrack item2 = new Models.LastFM.LastTrack
        {
            AlbumName = "Some Album Name 2",
            ArtistImages = new Models.LastFM.LastImageSet()
            {
                Small = new Uri("http://localhost/Small2"),
                Medium = new Uri("http://localhost/Medium2"),
                Large = new Uri("http://localhost/Large2"),
                ExtraLarge = new Uri("http://localhost/XL2"),
                Mega = new Uri("http://localhost/Mega2"),
            },
            ArtistMbid = "abcdefghi",
            ArtistName = "Some Artist 2",
            ArtistUrl = new Uri("http://localhost/ArtistURI2"),
            Duration = new TimeSpan(0, 3,0),
            Id = "bcdefghij",
            Images = new Models.LastFM.LastImageSet
            {
                Small = new Uri("http://localhost/Small3"),
                Medium = new Uri("http://localhost/Medium3"),
                Large = new Uri("http://localhost/Large3"),
                ExtraLarge = new Uri("http://localhost/XL3"),
                Mega = new Uri("http://localhost/Mega3"),
            },
            IsLoved = false,
            IsNowPlaying = true,
            ListenerCount = 53478763,
            Mbid = "cdefghijk",
            Name = "Some Track 2",
            PlayCount = 573847389,
            Rank = 2,
            TimePlayed = DateTime.UtcNow,
            TopTags = new List<Models.LastFM.LastTag>(),
            Url = new Uri("http://localhost/TrackURI2"),
            UserPlayCount = 30,
        };

        private readonly Models.LastFM.LastTrack item3 = new Models.LastFM.LastTrack
        {
            AlbumName = "Some Album Name 3",
            ArtistImages = new Models.LastFM.LastImageSet()
            {
                Small = new Uri("http://localhost/Small3"),
                Medium = new Uri("http://localhost/Medium3"),
                Large = new Uri("http://localhost/Large3"),
                ExtraLarge = new Uri("http://localhost/XL3"),
                Mega = new Uri("http://localhost/Mega3"),
            },
            ArtistMbid = "1a2b3c4d5e",
            ArtistName = "Some Artist 3",
            ArtistUrl = new Uri("http://localhost/ArtistURI3"),
            Duration = new TimeSpan(0, 6, 0),
            Id = "bcdefghij",
            Images = new Models.LastFM.LastImageSet
            {
                Small = new Uri("http://localhost/Small4"),
                Medium = new Uri("http://localhost/Medium4"),
                Large = new Uri("http://localhost/Large4"),
                ExtraLarge = new Uri("http://localhost/XL4"),
                Mega = new Uri("http://localhost/Mega4"),
            },
            IsLoved = false,
            IsNowPlaying = true,
            ListenerCount = 53478763,
            Mbid = "cdefghijk",
            Name = "Some Track 3",
            PlayCount = 573847389,
            Rank = 2,
            TimePlayed = DateTime.UtcNow,
            TopTags = new List<Models.LastFM.LastTag>(),
            Url = new Uri("http://localhost/TrackURI3"),
            UserPlayCount = 30,
        };

        private readonly DTO.LastTrack DTOItem1 = new DTO.LastTrack
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
            TimePlayed = DateTime.UtcNow,
            TopTags = new List<DTO.LastTag>(),
            Url = new Uri("http://localhost/TrackURI"),
            UserPlayCount = 20
        };

        private readonly DTO.LastTrack DTOItem2 = new DTO.LastTrack
        {
            AlbumName = "Some Album Name 2",
            ArtistImages = new DTO.LastImageSet()
            {
                Small = new Uri("http://localhost/Small2"),
                Medium = new Uri("http://localhost/Medium2"),
                Large = new Uri("http://localhost/Large2"),
                ExtraLarge = new Uri("http://localhost/XL2"),
                Mega = new Uri("http://localhost/Mega2"),
            },
            ArtistMbid = "abcdefghi",
            ArtistName = "Some Artist 2",
            ArtistUrl = new Uri("http://localhost/ArtistURI2"),
            Duration = new TimeSpan(0, 3, 0),
            Id = "bcdefghij",
            Images = new DTO.LastImageSet
            {
                Small = new Uri("http://localhost/Small3"),
                Medium = new Uri("http://localhost/Medium3"),
                Large = new Uri("http://localhost/Large3"),
                ExtraLarge = new Uri("http://localhost/XL3"),
                Mega = new Uri("http://localhost/Mega3"),
            },
            IsLoved = false,
            IsNowPlaying = true,
            ListenerCount = 53478763,
            Mbid = "cdefghijk",
            Name = "Some Track 2",
            PlayCount = 573847389,
            Rank = 2,
            TimePlayed = DateTime.UtcNow,
            TopTags = new List<DTO.LastTag>(),
            Url = new Uri("http://localhost/TrackURI2"),
            UserPlayCount = 30,
        };

        private readonly DTO.LastTrack DTOItem3 = new DTO.LastTrack
        {
            AlbumName = "Some Album Name 3",
            ArtistImages = new DTO.LastImageSet()
            {
                Small = new Uri("http://localhost/Small3"),
                Medium = new Uri("http://localhost/Medium3"),
                Large = new Uri("http://localhost/Large3"),
                ExtraLarge = new Uri("http://localhost/XL3"),
                Mega = new Uri("http://localhost/Mega3"),
            },
            ArtistMbid = "1a2b3c4d5e",
            ArtistName = "Some Artist 3",
            ArtistUrl = new Uri("http://localhost/ArtistURI3"),
            Duration = new TimeSpan(0, 6, 0),
            Id = "bcdefghij",
            Images = new DTO.LastImageSet
            {
                Small = new Uri("http://localhost/Small4"),
                Medium = new Uri("http://localhost/Medium4"),
                Large = new Uri("http://localhost/Large4"),
                ExtraLarge = new Uri("http://localhost/XL4"),
                Mega = new Uri("http://localhost/Mega4"),
            },
            IsLoved = false,
            IsNowPlaying = true,
            ListenerCount = 53478763,
            Mbid = "cdefghijk",
            Name = "Some Track 3",
            PlayCount = 573847389,
            Rank = 2,
            TimePlayed = DateTime.UtcNow,
            TopTags = new List<DTO.LastTag>(),
            Url = new Uri("http://localhost/TrackURI3"),
            UserPlayCount = 30,
        };

        private DbContextOptions<DataRetrievalContext> contextOptions;

        [OneTimeSetUp]
        public void SetUp()
        {
            contextOptions = new DbContextOptionsBuilder<DataRetrievalContext>()
                .UseInMemoryDatabase("LastFMMusicControllerTestDatabase")
                .Options;

            using var context = new DataRetrievalContext(contextOptions);
            var now = DateTime.UtcNow;
            item1.TimePlayed = now.AddDays(-2);
            item2.TimePlayed = now.AddDays(-3);
            item3.TimePlayed = now;
            DTOItem1.TimePlayed = now.AddDays(-2);
            DTOItem2.TimePlayed = now.AddDays(-3);
            DTOItem3.TimePlayed = now;

            listeningHistory.Add(DTOItem1);
            listeningHistory.Add(DTOItem2);
            listeningHistory.Add(DTOItem3);

            context.LastTracks.Add(item1);
            context.LastTracks.Add(item2);
            context.LastTracks.Add(item3);

            context.SaveChanges();
        }

        [Test]
        public void GetRecentTracks_MusicHistoryReturned()
        {
            sut = new LastFMMusicController(new DataRetrievalContext(contextOptions));
            var request = new LastFMGetRecentTracksRequest
            {
                ApiKey = "some API key",
                User = "RD"
            };
            var getResult = sut.GetRecentTracks(request);
            var retrievedSongs = getResult.Result.Content.ToList();
            retrievedSongs.Should().HaveCount(3);
            retrievedSongs.Should().BeEquivalentTo(listeningHistory);
        }

        [Test]
        public void GetRecentTracksWithAfterParam_MusicHistoryReturned()
        {
            var after = DateTime.UtcNow.AddDays(-1);
            var afterAsUnix = ((DateTimeOffset)after).ToUnixTimeMilliseconds();
            var request = new LastFMGetRecentTracksRequest
            {
                ApiKey = "some API key",
                User = "RD",
                From = afterAsUnix
            };

            sut = new LastFMMusicController(new DataRetrievalContext(contextOptions));
            var getResult = sut.GetRecentTracks(request);
            var retrievedSongs = getResult.Result.Content.ToList();
            retrievedSongs.Should().HaveCount(1);
            retrievedSongs.Should().NotBeEquivalentTo(listeningHistory);
        }
    }
}
