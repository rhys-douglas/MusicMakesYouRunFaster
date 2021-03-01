namespace RD.CanMusicMakeYouRunFaster.Rest.Entity
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for holding list of activities.
    /// </summary>
    public class ActivityResponse
    {
        /// <summary>
        /// List of activties from request.
        /// </summary>
        public IList<Activity> ListOfActivities { get; set; }
    }
}
