using OOP_EncapsulationInheritance.Behaviour;
using OOP_EncapsulationInheritance.Biomes;
using OOP_EncapsulationInheritance.IO;
using OOP_EncapsulationInheritance.Statistics;

namespace OOP_EncapsulationInheritance
{
    public class StartUp
    {
       

        static void Main()
        {

            
            Random rnd = new Random();
            bool getDetailedStatistics = true;
            IStatistics statistics = new ConsoleStatistics();
            IWriter writer = ConsoleWriter.Instance;
            IBehaviour behaviour = new BehaviourEnglish();
            IBiome normalBiome = new NormalBiome();

            Simulation simulation = new Simulation(rnd,statistics, normalBiome, writer,getDetailedStatistics, behaviour);

            simulation.Start();
            
            
        }
    }
}