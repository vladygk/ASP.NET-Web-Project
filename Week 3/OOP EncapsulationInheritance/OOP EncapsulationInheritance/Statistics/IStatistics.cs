namespace OOP_EncapsulationInheritance.Statistics;

using Animals;

public interface IStatistics
{
    string GenerateStatistics(IEnumerable<Animal> animals); 
    string GenerateDailyStatistics(int dayCounter, IEnumerable<Animal> animals, bool detailedStats);
}