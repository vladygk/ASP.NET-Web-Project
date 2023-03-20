using Complexity_fundamentals;

namespace TestComplexityFundamentalsHomework
{
    [TestClass]
    public class TestComplexityFunctions
    {
        [TestMethod]
        public void TestFindMissingNumberGivenArrayWithFiveNumbers()
        {
            //Arrange
            int[] arr = new int[] { 4, 5, 1, 2, 6 };
            int expected = 3;
            //Act
            int actual = ComplexityFundamentals.FindMissing(arr);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFindMissingNumberGivenArrayWithOneNumbers()
        {
            //Arrange
            int[] arr = new int[] { 1 };
            int expected = -1;
            //Act
            int actual = ComplexityFundamentals.FindMissing(arr);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFindMissingNumberGivenEmptyArray()
        {
            //Arrange
            int[] arr = new int[0];

            //Act  & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ComplexityFundamentals.FindMissing(arr);
            });
        }

        [TestMethod]
        public void TestFindCubicRootGivenPositiveNumber()
        {
            //Arrange
            int input = 729;
            int expected = 9;
            //Act
            int actual = ComplexityFundamentals.FindCubicRoot(input);

            //Assert

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestFindCubicRootGivenNegativeNumber()
        {
            //Arrange
            int input = -729;
            int expected = -9;
            //Act
            int actual = ComplexityFundamentals.FindCubicRoot(input);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFindCubicRootGivenZero()
        {
            //Arrange
            int input = 0;
            int expected = 0;
            //Act
            int actual = ComplexityFundamentals.FindCubicRoot(input);

            //Assert

            Assert.AreEqual(expected, actual);
        }

    }

}