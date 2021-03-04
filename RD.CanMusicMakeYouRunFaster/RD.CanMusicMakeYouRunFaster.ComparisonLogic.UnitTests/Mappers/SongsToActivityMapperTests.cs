namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.UnitTests.Mappers
{
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.ComparisonLogic.Mappers;

    public class SongsToActivityMapperTests
    {
        private SongsToActivityMapper sut;

        [Test]
        public void MapWithCorrectParams_CorrectResultsReturned()
        {
            sut = new SongsToActivityMapper();
        }
    }
}
