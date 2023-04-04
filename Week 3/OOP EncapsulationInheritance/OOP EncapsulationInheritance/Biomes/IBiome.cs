using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance.Biomes;

public interface IBiome
{
    public (IEnumerable<Animal>, IEnumerable<IEatable>) GenerateBiom(int numberOfAnimals);
}