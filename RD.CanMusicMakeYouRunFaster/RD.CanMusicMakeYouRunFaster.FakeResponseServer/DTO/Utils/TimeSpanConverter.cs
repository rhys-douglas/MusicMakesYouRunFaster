namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO.Utils
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Time span converter class, used to 
    /// </summary>
    public class TimeSpanConverter :JsonConverter<TimeSpan>
    {
        public const string TimeSpanFormatString = @"d\.hh\:mm\:ss\:FFF";

        /// <summary>
        /// Converts TimeSpan to valid json.
        /// </summary>
        /// <param name="writer">JsonWriter.</param>
        /// <param name="ts">Timespan to convert.</param>
        /// <param name="serializer">JsonSerializer to use.</param>
        public override void WriteJson(JsonWriter writer, TimeSpan ts, JsonSerializer serializer)
        {
            var timespanFormatted = $"{ts.ToString(TimeSpanFormatString)}";
            writer.WriteValue(timespanFormatted);
        }

        /// <summary>
        /// Reads JSON and outputs a timeSpan.
        /// </summary>
        /// <param name="reader">JsonReader.</param>
        /// <param name="objectType">Object type to convert to</param>
        /// <param name="ts">TimeSpan.</param>
        /// <param name="hasExistingValue">Bool if there is an existing value</param>
        /// <param name="serializer"> Json serializer to use.</param>
        /// <returns> Deserialized json in a TimeSpan.</returns>
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan ts, bool hasExistingValue, JsonSerializer serializer)
        {
            TimeSpan parsedTimeSpan;
            TimeSpan.TryParseExact((string)reader.Value, TimeSpanFormatString, null, out parsedTimeSpan);
            return parsedTimeSpan;
        }
    }
}
