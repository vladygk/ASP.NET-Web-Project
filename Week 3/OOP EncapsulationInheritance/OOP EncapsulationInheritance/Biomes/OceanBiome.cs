namespace OOP_EncapsulationInheritance.Biomes;

using Animals.Carnivore;
using Animals.Herbivore;
using Animals.Omnivore;
using Enums;
using Food;
using Animals;
using Contracts;
using Factories;

public class OceanBiome : Biome
{


    private AnimalFactory animalFactory;


    public OceanBiome(int numberOfAnimals, Map map, Random rnd) : base(numberOfAnimals, map, rnd)
    {
        Type = BiomeTypes.OceanBiome;
        AnimalTypes =
            new Dictionary<IEatableTypes, Func<IBiome, Map, Random, Animal>>()
            {
                {IEatableTypes.Whale, new Whale(this,map,rnd ).Instantiate },
                {IEatableTypes.Shark, new Shark(this,map,rnd).Instantiate },
                {IEatableTypes.Tilapia, new Tilapia(this,map,rnd).Instantiate },
            };

        // Initialize food in Biome
        Foods = new List<IEatable>()
        {
            {new Bone()},
            { new Meat() },
            {new Seaweed()}
        };
        this.Animals = GenerateAnimals(numberOfAnimals);
        this.animalFactory = new AnimalFactory(AnimalTypes, map, rnd);

    }


    public override IBiome Instantiate(int numberOfAnimals)
    {
        return new OceanBiome(numberOfAnimals, this.Map, this.Random);
    }
}