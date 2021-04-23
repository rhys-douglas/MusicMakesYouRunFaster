namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO.Request
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Request class for holding params to the Last FM "Get recent tracks" controller.
    /// </summary>
    public class LastFMGetRecentTracksRequest
    {
        [FromQuery(Name = "api_key")]
        public string ApiKey { get; set; }

        [FromQuery(Name = "user")]
        public string User { get; set; }

        [FromQuery(Name = "from")]
        public long? From { get; set; } = default!;
    }
}
