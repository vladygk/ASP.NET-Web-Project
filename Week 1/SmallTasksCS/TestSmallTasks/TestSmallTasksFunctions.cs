using SmallTasksCS;
namespace TestSmallTasks
{
    public class Tests
    {

        [SetUp]


        [Test]
        public void TestIsOddWithOddInput()
        {
            //Arrange
            bool exptected = true;

            //Act

            bool actual = SmallTasksFunctions.isOdd(1);

            //Assert

            Assert.That(actual, Is.EqualTo(exptected));
        }

        [Test]
        public void TestIsOddWithEventInput()
        {
            //Arrange
            bool exptected = false;

            //Act

            bool actual = SmallTasksFunctions.isOdd(2);

            //Assert

            Assert.That(actual, Is.EqualTo(exptected));
        }

        [Test]
        public void TestIsPrimeWithPrimeInput()
        {
            //Arrange
            bool exptected = true;

            //Act

            bool actual = SmallTasksFunctions.isPrime(23);

            //Assert

            Assert.That(actual, Is.EqualTo(exptected));
        }

        [Test]
        public void TestIsPrimeWithNotPrimeInput()
        {
            //Arrange
            bool exptected = false;

            //Act

            bool actual = SmallTasksFunctions.isPrime(4);

            //Assert

            Assert.That(actual, Is.EqualTo(exptected));
        }

        [Test]
        public void TestIsPrimeWithNegativeInput()
        {
            //Arrange
            bool exptected = false;

            //Act

            bool actual = SmallTasksFunctions.isPrime(-4);

            //Assert

            Assert.That(actual, Is.EqualTo(exptected));
        }
       
    }
}