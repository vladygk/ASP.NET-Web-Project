using OOP_EncapsulationInheritance.Animals;

namespace OOP_EncapsulationInheritance.Statistics;

public interface IStatistics
{
    string GenerateStatistics(IEnumerable<Animal> animals);
    string GenerateDailyStatistics(int dayCounter, IEnumerable<Animal> animals, bool detailedStats);
}