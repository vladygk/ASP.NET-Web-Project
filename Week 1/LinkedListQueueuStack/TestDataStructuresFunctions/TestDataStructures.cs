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
            
            // Act
            bool actual = DataStructuresFunctions<int>.EraseTheMiddleElement(input);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestEraseTheMiddleElementWithOneElements()
        {
            //Arrange
            LinkedList<int> input = new LinkedList<int>(new List<int>() { 1 });
            
            // Act
            bool actual = DataStructuresFunctions<int>.EraseTheMiddleElement(input);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestEraseTheMiddleElementWithFourElements()
        {
            //Arrange
            LinkedList<int> input = new LinkedList<int>(new List<int>() { 1, 2, 3, 4 });
            
            // Act
            bool actual = DataStructuresFunctions<int>.EraseTheMiddleElement(input);

            //Assert
            Assert.IsTrue(actual);
        }



        [TestMethod]
        public void TestEraseTheMiddleElementWithEmptyList()
        {
            //Arrange
            LinkedList<int> input = new LinkedList<int>();
            
            // Act
           bool actual = DataStructuresFunctions<int>.EraseTheMiddleElement(input);

            //Assert
            Assert.IsFalse(actual);
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
        public void TestExpressionExpanderWithComplexInput()
        {
            //Arrange
            string input = "AB3(C)4(DE)F";
            string expected1 = "ABDCDCDCZZZZEGGGXYYWWWWWEGGGXYYWWWWW";
            string expected2 = "HAAAFFCHAAAFFCEE";
            string expected3 = "EE";

            string input1 = "AB3(DC)2(0(F)ZZ0(R)0(P))2(E3(G)X2(Y)5(W))0(H)";
            string input2 = "2(H3(A)2(F)C)2(E)";
            string input3 = "0(H3(A)2(F)C)2(E)";
            
            //Act
            string actual1 = DataStructuresFunctions<int>.ExpressionExpander(input1);
            string actual2 = DataStructuresFunctions<int>.ExpressionExpander(input2);
            string actual3 = DataStructuresFunctions<int>.ExpressionExpander(input3);
            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
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