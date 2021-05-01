namespace RD.CanMusicMakeYouRunFaster.Rest.Entity.Utils
{
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Utility DateConverter class, used to override the default date conversion.
    /// </summary>
    public class DateConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateConverter"/> class.
        /// </summary>
        public DateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
