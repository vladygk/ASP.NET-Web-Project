using OOP_EncapsulationInheritance.Animals;

namespace OOP_EncapsulationInheritance.Contracts;

public interface IStatistics
{
    void GenerateStatistics(IEnumerable<Animal> animals);
    void GenerateDailyStatistics(int dayCounter, IEnumerable<Animal> animals, bool detailedStats);
}