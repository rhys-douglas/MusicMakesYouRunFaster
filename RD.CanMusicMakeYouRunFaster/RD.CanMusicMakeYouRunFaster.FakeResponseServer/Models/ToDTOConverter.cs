using System.Collections.Generic;

namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models
{
    /// <summary>
    /// Converts context entities / models into Data Transfer Objects.
    /// </summary>
    public static class ToDTOConverter
    {
        /// <summary>
        /// Converts context PlayHistoryItems to DTO.
        /// </summary>
        /// <param name="playHistoryItem"></param>
        /// <returns> DTO of PlayHistoryItem.</returns>
        public static DTO.PlayHistoryItem ToDTO(this PlayHistoryItem playHistoryItem)
        {
            return playHistoryItem != null ? new DTO.PlayHistoryItem
            {
                Context = new DTO.Context
                {
                    ExternalUrls = playHistoryItem.Context.ExternalUrls,
                    Href = playHistoryItem.Context.Href,
                    Type = playHistoryItem.Context.Type,
                    Uri = playHistoryItem.Context.Uri
                },
                PlayedAt = playHistoryItem.PlayedAt,
                Track = new DTO.SimpleTrack 
                { 
                    Artists = ConvertArtsits(playHistoryItem.Track.Artists),
                    AvailableMarkets = playHistoryItem.Track.AvailableMarkets,
                    DiscNumber = playHistoryItem.Track.DiscNumber,
                    DurationMs = playHistoryItem.Track.DurationMs,
                    Explicit = playHistoryItem.Track.Explicit,
                    ExternalUrls = playHistoryItem.Track.ExternalUrls,
                    Href = playHistoryItem.Track.Href,
                    Id = playHistoryItem.Track.Id,
                    IsPlayable = playHistoryItem.Track.IsPlayable,
                    LinkedFrom = new DTO.LinkedTrack
                    {
                        ExternalUrls = playHistoryItem.Track.LinkedFrom.ExternalUrls,
                        Href = playHistoryItem.Track.LinkedFrom.Href,
                        Id = playHistoryItem.Track.LinkedFrom.Id,
                        Type = playHistoryItem.Track.LinkedFrom.Type,
                        Uri = playHistoryItem.Track.LinkedFrom.Uri
                    },
                    Name = playHistoryItem.Track.Name,
                    PreviewUrl = playHistoryItem.Track.PreviewUrl,
                    TrackNumber = playHistoryItem.Track.TrackNumber,
                    Type = playHistoryItem.Track.Type,
                    Uri = playHistoryItem.Track.Uri
                }

            } : null;
        }

        private static List<DTO.SimpleArtist> ConvertArtsits(List<Models.SimpleArtist> listOfModels)
        {
            if (listOfModels == null)
            {
                return null;
            }

            List<DTO.SimpleArtist> listOfDTOArtists = new List<DTO.SimpleArtist>();
            foreach (var model in listOfModels)
            {
                listOfDTOArtists.Add(new DTO.SimpleArtist
                {
                    ExternalUrls = model.ExternalUrls,
                    Href = model.Href,
                    Id = model.Id,
                    Name = model.Name,
                    Type = model.Type,
                    Uri = model.Uri
                });
            }

            return listOfDTOArtists;
        }
    }
}
