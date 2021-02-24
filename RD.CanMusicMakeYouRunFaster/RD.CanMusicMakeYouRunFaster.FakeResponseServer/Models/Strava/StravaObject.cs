namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Strava
{
    /// <summary>
    /// Base class of Strava objects
    /// </summary>
    /// <typeparam name="T"> Identifier type</typeparam>
    public class StravaObject<T>
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public T Id { get; internal set; }
    }
}
