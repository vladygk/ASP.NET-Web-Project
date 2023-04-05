namespace OOP_EncapsulationInheritance;

using Behaviour;
using Biomes;
using IO;
using Statistics;
    public class StartUp
    {
       

        static void Main()
        {

            
            Random rnd = new Random();
           
            bool getDetailedStatistics = true;
            IStatistics statistics = new EnglishStatistics();
            IWriter writer = ConsoleWriter.Instance;
            IBehaviour behaviour = new BehaviourEnglish();

            var biomeTypes = new Func<IBiome>[]
            {
                new NormalBiome().Instantiate,
                new OceanBiome().Instantiate
            };

            Map map = new Map(2, biomeTypes, rnd);

            Simulation simulation = new Simulation(rnd,statistics, map, writer,getDetailedStatistics, behaviour);

            simulation.Start();
            
            
        }
    }
