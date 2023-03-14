using SmallTasksCS;
namespace TestSmallTasks
{
    public class Tests
    {
        SmallTasksFunctions smf;
        [SetUp]
        public void Setup()
        {
             smf = new SmallTasksFunctions();
        }

        [Test]
        public void TestIsOddWithOddInput()
        {
            //Arrange
            bool exptected = true;

            //Act

            bool actual = smf.isOdd(1);

            //Assert

            Assert.AreEqual(exptected, actual);
        }

        [Test]
        public void TestIsOddWithEventInput()
        {
            //Arrange
            bool exptected = false;

            //Act

            bool actual = smf.isOdd(2);

            //Assert

            Assert.AreEqual(exptected, actual);
        }
    }
}