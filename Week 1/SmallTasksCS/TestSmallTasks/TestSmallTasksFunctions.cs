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


        [Test]
        public void TestMinWithCorrectInput()
        {
            //Arrange
            int expected = 1;
            int[] arr = { 5, 4, 10, 1 };
            //Act
            int actual = SmallTasksFunctions.Min(arr);
            // Assert

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestMinWithEmptyArraytInputThrowsException()
        {
            //Arrange          
            int[] arr = Array.Empty<int>();

            //Act + Assert

            Assert.Throws<InvalidOperationException>(
           () =>
           {
               SmallTasksFunctions.Min(arr);
           });
        }
        [Test]
        public void TestKthMinElementWithCorrectInput()
        {
            //Arrange
            int[] array = new int[] { 5, 4, 3, 2, 1 };
            int k = 3;
            int expected = 3;

            // Act 
            int actual = SmallTasksFunctions.KthMin(k, array);

            //Assert
            Assert.That(actual,Is.EqualTo(expected));
        }

        [Test]
        public void TestKthMinElementWithKBiggerThanArrayLength()
        {
            //Arrange
            int[] array = new int[] { 1, 2, 3 };
            int k = 5;
            //Act + Assert
            Assert.Throws<ArgumentException>(() =>
            {
                SmallTasksFunctions.KthMin(k, array);
            });
        }
    }
}