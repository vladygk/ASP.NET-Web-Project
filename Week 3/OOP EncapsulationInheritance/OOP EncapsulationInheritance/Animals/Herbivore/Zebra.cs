
using OOP_EncapsulationInheritance.Biomes;

namespace OOP_EncapsulationInheritance.Animals.Herbivore;
using Contracts;
using Diets;
using OOP_EncapsulationInheritance.Enums;

public class Zebra : Herbivore
{
    private static readonly IDiet _diet = new Diet(
        new HashSet<IEatableTypes>() { IEatableTypes.Vegetable, IEatableTypes.Fruit },
        new HashSet<IEatableTypes>() { IEatableTypes.Fruit });
    public Zebra(IBiome startBiome,Map map, Random rnd) : base(_diet, startBiome, map, rnd)
    {
        this.Type = IEatableTypes.Zebra;
    }

  

    public override Animal Instantiate(IBiome startBiome, Map map, Random rnd)
    {
        return new Zebra(startBiome, map, rnd);
    }
}

