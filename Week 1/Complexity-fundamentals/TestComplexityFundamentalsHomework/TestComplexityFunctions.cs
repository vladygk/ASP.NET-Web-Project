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
            double[] arr = new double[] { 4, 5, 1, 2, 6 };
            double expected = 3;
            //Act
            double actual = ComplexityFundamentals.FindMissing(arr);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFindMissingNumberGivenArrayWithOneNumbers()
        {
            //Arrange
            double[] arr = new double[] { 1 };
            double expected = -1;
            //Act  & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ComplexityFundamentals.FindMissing(arr);
            });
        }

        [TestMethod]
        public void TestFindMissingNumberGivenEmptyArray()
        {
            //Arrange
            double[] arr = new double[0];

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
            double expected = 9;
            //Act
            double actual = ComplexityFundamentals.FindCubicRoot(input);

            //Assert

            Assert.AreEqual(expected, actual);
        }
    

        [TestMethod]
        public void TestFindCubicRootGivenZero()
        {
            //Arrange
            int input = 0;
            double expected = 0;
            //Act
            double actual = ComplexityFundamentals.FindCubicRoot(input);

            //Assert

            Assert.AreEqual(expected, actual);
        }

    }

}