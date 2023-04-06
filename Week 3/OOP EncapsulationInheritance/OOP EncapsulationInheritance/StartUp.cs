namespace OOP_EncapsulationInheritance;

using Behaviour;
using IO;
using Statistics;
public class StartUp
{
    static void Main()
    {
        Random rnd = new Random();
        bool getDetailedStatistics = true;
        IStatistics statistics = new Statistics.Statistics();
        IWriter writer = ConsoleWriter.Instance;
        IBehaviour behaviour = new Behaviour.Behaviour();

        int numberOfElementsForEachType = 2;
        Map map = new Map(2, rnd, numberOfElementsForEachType);

        Simulation simulation = new Simulation(rnd, statistics, map, writer, getDetailedStatistics, behaviour);

        simulation.Start();
    }
}