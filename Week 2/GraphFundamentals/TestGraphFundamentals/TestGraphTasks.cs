using GraphFundamentals;
using System.ComponentModel;

namespace TestGraphFundamentals;

[TestClass]
public class TestGraphTasks
{
    [TestMethod]
    public void TestDetectCycleGivenGraphWithCycle()
    {
        //Arrange
        List<List<int>> graphC = new List<List<int>>();
        graphC.Add(new List<int>() { 1 });
        graphC.Add(new List<int>() { 2 });
        graphC.Add(new List<int>() { 3, 0 });
        graphC.Add(new List<int>());

        //Act
        bool existCycle = GraphCycleDetector.DetectCycle(graphC);

        //Assert
        Assert.IsTrue(existCycle);
    }

    [TestMethod]
    public void TestDetectCycleGivenGraphWithoutCycle()
    {
        //Arrange
        List<List<int>> graphC = new List<List<int>>();
        graphC.Add(new List<int>() { 1 });
        graphC.Add(new List<int>() { 2 });
        graphC.Add(new List<int>() { 3 });
        graphC.Add(new List<int>());

        //Act
        bool existCycle = GraphCycleDetector.DetectCycle(graphC);

        //Assert
        Assert.IsFalse(existCycle);
    }

    [TestMethod]
    public void TestCalculateFieldsGivenNonCyclicGraph()
    {
        //Arrange
        List<List<int>> graph = new List<List<int>>();
        graph.Add(new List<int>() { 1, 2 }); // 0 = 1+2
        graph.Add(new List<int>()); // 1 is numeric
        graph.Add(new List<int>()); //2 is numeric
        graph.Add(new List<int>() { 4 }); // 3 = 4
        graph.Add(new List<int>()); //4 is numeric

        Dictionary<int, int> expectedCalculatedValues = new Dictionary<int, int>()
        {
            {0,3 },
            {1, 1},
            {2,2 },
            {3,4 },
            {4,4 }
        };

        //Act 
        Dictionary<int, int> actualCalculatedValues = CalculateValueOfFieldsFunction.CalculateFields(graph);

        //Assert
        CollectionAssert.AreEqual(expectedCalculatedValues, actualCalculatedValues);
    }

    [TestMethod]
    public void TestCalculateFieldsGivenCyclicGraph()
    {
        //Arrange
        List<List<int>> graph = new List<List<int>>();
        graph.Add(new List<int>() { 1, }); // 0 depends on 1 
        graph.Add(new List<int> { 0 }); // 1 depends on 0


        //Act + Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            CalculateValueOfFieldsFunction.CalculateFields(graph);
        });
    }
    [TestMethod]
    public void TestIsHamiltonianGivenHamiltonianGraph()
    {
        //Arrange
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        graph.Add("A", new List<string>() { "B", "C" });
        graph.Add("B", new List<string>() { "C", "E", "A" });
        graph.Add("C", new List<string>() { "D", "B", "A" });
        graph.Add("D", new List<string>() { "E", "C" });
        graph.Add("E", new List<string>() { "B", "D" });

        //Act
        bool isHamiltonian = HamiltonianPath.IsHamiltonian(graph,"A");

        //Assert
        Assert.IsTrue(isHamiltonian);
    }
    [TestMethod]
    public void TestIsHamiltonianGivenNonHamiltonianGraph()
    {
        //Arrange
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        graph.Add("A", new List<string>() { "B" });
        graph.Add("B", new List<string>() { "C", "E" });
        graph.Add("C", new List<string>() { "D", "B"});
        graph.Add("D", new List<string>() { "E", "C","F" });
        graph.Add("E", new List<string>() { "B", "D" });
        graph.Add("F", new List<string>() { "D"});

        //Act
        bool isHamiltonian = HamiltonianPath.IsHamiltonian(graph, "A");

        //Assert
        Assert.IsFalse(isHamiltonian);
    }

    [TestMethod]
    public void TestCalculatePathTimeCost()
    {
        //Arrange 
        int numberNodes = 4;
        int numberEdges = 5;
        int pricePerHour = 1000;
        List<string> edgeData = new List<string>()
        {
            "1 2 1 2500",
            "1 3 1 3000",
            "1 4 2 7000",
            "2 4 1 3000",
            "3 4 1 2000"
        };
        int startNode = 1;
        int endNode = 4;

        string expected = "1-> 3-> 4 3 8000";
        //Act
        string actual = Djikstra.CalculatePathTimeCost(pricePerHour,numberNodes,numberEdges,edgeData,startNode,endNode);

        //Assert
        Assert.AreEqual(expected, actual);  
    }

}