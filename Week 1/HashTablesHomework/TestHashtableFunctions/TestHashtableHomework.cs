using HashTablesHomework;
using ClassTasks;
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
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestFindIntersectionOfTwoArraysWithoutIntersectingElements()
        {
            //Arrange
            int[] arrA = new int[] { 1, 2, 3, 4, 5 };
            int[] arrB = new int[] { 6, 7 };

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

        [TestMethod]
        public void TestSpellCheckGivenASentence()
        {
            //Arrange
            string input = "Helo world, ho are you?";

            HashSet<string> correctWords = new HashSet<string>()
            {
                "hello",
                "world",
                "how",
                "are",
                "you"
            };

            List<string> expected = new List<string>()
            {
                "Helo",
                "ho"
            };
            //Act
            List<string> actual = HashTableFunctions.SpellChecker(input, correctWords);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSpellCheckGivenEmptyInput()
        {
            //Arrange
            string input = String.Empty;

            HashSet<string> correctWords = new HashSet<string>()
            {
                "hello",
                "world",
                "how",
                "are",
                "you"
            };

            List<string> expected = new List<string>();

            //Act
            List<string> actual = HashTableFunctions.SpellChecker(input, correctWords);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGroupByAnagrams()
        {
            //Arrange
            List<string> input = new List<string>()
            {
                "abba",
                "baba",
                "hell",
                "hlel",
                "hey"

            };
            Dictionary<SortedSet<char>, List<string>> expected =
                new Dictionary<SortedSet<char>, List<string>>();
            expected.Add(new SortedSet<char>()
            {
                'a',
               'b'
            }, new List<string>()
            {
                "abba",
                "baba"
            });

            expected.Add(new SortedSet<char>()
            {
                'h',
               'e',
               'l'
            }, new List<string>()
            {
                "hell",
                "hlel"
            });

            expected.Add(new SortedSet<char>()
            {
                'h',
               'e',
               'y'
            }, new List<string>()
            {
                "hey",

            });

            List<string> expectedGroup1 = new List<string>()
            {
                "abba",
                "baba"
            };

            List<string> expectedGroup2 = new List<string>()
            {
                 "hell",
                "hlel"
            };

            List<string> expectedGroup3 = new List<string>()
            {
                 "hey"
            };


            //Act
            var actual = HashTableFunctions.GroupByAnagrams(input);

            List<string> actualGroup1 = actual.Values.ToList()[0];

            List<string> actualGroup2 = actual.Values.ToList()[1];
            List<string> actualGroup3 = actual.Values.ToList()[2];
            //
            CollectionAssert.AreEqual(expectedGroup1, actualGroup1);

            CollectionAssert.AreEqual(expectedGroup2, actualGroup2);

            CollectionAssert.AreEqual(expectedGroup3, actualGroup3);
        }

        [TestMethod]
        public void TestUserAccountClass()
        {
            //Arrange 
            string username = "test";
            string password = "123";
            string expectedHashedPassword = @"a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3";
            //Act
            UserAccount user = new UserAccount(username, password);
            string actualHashedPassword = user.Password;

            //Assert
            Assert.AreEqual(expectedHashedPassword, actualHashedPassword);
        }

        [TestMethod]
        public void TestCustomGetHashUser()
        {
            //Arrange
            CustomGetHashUser user1 = new CustomGetHashUser("Pesho", "Peshov", 30);
            CustomGetHashUser user2 = new CustomGetHashUser("Pesho", "Peshov", 30);
            CustomGetHashUser user3 = new CustomGetHashUser("Pesho", "Peshov", 10);

            HashSet<CustomGetHashUser> expected = new HashSet<CustomGetHashUser>() { new CustomGetHashUser("Pesho", "Peshov", 30), new CustomGetHashUser("Pesho", "Peshov", 10) };

            //Act 
            HashSet<CustomGetHashUser> actual = new HashSet<CustomGetHashUser>() { user1,user2,user3 };

            bool areEqual = actual.SetEquals(expected);
            //Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestCustomHashTableInsert()
        {
            //Arrange
            CustomeHashTable<string, string> table = new CustomeHashTable<string, string>();
            string expected = "123";
            //Act 
            table.Insert("Ivan", "123");
            string actual = table["Ivan"];
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCustomHashTableFind()
        {
            //Arrange
            CustomeHashTable<string, string> table = new CustomeHashTable<string, string>();
            string expected = "123";
            table.Insert("Ivan", "123");
            //Act 
            string actual = table.FindValue("Ivan");
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCustomHashTableDelete()
        {
            //Arrange
            CustomeHashTable<string, string> table = new CustomeHashTable<string, string>();
            table.Insert("Ivan", "123");
            int expectedLength = 0;


            //Act 
            table.Delete("Ivan");
            int actualLength = table.Count;

            //Assert
            Assert.AreEqual(expectedLength, actualLength);
        }
    }
}