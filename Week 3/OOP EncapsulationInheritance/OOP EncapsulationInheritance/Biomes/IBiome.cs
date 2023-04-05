using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance.Biomes;

public interface IBiome
{
     (List<Animal>, List<IEatable>) GenerateBiom(int numberOfAnimals);

     IBiome Instantiate();
}