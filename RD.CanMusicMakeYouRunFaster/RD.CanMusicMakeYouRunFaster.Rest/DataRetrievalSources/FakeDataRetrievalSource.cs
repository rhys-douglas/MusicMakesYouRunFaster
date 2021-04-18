namespace RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using System.Threading.Tasks;
    using SpotifyAPI.Web;
    using System.Web;
    using System.Collections.Generic;
    using Fitbit.Api.Portable.Models;

    /// <summary>
    /// Fake data source used for tests.
    /// </summary>
    public class FakeDataRetrievalSource : IDataRetrievalSource
    {
        private readonly FakeResponseServer.Controllers.ExternalAPICaller externalAPICaller;
        private readonly Uri fakeSpotifyAuthUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDataRetrievalSource"/> class.
        /// </summary>
        /// <param name="externalAPICaller"> HTTP encapsulated Client. </param>
        /// <param name="fakeServerUrl"> Fake server url to call.</param>
        public FakeDataRetrievalSource(FakeResponseServer.Controllers.ExternalAPICaller externalAPICaller,  string fakeServerUrl)
        {
            this.externalAPICaller = externalAPICaller;
            this.fakeSpotifyAuthUrl = new Uri(fakeServerUrl);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyAuthenticationToken()
        {
            var (challenge, verifier) = PKCEUtil.GenerateCodes();
            await Task.Delay(0);
            FakeResponseServer.DTO.Request.PKCETokenRequest tokenRequest = new FakeResponseServer.DTO.Request.PKCETokenRequest
            {
                ClientId = "Some client id",
                Code = "200",
                CodeVerifier = verifier,
                RedirectUri = new Uri("http://localhost:2000/callback/")
            };
            var builder = new UriBuilder(fakeSpotifyAuthUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["ClientId"] = tokenRequest.ClientId;
            query["Code"] = tokenRequest.Code;
            query["CodeVerifier"] = tokenRequest.CodeVerifier;
            query["RedirectUri"] = tokenRequest.RedirectUri.ToString();
            builder.Query = query.ToString();
            var authTokenResponse = externalAPICaller.Get<SpotifyAuthenticationToken>(new Uri("http://localhost:2222/authorize?ClientId=Some+client+id&Code=200&CodeVerifier=KmS_2IQWRizX1bXF5G508LjlbdO2P9432WFf7gKEfD4&RedirectUri=http%3a%2f%2flocalhost%3a2000%2fcallback%2f"));
            return new JsonResult(authTokenResponse);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetStravaAuthenticationToken()
        {
            await Task.Delay(0);
            var exchangeTokenResponse = externalAPICaller.Get<FakeResponseServer.DTO.StravaExchangeTokenResponse>(new Uri("http://localhost:2222/oauth/authorize?client_id=1234&response_type=code&approval_prompt=force&scope=read,activity:read_all&redirect_uri=localhost:5000/callback"));
            var authTokenResponse = externalAPICaller.Get<FakeResponseServer.DTO.StravaAuthenticationTokenResponse>(new Uri("http://localhost:2222/oauth/token?client_id=1234&client_secret=23456&grant_type=authorization_code&code=" + exchangeTokenResponse.code));
            return new JsonResult(authTokenResponse);
        }

        public async Task<JsonResult> GetFitBitAuthenticationToken()
        {
            await Task.Delay(0);
            var exchangeTokenResponse = externalAPICaller.Get<FakeResponseServer.DTO.FitBitExchangeTokenResponse>(new Uri("http://localhost:2222/oauth2/authorize?response_type=code&client_id=22CCZ8&redirect_uri=http://localhost:5002/fitbittoken&scope=activity%20heartrate"));
            var authTokenResponse = externalAPICaller.Get<FakeResponseServer.DTO.FitBitAuthenticationTokenResponse>(new Uri("http://localhost:2222/oauth2/token?client_id=22CCZ8&grant_type=authorization_code&redirect_uri=http://localhost:5002/fitbittoken&code=" + exchangeTokenResponse.Code));
            return new JsonResult(authTokenResponse);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetSpotifyRecentlyPlayed(SpotifyAuthenticationToken authToken, long? after = null)
        {
            await Task.Delay(0);
            var requesturiString = string.Format("http://localhost:2222/v1/me/player/recently-played?after={0}",after);
            var musicHistory = externalAPICaller.Get<CursorPaging<FakeResponseServer.DTO.PlayHistoryItem>>(new Uri(requesturiString));
            var correctMusicHistory = new CursorPaging<PlayHistoryItem>
            {
                Items = new List<PlayHistoryItem>()
            };
            foreach (var item in musicHistory.Items)
            {
                correctMusicHistory.Items.Add(new PlayHistoryItem
                {
                    Context = new Context
                    {
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = item.Context.Href,
                        Type = item.Context.Type,
                        Uri = item.Context.Uri
                    },
                    PlayedAt = (DateTime)item.PlayedAt,
                    Track = new SimpleTrack
                    {
                        Artists = new List<SimpleArtist>(),
                        AvailableMarkets = new List<string>(),
                        DiscNumber = item.Track.DiscNumber,
                        DurationMs = item.Track.DurationMs,
                        Explicit = item.Track.Explicit,
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = item.Track.Href,
                        Id = item.Track.Id,
                        IsPlayable = item.Track.IsPlayable,
                        LinkedFrom = new LinkedTrack
                        {
                            ExternalUrls = new Dictionary<string, string>(),
                            Href = item.Track.LinkedFrom.Href,
                            Id = item.Track.LinkedFrom.Id,
                            Type = item.Track.LinkedFrom.Type,
                            Uri = item.Track.LinkedFrom.Uri,
                        },
                        Name = item.Track.Name,
                        PreviewUrl = item.Track.PreviewUrl,
                        TrackNumber = item.Track.TrackNumber,
                        Type = ItemType.Track,
                        Uri = item.Track.Uri
                    }
                });;
            }
            return new JsonResult(correctMusicHistory);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetStravaActivityHistory(StravaAuthenticationToken authToken)
        {
            await Task.Delay(0);
            var activityHistory = externalAPICaller.Get<List<FakeResponseServer.DTO.Activity>>(new Uri("http://localhost:2222/v3/athlete/activities"));
            var correctActivityHistory = new List<Activity>();
            foreach (var item in activityHistory)
            {
                correctActivityHistory.Add(new Activity
                {
                    achievement_count = item.achievement_count,
                    athlete = new Athlete
                    {
                        badge_type_id = item.athlete.badge_type_id,
                        city = item.athlete.city,
                        country = item.athlete.country,
                        created_at = item.athlete.created_at,
                        firstname = item.athlete.firstname,
                        follower = item.athlete.follower,
                        friend = item.athlete.friend,
                        id = item.athlete.id,
                        lastname = item.athlete.lastname,
                        premium = item.athlete.premium,
                        profile = item.athlete.profile,
                        profile_medium = item.athlete.profile_medium,
                        resource_state = item.athlete.resource_state,
                        sex = item.athlete.sex,
                        state = item.athlete.state,
                        summit = item.athlete.summit,
                        updated_at = item.athlete.updated_at,
                        username = item.athlete.username
                    },
                    athlete_count = item.athlete_count,
                    average_cadence = item.average_cadence,
                    average_heartrate = item.average_heartrate,
                    average_speed = item.average_speed,
                    average_temp = item.average_temp,
                    comment_count = item.comment_count,
                    commute = item.commute,
                    display_hide_heartrate_option = item.display_hide_heartrate_option,
                    distance = item.distance,
                    elapsed_time = item.elapsed_time,
                    elev_high = item.elev_high,
                    elev_low = item.elev_low,
                    end_latlng = item.end_latlng,
                    external_id = item.external_id,
                    flagged = item.flagged,
                    from_accepted_tag = item.from_accepted_tag,
                    gear_id = item.gear_id,
                    has_heartrate = item.has_heartrate,
                    has_kudoed = item.has_kudoed,
                    heartrate_opt_out = item.heartrate_opt_out,
                    id = item.id,
                    kudos_count = item.kudos_count,
                    location_city = item.location_city,
                    location_country = item.location_country,
                    location_state = item.location_state,
                    manual = item.manual,
                    map = new Map
                    {
                        id = item.map.id,
                        resource_state = item.map.resource_state,
                        summary_polyline = item.map.summary_polyline
                    },
                    max_heartrate = item.max_heartrate,
                    max_speed = item.max_speed,
                    moving_time = item.moving_time,
                    name = item.name,
                    photo_count = item.photo_count,
                    Private = item.Private,
                    pr_count = item.pr_count,
                    resource_state = item.resource_state,
                    start_date = item.start_date,
                    start_date_local = item.start_date_local,
                    start_latitude = item.start_latitude,
                    start_latlng = item.start_latlng,
                    start_longitude = item.start_longitude,
                    timezone = item.timezone,
                    total_elevation_gain = item.total_elevation_gain,
                    total_photo_count = item.total_photo_count,
                    trainer = item.trainer,
                    type = item.type,
                    upload_id = item.upload_id,
                    upload_id_str = item.upload_id_str,
                    utc_offset = item.utc_offset,
                    visibility = item.visibility,
                    workout_type = item.workout_type,
                });
            }
            return new JsonResult(correctActivityHistory);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetFitBitActivityHistory(FitBitAuthenticationToken authToken)
        {
            await Task.Delay(0);
            var fitBitActivityHistory = externalAPICaller.Get<ActivityLogsList>(new Uri("http://localhost:2222/1/user/-/activities"));
            return new JsonResult(fitBitActivityHistory);
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetLastFMAuthenticationToken()
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<JsonResult> GetLastFMRecentlyPlayed(LastFMAuthenticationToken authToken, long? after = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }
    }
}
