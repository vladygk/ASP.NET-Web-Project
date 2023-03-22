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
        graph.Add(new List<int>() { 1,}); // 0 depends on 1 
        graph.Add(new List<int> { 0 }); // 1 depends on 0
    

        //Act + Assert
        Assert.ThrowsException<ArgumentException>(() =>
        {
            CalculateValueOfFieldsFunction.CalculateFields(graph);
        });
    }
}