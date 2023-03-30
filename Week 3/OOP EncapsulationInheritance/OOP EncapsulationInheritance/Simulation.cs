using System.Text;
using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Contracts;
using OOP_EncapsulationInheritance.Factories;


namespace OOP_EncapsulationInheritance;

public class Simulation
{
    private int dayCounter = 0;


    private readonly List<Animal> _animals;
    private readonly List<IEatable> _food;
    private readonly bool _detailedStats;
    private readonly Random _random;

    public Simulation(Random random, bool detailedStats)
    {
        (IEnumerable<Animal> animals, IEnumerable<IEatable> food) = this.GenerateAnimalsAndFood();
        this._animals = animals.ToList();
        this._food = food.ToList();
        this._random = random;
        this._detailedStats = detailedStats;
    }


    public void Start()
    {
        while (_animals.Any(x => !x.IsDead))
        {
            dayCounter++;
            GetDailyStatistics();
            foreach (var animal in _animals)
            {
                if (animal.IsDead)
                {
                    continue;
                }

                IEatable currentFood = GetRandomFood();
                if (currentFood.IsEaten)
                {
                    continue;
                }
                animal.Eat(currentFood);

                if (!animal.IsDead)
                {
                    animal.Age++;

                }
            }


            RegenerateFood();
        }
        GetDailyStatistics();

        GetStatistics();
    }

    public IEatable GetRandomFood()
    {
        int randomIndex = _random.Next(_food.Count);
        return this._food[randomIndex];
    }

    public void RegenerateFood()
    {
        foreach (var food in _food)
        {
            food.RestoreNutritionalValue();
        }
    }

    private void GetStatistics()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.WriteLine($"Maximum age: {_animals.Max(x => x.Age)}");
        Console.WriteLine($"Minimum age: {_animals.Min(x => x.Age)}");
        Console.WriteLine($"Average age: {_animals.Average(x => x.Age):f0}");

    }

    private void GetDailyStatistics()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Day: {dayCounter}");
        Console.WriteLine();
        if (_detailedStats)
        {
            Console.WriteLine($"Animals alive: {_animals.Count(a => !a.IsDead)}");
            Console.WriteLine($"Animals dead: {_animals.Count(a => a.IsDead)}");
        }

        Console.WriteLine();
        foreach (var animal in _animals)
        {
            Console.WriteLine(animal);
        }

        Console.WriteLine();

    }

    private (IEnumerable<Animal> animals, IEnumerable<IEatable> food) GenerateAnimalsAndFood()
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

