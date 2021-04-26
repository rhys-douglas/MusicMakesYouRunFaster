namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Last FM Image set.
    /// </summary>
    public class LastImageSet
    {
        /// <summary>
        /// Uri of the smallest image.
        /// </summary>
        public Uri Small { get; set; }

        /// <summary>
        /// Uri of the medium size image.
        /// </summary>
        public Uri Medium { get; set; }

        /// <summary>
        /// Uri of the large size image.
        /// </summary>
        public Uri Large { get; set; }

        /// <summary>
        /// Uri of the extra large size image.
        /// </summary>
        public Uri ExtraLarge { get; set; }

        /// <summary>
        /// Uri of the mega size image.
        /// </summary>
        public Uri Mega { get; set; }

        /// <summary>
        /// Gets the largest image.
        /// </summary>
        public Uri Largest => Mega ?? ExtraLarge ?? Large ?? Medium ?? Small;
    }
}
