namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using TechTalk.SpecFlow;

    [Binding]
    public class CommonSteps
    {
        [Given(@"a list of users")]
        public void GivenAListOfUsers(Table table)
        {
            // Temporarily redundant
        }

        [Given(@"a user [""]?([^""]*)[""]?")]
        public void GivenAUser(string user)
        {
            // Does something
        }
    }
}
