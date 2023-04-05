
namespace OOP_EncapsulationInheritance.Statistics;

using System.Text;
using Animals;

public class SpanishStatistics : IStatistics
{
   
    public string GenerateStatistics(IEnumerable<Animal> animals)
    {
        StringBuilder statistics = new StringBuilder();
        statistics.AppendLine();
        statistics.AppendLine($"Edad maxima: {animals.Max(x => x.Age)}");
        statistics.AppendLine($"Edad minima: {animals.Min(x => x.Age)}");
        statistics.AppendLine($"Edad promedio: {animals.Average(x => x.Age):f0}");

        return statistics.ToString().TrimEnd();
    }

    public string GenerateDailyStatistics(int dayCounter, IEnumerable<Animal> animals, bool detailedStats)
    {
        StringBuilder dailyStatistics = new StringBuilder();
        dailyStatistics.AppendLine();
        dailyStatistics.AppendLine($"Dia: {dayCounter}");
        dailyStatistics.AppendLine();
        if (detailedStats)
        {
            dailyStatistics.AppendLine($"Animales vivos: {animals.Count(a => !a.IsDead)}");
            dailyStatistics.AppendLine($"Animales muertos: {animals.Count(a => a.IsDead)}");
        }

        dailyStatistics.AppendLine();
        foreach (var animal in animals)
        {
            int energy = animal.CurrentEnergy < 0 ? 0 : animal.CurrentEnergy;
            string isDead = animal.IsDead ? "Si" : "No";
            dailyStatistics.AppendLine($"{animal.Name}-> Energia:{energy} Esta Muerto:{isDead}");

   
        }

        dailyStatistics.AppendLine();

        return dailyStatistics.ToString().TrimEnd();
    }
}