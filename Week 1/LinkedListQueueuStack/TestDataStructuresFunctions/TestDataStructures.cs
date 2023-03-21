namespace TestDataStructuresFunctions
{
    using DataStructuresFund;
    [TestClass]
    public class TestDataStructures
    {
        [TestMethod]
        public void TestReturnUniqueElementsdGivenListOfFive()
        {
            //Arrange
            List<int> input = new List<int>() { 10, 10, 20, 30, 30, 30 };
            List<int> expected = new List<int>() { 10, 20, 30 };
            //Act
            List<int> actual = DataStructuresFunctions<int>.ReturnUniqueElements(input);
            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestReturnUniqueElementsdGivenListOfOne()
        {
            //Arrange
            List<int> input = new List<int>() { 10 };
            List<int> expected = new List<int>() { 10 };
            //Act
            List<int> actual = DataStructuresFunctions<int>.ReturnUniqueElements(input);
            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestReturnUniqueElementsdEmptyList()
        {
            //Arrange
            List<int> input = new List<int>();
            List<int> expected = new List<int>();
            //Act
            List<int> actual = DataStructuresFunctions<int>.ReturnUniqueElements(input);
            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestEraseTheMiddleElementWithFiveElements()
        {
            //Arrange
            LinkedList<int> input = new LinkedList<int>(new List<int>() { 1, 2, 3, 4, 5 });
            LinkedList<int> expected = new LinkedList<int>(new List<int>() { 1, 2, 4, 5 });
            // Act
            LinkedList<int> actual = DataStructuresFunctions<int>.EraseTheMiddleElement(input);

            //Assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestEraseTheMiddleElementWithOneElements()
        {
            //Arrange
            LinkedList<int> input = new LinkedList<int>(new List<int>() { 1 });
            LinkedList<int> expected = new LinkedList<int>(new List<int>());
            // Act
            LinkedList<int> actual = DataStructuresFunctions<int>.EraseTheMiddleElement(input);

            //Assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestEraseTheMiddleElementWithFourElements()
        {
            //Arrange
            LinkedList<int> input = new LinkedList<int>(new List<int>() { 1, 2, 3, 4 });
            LinkedList<int> expected = new LinkedList<int>(new List<int>() { 1, 2, 4 });
            // Act
            LinkedList<int> actual = DataStructuresFunctions<int>.EraseTheMiddleElement(input);

            //Assert
            CollectionAssert.AreEqual(actual, expected);
        }



        [TestMethod]
        public void TestEraseTheMiddleElementWithEmptyList()
        {
            //Arrange
            LinkedList<int> input = new LinkedList<int>();
            LinkedList<int> expected = new LinkedList<int>();
            // Act
            LinkedList<int> actual = DataStructuresFunctions<int>.EraseTheMiddleElement(input);

            //Assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestSolveTowersOfHonoi()
        {
            //Arrange 
            Stack<int> input = new Stack<int>(new int[] { 30,20,10 });
            Stack<int> expected = new Stack<int>(new int[] { 30,20,10 });

            //Act
            Stack<int> actual= DataStructuresFunctions<int>.SolveTowersOfHonoi(input);

            //Assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestExpressionExpanderWithoutNestedBrackets()
        {
            //Arrange
            string input = "AB3(C)4(DE)F";
            string expected = "ABCCCDEDEDEDEF";

            //Act
            string actual = DataStructuresFunctions<int>.ExpressionExpander(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestExpressionExpanderWithNestedBrackets()
        {
            //Arrange
            string input = "AB2(C2(X))F";
            string expected = "ABCXXCXXF";

            //Act
            string actual = DataStructuresFunctions<int>.ExpressionExpander(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestExpressionExpanderWithTripleNestedBrackets()
        {
            //Arrange
            string input = "AB2(C2(X2(R)))F";
            string expected = "ABCXRRXRRCXRRXRRF";

            //Act
            string actual = DataStructuresFunctions<int>.ExpressionExpander(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestShuntingYardParser()
        {
            //Arange
            string input = "1+2/2-3";
            Queue<char > exptected = new Queue<char>(new List<char>() { '1', '2', '+', '2', '/', '3', '-' }) ;

            //Act
            Queue<char> actual = DataStructuresFunctions<int>.ShuntingYardParser(input);

            //Assert
            CollectionAssert.AreEqual(exptected, actual);   
        }

        [TestMethod]
        public void TestEvaluate()
        {
            //Arrange
            Queue<char> input = new Queue<char>(new List<char>() { '1', '2', '-', '4', '*' });
            int exptected = -4;
            //Act
            int actual = DataStructuresFunctions<int>.Evaluate(input);
            //Assert
            Assert.AreEqual(exptected,actual);  
        }
    }
}