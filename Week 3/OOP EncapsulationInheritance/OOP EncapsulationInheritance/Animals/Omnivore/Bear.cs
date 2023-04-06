
using OOP_EncapsulationInheritance.Biomes;
using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance.Animals.Omnivore;

using Diets;
using OOP_EncapsulationInheritance.Enums;

public class Bear : Omnivore
{
    private static IDiet _diet = new Diet(
        new HashSet<IEatableTypes>() { IEatableTypes.IceCream, IEatableTypes.Pizza },
        new HashSet<IEatableTypes>() { IEatableTypes.IceCream });
    public Bear(IBiome startBiome,Map map, Random rnd) : base(_diet, startBiome, map, rnd)
    {
        this.Type = IEatableTypes.Bear;
    }

  

    public override Animal Instantiate(IBiome startBiome, Map map, Random rnd)
    {
        return new Bear(startBiome, map, rnd);
    }

    
}

