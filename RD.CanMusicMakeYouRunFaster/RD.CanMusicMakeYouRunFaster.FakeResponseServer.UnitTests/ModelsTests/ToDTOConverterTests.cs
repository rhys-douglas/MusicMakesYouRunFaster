namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ModelsTests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using FluentAssertions;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models;

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
    }
}
