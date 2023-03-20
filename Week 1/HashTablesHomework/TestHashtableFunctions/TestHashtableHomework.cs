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
    }
}