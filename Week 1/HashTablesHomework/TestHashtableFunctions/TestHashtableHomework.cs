using HashTablesHomework;

namespace TestHashtableFunctions
{
    [TestClass]
    public class TestHashtableHomework
    {
        [TestMethod]
        public void TestGetCoolestCarAndTheownersWithMoreThanOneCar()
        {
            //Arrange
            string expectedCoolPlateOwner = "Ivan";
            List<string> expectedOnwersWithMultipleCars = new List<string>() {"Ivan"
            };

            //Act
            string actualCoolPlateOwner = string.Empty;
            List<string> actualOnwersWithMultipleCars = HashTableFunctions.GetCoolestCarAndTheownersWithMoreThanOneCar(out actualCoolPlateOwner);

            //Assert

            Assert.AreEqual(actualCoolPlateOwner, expectedCoolPlateOwner);
            CollectionAssert.AreEqual(actualOnwersWithMultipleCars, expectedOnwersWithMultipleCars);
        }

        [TestMethod]
        public void TestFindIntersectionOfTwoArraysWithIntersectingElements()
        {
            //Arrange
            int[] arrA = new int[] { 1, 2, 3, 4, 5 };
            int[] arrB = new int[] { 1, 2 };

            int[] expected = new int[] { 1, 2 };
            //Act 

            int[] actual = HashTableFunctions.FindIntersectionOfTwoArrays(arrA, arrB);

            //Assert
            CollectionAssert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void TestFindIntersectionOfTwoArraysWithoutIntersectingElements()
        {
            //Arrange
            int[] arrA = new int[] { 1, 2, 3, 4, 5 };
            int[] arrB = new int[] { 6,7 };

            int[] expected = Array.Empty<int>();
            //Act 

            int[] actual = HashTableFunctions.FindIntersectionOfTwoArrays(arrA, arrB);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFindIntersectionOfTwoEmptyArrays()
        {
            //Arrange
            int[] arrA = Array.Empty<int>();
            int[] arrB = Array.Empty<int>();

            int[] expected = Array.Empty<int>();
            //Act 

            int[] actual = HashTableFunctions.FindIntersectionOfTwoArrays(arrA, arrB);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFindUniqueCharsGivenUniqueChars()
        {
            //Arrange 
            string input = "aabcvc";
            int expectedIndex = 2;
            List<char> exptectedList = new List<char>() { 'b', 'v' };

            //Act
            int actualIndex = -1;
            List<char> actualList = HashTableFunctions.FindUniqueChars(input, out actualIndex);

            //Assert
            Assert.AreEqual(expectedIndex, actualIndex);
            CollectionAssert.AreEqual(exptectedList, actualList);
        }

        [TestMethod]
        public void TestFindUniqueCharsWithoutUniqueChars()
        {
            //Arrange 
            string input = "aabbcc";
            int expectedIndex = -1;
            List<char> exptectedList = new List<char>();

            //Act
            int actualIndex = -1;
            List<char> actualList = HashTableFunctions.FindUniqueChars(input, out actualIndex);

            //Assert
            Assert.AreEqual(expectedIndex, actualIndex);
            CollectionAssert.AreEqual(exptectedList, actualList);
        }
    }
}