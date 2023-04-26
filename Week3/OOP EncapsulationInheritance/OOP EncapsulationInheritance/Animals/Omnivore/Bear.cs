namespace OOP_EncapsulationInheritance.Animals.Omnivore;

using Biomes;
using Diets;
using Enums;

public class Bear : Omnivore
{
    private static readonly IDiet diet = new Diet(
        new HashSet<IEatableTypes>() { IEatableTypes.IceCream, IEatableTypes.Pizza },
        new HashSet<IEatableTypes>() { IEatableTypes.IceCream });

    public Bear(IBiome startBiome,Map map, Random rnd)
        : base(diet, startBiome, map, rnd)
    {
        this.Type = IEatableTypes.Bear;
    }

    public override Animal Instantiate(IBiome startBiome, Map map, Random rnd)
    {
        return new Bear(startBiome, map, rnd);
    }
}