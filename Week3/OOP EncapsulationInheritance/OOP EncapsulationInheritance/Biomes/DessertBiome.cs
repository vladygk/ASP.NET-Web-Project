namespace OOP_EncapsulationInheritance.Biomes;

using Animals.Carnivore;
using Animals.Herbivore;
using Animals;
using Contracts;
using Enums;
using Factories;
using Foods;

public class DessertBiome : Biome
{
    private AnimalFactory animalFactory;

    public DessertBiome(int numberOfAnimals, Map map, Random rnd)
        : base(numberOfAnimals, map, rnd)
    {
        this.Type = BiomeTypes.DessertBiome;

        this.AnimalTypes =
            new Dictionary<IEatableTypes, Func<IBiome, Map, Random, Animal>>()
            {
                { IEatableTypes.Lion, new Lion(this, map, rnd).Instantiate },
                { IEatableTypes.Zebra, new Zebra(this, map, rnd).Instantiate },

            };

        // Initialize food in Biome
        this.Foods = new List<IEatable>()
        {
            { new Bone() },
            { new Meat() },
            { new Cactus() },
        };
        this.Animals = this.GenerateAnimals(numberOfAnimals);
        this.animalFactory = new AnimalFactory(this.AnimalTypes, map, rnd);
    }

    public override IBiome Instantiate(int numberOfAnimals)
    {
        return new DessertBiome(numberOfAnimals, this.Map, this.Random);
    }
}