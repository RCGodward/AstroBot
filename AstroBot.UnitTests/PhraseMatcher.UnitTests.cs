
namespace AstroBot.UnitTests
{
    [TestFixture]
    public class PhraseMatcher
    {
        private AstroBot.PhraseMatcher Subject;

        [SetUp]
        public void Setup()
        {
            Subject = new AstroBot.PhraseMatcher();
        }

        [TestCase("Astros")]
        [TestCase("AsTrOs")]
        [TestCase("Yankees")]
        public void IsMatch_Returns_True_When_Phrase_Should_Match(string message)
        {
            Assert.True(Subject.IsMatch(message));
        }

        [TestCase("Guardians")]
        // Thanks Brendan
        [TestCase("Kwan has stepped up for post season again")]
        [TestCase("In the replay, you can see that Thomas was likely being blinded even through those sunglasses.")]
        public void IsMatch_Returns_False_When_Phrase_Should_Not_Match(string message)
        {
            Assert.False(Subject.IsMatch(message));
        }
    }
}
