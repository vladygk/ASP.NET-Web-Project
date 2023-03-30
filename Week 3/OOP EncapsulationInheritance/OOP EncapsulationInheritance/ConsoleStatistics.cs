using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance;

public class ConsoleStatistics : IStatistics
{
    public  void GenerateStatistics(IEnumerable<Animal> animals)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.WriteLine($"Maximum age: {animals.Max(x => x.Age)}");
        Console.WriteLine($"Minimum age: {animals.Min(x => x.Age)}");
        Console.WriteLine($"Average age: {animals.Average(x => x.Age):f0}");
    }

    public void GenerateDailyStatistics(int dayCounter, IEnumerable<Animal> animals,bool detailedStats)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Day: {dayCounter}");
        Console.WriteLine();
        if (detailedStats)
        {
            Console.WriteLine($"Animals alive: {animals.Count(a => !a.IsDead)}");
            Console.WriteLine($"Animals dead: {animals.Count(a => a.IsDead)}");
        }

        Console.WriteLine();
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }

        Console.WriteLine();
    }
}