using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance
{
    public class StartUp
    {
       

        static void Main(string[] args)
        {

            
            Random rnd = new Random();
            bool getDetailedStatistics = true;
            IStatistics statistics = new ConsoleStatistics();
            IBiom biom = new Biom();
            Simulation simulation = new Simulation(rnd,statistics,biom, getDetailedStatistics);

            simulation.Start();
            
            
        }
    }
}