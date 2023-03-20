using Complexity_fundamentals;
using System.Numerics;

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
            BigInteger expected = 9;
            //Act
            BigInteger actual = ComplexityFundamentals.FindCubicRoot(input);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFindCubicRootGivenMaxInt()
        {
            //Arrange
            int input = 2_146_689_000;
            BigInteger expected =(BigInteger) Math.Round(Math.Cbrt(input));
            //Act
            BigInteger actual = ComplexityFundamentals.FindCubicRoot(input);

            //Assert

            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void TestFindCubicRootGivenZero()
        {
            //Arrange
            int input = 0;
            BigInteger expected = 0;
            //Act
            BigInteger actual = ComplexityFundamentals.FindCubicRoot(input);

            //Assert

            Assert.AreEqual(expected, actual);
        }

    }

}