namespace OOP_EncapsulationInheritance.Biomes;

using Contracts;
using Enums;
using Animals;

public abstract class Biome : IBiome
{
    protected Map Map { get; set; }

    protected Random Random { get; set; }

    protected Biome( int numberOfAnimals, Map map, Random rnd)
    {
        this.Map = map;
        this.Random = rnd;
    }

    public BiomeTypes Type { get; set; }

    public (int x, int y) Coordinates { get; set; }

    public List<IEatable> Foods { get; set; }

    public Dictionary<IEatableTypes, Func<IBiome,Map,Random, Animal>> AnimalTypes { get; set; }

    public List<Animal> Animals { get; set; }

    protected List<Animal> GenerateAnimals(int numberOfAnimals)
    {
        List<Animal> animals = new List<Animal>();

        foreach (var animalType in AnimalTypes)
        {
            for (int i = 0; i < numberOfAnimals; i++)
            {
                Animal currentAnimal = animalType.Value.Invoke(this, this.Map, this.Random);
                animals.Add(currentAnimal);
                this.Foods.Add(currentAnimal);
            }
        }

        return animals;
    }

    public abstract IBiome Instantiate(int numberOfAnimals);
}