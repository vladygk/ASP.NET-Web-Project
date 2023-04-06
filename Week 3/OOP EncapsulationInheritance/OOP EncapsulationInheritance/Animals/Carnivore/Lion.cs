
namespace OOP_EncapsulationInheritance.Animals.Carnivore;

using Enums;
using Diets;
using Biomes;

public class Lion : Carnivore
{
    private static readonly IDiet _diet = new Diet(
        new HashSet<IEatableTypes>() { IEatableTypes.Meat, IEatableTypes.Bone, IEatableTypes.Zebra },
        new HashSet<IEatableTypes>() { IEatableTypes.Meat, IEatableTypes.Zebra });

    public Lion(IBiome startBiome, Map map, Random rnd)
        : base(_diet, startBiome, map, rnd)
    {
        this.Type = IEatableTypes.Lion;
    }

    public override Animal Instantiate(IBiome startBiome, Map map, Random rnd)
    {
        return new Lion(startBiome,map, rnd);
    }
}