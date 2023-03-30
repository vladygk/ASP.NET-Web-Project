using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Contracts;
using OOP_EncapsulationInheritance.Factories;

namespace OOP_EncapsulationInheritance;

public class Biom : IBiom
{
    public (IEnumerable<Animal>, IEnumerable<IEatable>) GenerateBiom()
    {
        Console.WriteLine("Desired number of Lions:");
        int lionNum = int.Parse(Console.ReadLine());
        Console.WriteLine("Desired number of Bears:");
        int bearNum = int.Parse(Console.ReadLine());
        Console.WriteLine("Desired number of Zebras:");
        int zebraNum = int.Parse(Console.ReadLine());


        List<IEatable> food = new List<IEatable>();
        food.Add(FoodFactory.CreateBone());
        food.Add(FoodFactory.CreatePizza());
        food.Add(FoodFactory.CreateFruit());
        food.Add(FoodFactory.CreateMeat());
        food.Add(FoodFactory.CreateIceCream());
        food.Add(FoodFactory.CreateVegetable());

        List<Animal> animals = new List<Animal>();

        for (int i = 0; i < lionNum; i++)
        {
            animals.Add(AnimalFactory.CreateLion());
        }
        for (int i = 0; i < bearNum; i++)
        {
            animals.Add(AnimalFactory.CreateBear());
        }
        for (int i = 0; i < zebraNum; i++)
        {
            Animal z = AnimalFactory.CreateZebra();
            animals.Add(z);
            food.Add(z);
        }

        return (animals, food);
    }
}