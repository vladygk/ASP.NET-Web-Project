
namespace OOP_EncapsulationInheritance.Statistics;

using System.Text;
using Animals;

public class ConsoleStatistics : IStatistics
{
   
    public string GenerateStatistics(IEnumerable<Animal> animals)
    {
        StringBuilder statistics = new StringBuilder();
        statistics.AppendLine();
        statistics.AppendLine($"Maximum age: {animals.Max(x => x.Age)}");
        statistics.AppendLine($"Minimum age: {animals.Min(x => x.Age)}");
        statistics.AppendLine($"Average age: {animals.Average(x => x.Age):f0}");

        return statistics.ToString().TrimEnd();
    }

    public string GenerateDailyStatistics(int dayCounter, IEnumerable<Animal> animals, bool detailedStats)
    {
        StringBuilder dailyStatistics = new StringBuilder();
        dailyStatistics.AppendLine();
        dailyStatistics.AppendLine($"Day: {dayCounter}");
        dailyStatistics.AppendLine();
        if (detailedStats)
        {
            dailyStatistics.AppendLine($"Animals alive: {animals.Count(a => !a.IsDead)}");
            dailyStatistics.AppendLine($"Animals dead: {animals.Count(a => a.IsDead)}");
        }

        dailyStatistics.AppendLine();
        foreach (var animal in animals)
        {
            dailyStatistics.AppendLine(animal.ToString());
        }

        dailyStatistics.AppendLine();

        return dailyStatistics.ToString().TrimEnd();
    }
}