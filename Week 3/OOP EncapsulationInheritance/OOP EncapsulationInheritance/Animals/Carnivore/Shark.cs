namespace OOP_EncapsulationInheritance.Animals.Carnivore;

using Contracts;
using Diets;
using OOP_EncapsulationInheritance.Biomes;
using OOP_EncapsulationInheritance.Enums;

public class Shark : Carnivore
{
    private static readonly IDiet _diet = new Diet(
        new HashSet<IEatableTypes>() { IEatableTypes.Meat, IEatableTypes.Bone, IEatableTypes.Tilapia },
        new HashSet<IEatableTypes>() { IEatableTypes.Meat, IEatableTypes.Bone, IEatableTypes.Tilapia });
    public Shark(IBiome startBiome, Map map, Random rnd) : base(_diet,startBiome,map,rnd)
    {
        this.Type = IEatableTypes.Shark;
    }



    public override Animal Instantiate(IBiome startBiome, Map map, Random rnd)
    {
        return new Shark( startBiome,map,rnd);
    }

 
}

