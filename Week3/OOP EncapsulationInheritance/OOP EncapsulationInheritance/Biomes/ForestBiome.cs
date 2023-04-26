namespace OOP_EncapsulationInheritance.Biomes;

using Animals.Carnivore;
using Animals.Herbivore;
using Animals.Omnivore;
using Enums;
using Foods;
using Animals;
using Contracts;
using Factories;

public class ForestBiome : Biome
{
    private AnimalFactory animalFactory;

    public ForestBiome(int numberOfAnimals, Map map, Random rnd)
        : base(numberOfAnimals, map, rnd)
    {
        this.Type = BiomeTypes.ForestBiome;

        this.AnimalTypes =
            new Dictionary<IEatableTypes, Func<IBiome, Map, Random, Animal>>()
            {
                { IEatableTypes.Lion, new Lion(this, map, rnd).Instantiate },
                { IEatableTypes.Bear, new Bear(this, map, rnd).Instantiate },
                { IEatableTypes.Zebra, new Zebra(this, map, rnd).Instantiate },
            };

        // Initialize food in Biome
        this.Foods = new List<IEatable>()
        {
            { new Bone() },
            { new Meat() },
            { new IceCream() },
            { new Pizza() },
            { new Vegetable() },
            { new Fruit() },
        };
        this.Animals = this.GenerateAnimals(numberOfAnimals);
        this.animalFactory = new AnimalFactory(this.AnimalTypes, map, rnd);
    }

    public override IBiome Instantiate(int numberOfAnimals)
    {
        return new ForestBiome(numberOfAnimals,this.Map,this.Random);
    }
}