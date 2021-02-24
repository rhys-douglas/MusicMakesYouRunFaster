namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models.Strava
{
    /// <summary>
    /// Class used for representing geographical position
    /// </summary>
    public class LatLng
    {
        /// <summary>
        /// WGS84 latitude
        /// </summary>
        public float Latitude { get; set; }
        /// <summary>
        /// WGS84 longitude
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// Determines if the object is empty.
        /// </summary>
        /// <returns> Boolean if the latlng is empty. </returns>
        public bool IsEmpty()
        {
            return Latitude.Equals(0.0f) && Longitude.Equals(0.0f);
        }

        /// <summary>
        /// Determines if this <see cref="LatLng"/> is equal to another.
        /// </summary>
        /// <param name="latLng"> Other LatLng to compare to.</param>
        /// <returns> Boolean if the LatLng is equal. </returns>
        public bool Equals(LatLng latLng)
        {
            return latLng.Latitude == Latitude && latLng.Longitude == Longitude;
        }

    }
}
