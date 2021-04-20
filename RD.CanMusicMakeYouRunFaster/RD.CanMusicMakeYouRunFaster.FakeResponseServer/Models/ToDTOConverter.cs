namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Converts context entities / models into Data Transfer Objects.
    /// </summary>
    public static class ToDTOConverter
    {
        /// <summary>
        /// Converts context PlayHistoryItems to DTO.
        /// </summary>
        /// <param name="playHistoryItem"> PlayHistoryItem from context.</param>
        /// <returns> DTO of PlayHistoryItem.</returns>
        public static DTO.PlayHistoryItem ToDTO(this Spotify.PlayHistoryItem playHistoryItem)
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
                    Artists = ConvertArtists(playHistoryItem.Track.Artists),
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

        /// <summary>
        /// Converts context Strava Activity objects to DTO counterparts.
        /// </summary>
        /// <param name="activity"> Activity from context.</param>
        /// <returns>DTO of Strava activity</returns>
        public static DTO.Activity ToDTO(this Strava.Activity activity)
        {
            return activity != null ? new DTO.Activity
            {
                achievement_count = activity.achievement_count,
                athlete = new DTO.Athlete
                {
                    badge_type_id = activity.athlete.badge_type_id,
                    city = activity.athlete.city,
                    country = activity.athlete.country,
                    created_at = activity.athlete.created_at,
                    firstname = activity.athlete.firstname,
                    follower = activity.athlete.follower,
                    friend = activity.athlete.friend,
                    id = activity.athlete.id,
                    lastname = activity.athlete.lastname,
                    premium = activity.athlete.premium,
                    profile = activity.athlete.profile,
                    profile_medium = activity.athlete.profile_medium,
                    resource_state = activity.athlete.resource_state,
                    sex = activity.athlete.sex,
                    state = activity.athlete.state,
                    summit = activity.athlete.summit,
                    updated_at = activity.athlete.updated_at,
                    username = activity.athlete.username
                },
                athlete_count = activity.athlete_count,
                average_cadence = activity.average_cadence,
                average_heartrate = activity.average_heartrate,
                average_speed = activity.average_speed,
                average_temp = activity.average_temp,
                comment_count = activity.comment_count,
                commute = activity.commute,
                display_hide_heartrate_option = activity.display_hide_heartrate_option,
                distance = activity.distance,
                elapsed_time = activity.elapsed_time,
                elev_high = activity.elev_high,
                elev_low = activity.elev_low,
                end_latlng = activity.end_latlng,
                external_id = activity.external_id,
                flagged = activity.flagged,
                from_accepted_tag = activity.from_accepted_tag,
                gear_id = activity.gear_id,
                has_heartrate = activity.has_heartrate,
                has_kudoed = activity.has_kudoed,
                heartrate_opt_out = activity.heartrate_opt_out,
                id = activity.id,
                kudos_count = activity.kudos_count,
                location_city = activity.location_city,
                location_country = activity.location_country,
                location_state = activity.location_state,
                manual = activity.manual,
                map = new DTO.Map
                {
                    id = activity.map.id,
                    resource_state = activity.map.resource_state,
                    summary_polyline = activity.map.summary_polyline
                },
                max_heartrate = activity.max_heartrate,
                max_speed = activity.max_speed,
                moving_time = activity.moving_time,
                name = activity.name,
                photo_count = activity.photo_count,
                Private = activity.Private,
                pr_count = activity.pr_count,
                resource_state = activity.resource_state,
                start_date = activity.start_date,
                start_date_local = activity.start_date_local,
                start_latitude = activity.start_latitude,
                start_latlng = activity.start_latlng,
                start_longitude = activity.start_longitude,
                timezone = activity.timezone,
                total_elevation_gain = activity.total_elevation_gain,
                total_photo_count = activity.total_photo_count,
                trainer = activity.trainer,
                type = activity.type,
                upload_id = activity.upload_id,
                upload_id_str = activity.upload_id_str,
                utc_offset = activity.utc_offset,
                visibility = activity.visibility,
                workout_type = activity.workout_type,
            } : null;
        }

        /// <summary>
        /// Converts context FitBit Activities to DTO counterparts.
        /// </summary>
        /// <param name="activity"> Activities object to convert.</param>
        /// <returns> DTO of FitBit Activity.</returns>
        public static DTO.FitBitActivities ToDTO(this FitBit.Activities activity)
        {
            return activity != null ? new DTO.FitBitActivities
            {
                ActiveDuration = activity.ActiveDuration,
                ActivityLevel = ConvertActivityLevels(activity.ActivityLevel),
                ActivityName = activity.ActivityName,
                ActivityTypeId = activity.ActivityTypeId,
                AverageHeartRate = activity.AverageHeartRate,
                Calories = activity.Calories,
                DateOfActivity = activity.DateOfActivity,
                Distance = activity.Distance,
                DistanceUnit = activity.DistanceUnit,
                Duration = activity.Duration,
                ElevationGain = activity.ElevationGain,
                HeartRateZones = ConvertHeartRateZones(activity.HeartRateZones),
                LastModified = activity.LastModified,
                LogId = activity.LogId,
                LogType = activity.LogType,
                ManualValuesSpecified = new DTO.ManualValuesSpecified 
                {
                    Calories = activity.ManualValuesSpecified.Calories,
                    Distance = activity.ManualValuesSpecified.Distance,
                    Steps = activity.ManualValuesSpecified.Steps
                },
                OriginalDuration = activity.OriginalDuration,
                OriginalStartTime = activity.OriginalStartTime,
                Pace = activity.Pace,
                Source = new DTO.ActivityLogSource
                {
                    Id = activity.Source.Id,
                    Name = activity.Source.Name,
                    Type = activity.Source.Type,
                    Url = activity.Source.Url
                },
                Speed = activity.Speed,
                StartTime = activity.StartTime,
                Steps = activity.Steps,
                TcxLink = activity.TcxLink
            } : null;
        }

        /// <summary>
        /// Converts context LastFM tracks to DTO counterparts.
        /// </summary>
        /// <param name="lastTrack"> LastTrack object to convert.</param>
        /// <returns>DTO of the LastTrack object.</returns>
        public static DTO.LastTrack ToDTO(this LastFM.LastTrack lastTrack)
        {
            return lastTrack != null ? new DTO.LastTrack
            {
                AlbumName = lastTrack.AlbumName,
                ArtistImages = new DTO.LastImageSet 
                {
                    Small = lastTrack.ArtistImages.Small,
                    Medium = lastTrack.ArtistImages.Medium,
                    Large = lastTrack.ArtistImages.Large,
                    ExtraLarge = lastTrack.ArtistImages.ExtraLarge,
                    Mega = lastTrack.ArtistImages.Mega,
                },
                ArtistMbid = lastTrack.ArtistMbid,
                ArtistName = lastTrack.ArtistName,
                ArtistUrl = lastTrack.ArtistUrl,
                Duration = lastTrack.Duration,
                Id = lastTrack.Id,
                Images = new DTO.LastImageSet
                {
                    Small = lastTrack.Images.Small,
                    Medium = lastTrack.Images.Medium,
                    Large = lastTrack.Images.Large,
                    ExtraLarge = lastTrack.Images.ExtraLarge,
                    Mega = lastTrack.Images.Mega,
                },
                IsLoved = lastTrack.IsLoved,
                IsNowPlaying = lastTrack.IsNowPlaying,
                ListenerCount = lastTrack.ListenerCount,
                Mbid = lastTrack.Mbid,
                Name = lastTrack.Name,
                PlayCount = lastTrack.PlayCount,
                Rank = lastTrack.Rank,
                TimePlayed = lastTrack.TimePlayed,
                TopTags = ConvertTags(lastTrack.TopTags),
                Url = lastTrack.Url,
                UserPlayCount = lastTrack.UserPlayCount,
            } : null;
        }

        private static List<DTO.SimpleArtist> ConvertArtists(List<Spotify.SimpleArtist> listOfModels)
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

        private static List<DTO.ActivityLevel> ConvertActivityLevels(List<FitBit.ActivityLevel> listOfActivityLevels)
        {
            if (listOfActivityLevels == null)
            {
                return null;
            }

            List<DTO.ActivityLevel> listOfDTOActivityLevels = new List<DTO.ActivityLevel>();
            foreach (var item in listOfActivityLevels)
            {
                listOfDTOActivityLevels.Add(new DTO.ActivityLevel
                {
                    Minutes = item.Minutes,
                    Name = item.Name
                });
            }

            return listOfDTOActivityLevels;
        }

        private static List<DTO.HeartRateZone> ConvertHeartRateZones(List<FitBit.HeartRateZone> listOfHeartRateZones)
        {
            if (listOfHeartRateZones == null)
            {
                return null;
            }

            List<DTO.HeartRateZone> listofDTOHeartRateZones = new List<DTO.HeartRateZone>();
            foreach (var item in listOfHeartRateZones)
            {
                listofDTOHeartRateZones.Add(new DTO.HeartRateZone
                {
                    Minutes = item.Minutes,
                    Name = item.Name,
                    CaloriesOut = item.CaloriesOut,
                    Max = item.Max,
                    Min = item.Min
                });
            }

            return listofDTOHeartRateZones;
        }

        private static List<DTO.LastTag> ConvertTags(IEnumerable<LastFM.LastTag> listOfTags)
        {
            if (listOfTags == null)
            {
                return null;
            }

            List<DTO.LastTag> listOfDTOTags = new List<DTO.LastTag>();
            foreach (var item in listOfTags)
            {
                listOfDTOTags.Add(new DTO.LastTag
                {
                    Count = item.Count,
                    Name = item.Name,
                    Reach = item.Reach,
                    RelatedTo = item.RelatedTo,
                    Streamable = item.Streamable,
                    Url = item.Url
                });
            }

            return listOfDTOTags;
        }
    }
}
