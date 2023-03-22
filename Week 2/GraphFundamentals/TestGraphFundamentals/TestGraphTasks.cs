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
}