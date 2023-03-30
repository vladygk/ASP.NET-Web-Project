using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Animals.Carnivore;
using OOP_EncapsulationInheritance.Animals.Herbivore;
using OOP_EncapsulationInheritance.Animals.Omnivore;
using OOP_EncapsulationInheritance.Contracts;
using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            
            Random rnd = new Random();
            bool getDetailedStatistics = true;

            Simulation simulation = new Simulation(rnd, getDetailedStatistics);

            simulation.Start();
            
            
        }
    }
}