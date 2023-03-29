using System.Text;
using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Contracts;


namespace OOP_EncapsulationInheritance;

public class Simulation
{
    private int dayCounter = 0;


    private readonly List<Animal> _animals;
    private readonly List<IEatable> _food;
    private readonly bool _detailedStats;
    private readonly Random _random;

    public Simulation(List<Animal> animals, List<IEatable> food, Random random, bool detailedStats)
    {
        this._animals = animals;
        this._food = food;
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
            Console.WriteLine($"Animals alive: {_animals.Count(a=>!a.IsDead)}");
            Console.WriteLine($"Animals dead: {_animals.Count(a => a.IsDead)}");
        }

        Console.WriteLine();
        foreach (var animal in _animals)
        {
            Console.WriteLine(animal);
        }

        Console.WriteLine();
       
    }
    

}

