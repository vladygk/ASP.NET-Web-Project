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
            Assert.That(actual, Is.EqualTo(expected));
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

        [Test]
        public void TestGetOddOccurrenceWithCorrectInput()
        {
            //Arrange
            int[] array = { 1, 1, 2 };
            int expected = 2;

            //Act
            int actual = SmallTasksFunctions.GetOddOccurrence(array);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestGetOddOccurrenceShouldThrowErrorIfNoSuchNumber()
        {
            //Arrange
            int[] array = { 1, 1 };

            //Act + Assert

            Assert.Throws<ArgumentException>(() =>
            {
                SmallTasksFunctions.GetOddOccurrence(array);
            });
        }
        [Test]
        public void TestGetAverageWithCorrectInput()
        {
            //Arrange
            int[] array = { 4, 6, 5 };
            int expected = 5;

            //Act
            int actual = SmallTasksFunctions.GetAverage(array);

            //Assert

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestPowWithCorrectInput()
        {
            //Arrange 
            int a = 5;
            int b = 2;
            long expected = 25;

            //Act 

            long actual = SmallTasksFunctions.pow(a, b);

            //Assert

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestGetSmallestMultipleWithCorrectInput()
        {
            //Arrange 
            int N = 7;
            long expected = 420;

            //Act

            long actual = SmallTasksFunctions.GetSmallestMultiple(N);

            //Assert

            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestGetSmallestMultipleWithZeroInputThrowsException()
        {
            //Arrange
            int N = 0;

            //Act + Assert
            Assert.Throws<ArgumentException>(() =>
            {
                SmallTasksFunctions.GetSmallestMultiple(N);
            });
        }
        [Test]
        public void TestDoubleFacWorksWithPositiveNumber()
        {
            // Arrange
            int n = 3;
            long expected = 720;

            // Act 
            long actual = SmallTasksFunctions.DoubleFac(n);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestDoubleFacWorksWithZero()
        {
            // Arrange
            int n = 0;
            long expected = 1;

            // Act 
            long actual = SmallTasksFunctions.DoubleFac(n);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestDoubleFacThrowsEceptionWithNegativeNumber()
        {
            // Arrange
            int n = -3;


            // Act + Assert

            Assert.Throws<InvalidOperationException>(() =>
            {
                SmallTasksFunctions.DoubleFac(n);
            });
        }

        [Test]
        public void TestKthFacWorksWithCorrectInput()
        {
            //Arrange
            int n = 3;
            int k = 2;
            long expected = 720;

            //Act
            long actual = SmallTasksFunctions.KthFac(k, n);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestEqualSumSidesWithExpectedOutputTrue()
        {
            //Arrange
            int[] array = { 6, 2, 2,4 };
            
            //Act 
            bool actual = SmallTasksFunctions.EqualSumSides(array);

            //Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void TestEqualSumSidesWithExpectedOutputFalse()
        {
            //Arrange
            int[] array = { 6, 2, 2};

            //Act 
            bool actual = SmallTasksFunctions.EqualSumSides(array);

            //Assert
            Assert.That(actual, Is.False);
        }
    }
}