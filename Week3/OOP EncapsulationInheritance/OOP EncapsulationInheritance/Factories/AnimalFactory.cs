namespace OOP_EncapsulationInheritance.Factories;

using Biomes;
using Enums;
using Animals;


public class AnimalFactory
{
    private readonly Dictionary<IEatableTypes, Func<IBiome,Map,Random, Animal>> animalTypes;
    private readonly Map _map;
    private readonly Random _rnd;


    public AnimalFactory(Dictionary<IEatableTypes, Func<IBiome, Map, Random, Animal>> animalTypes, Map map, Random rnd)
    {
        this.animalTypes = animalTypes;
        _map = map;
        _rnd = rnd;
    }

    public Animal Create(
        IEatableTypes animalType, 
        IBiome startBiome
        )
    {
        return animalTypes[animalType].Invoke(startBiome, _map, _rnd);
    }



}

