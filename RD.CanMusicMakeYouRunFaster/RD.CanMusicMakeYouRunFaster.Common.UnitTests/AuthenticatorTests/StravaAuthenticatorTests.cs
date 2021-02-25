namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.AuthenticatorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Authenticators;

    public class StravaAuthenticatorTests
    {
        [Test]
        public void StravaAuthenticatorInstantiated_ObjectIsNotNull()
        {
            var sut = new StravaAuthenticator();
            sut.Should().NotBeNull();
        }
    }
}
