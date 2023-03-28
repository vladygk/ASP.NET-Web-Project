using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Animals.Carnivore;
using OOP_EncapsulationInheritance.Animals.Herbivore;
using OOP_EncapsulationInheritance.Animals.Omnivore;
using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();
            animals.Add(new Zebra());
            animals.Add(new Lion());
            animals.Add(new Bear());

            List<FoodType> food = new List<FoodType>();
            food.Add(new Meat());
            food.Add(new Vegetable());
            food.Add(new IceCream());
            food.Add(new Bone());
            food.Add(new Pizza());
            food.Add(new Fruit());
            Random rnd = new Random();
            Controller simulation = new Controller(animals, food, rnd);

            simulation.Simulate();
            string stats = simulation.GetStatistics();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(stats);
            
        }
    }
}