namespace OOP_EncapsulationInheritance.Biomes;

using Enums;
using Contracts;
using Animals;



public interface IBiome
{
    List<Animal> Animals { get; set; }

    IBiome Instantiate(int numberOfAnimals);

    public List<IEatable> Foods { get; set; }

    public BiomeTypes Type { get; set; }

    public (int x, int y) Coordinates { get; set; }

    public Dictionary<IEatableTypes, Func<IBiome, Map, Random, Animal>> AnimalTypes { get; set; }
}