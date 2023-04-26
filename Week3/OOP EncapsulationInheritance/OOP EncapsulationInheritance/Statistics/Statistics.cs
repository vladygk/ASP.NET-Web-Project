namespace OOP_EncapsulationInheritance.Statistics;

using System.Text;
using Animals;

public class Statistics : IStatistics
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
            int energy = animal.CurrentEnergy < 0 ? 0 : animal.CurrentEnergy;

            dailyStatistics.AppendLine($"{animal.Type}-> Energy:{energy} Dead:{animal.IsDead}");
        }

        dailyStatistics.AppendLine();

        return dailyStatistics.ToString().TrimEnd();
    }
}