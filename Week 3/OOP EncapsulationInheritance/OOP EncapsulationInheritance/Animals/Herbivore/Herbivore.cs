namespace OOP_EncapsulationInheritance.Animals.Herbivore;

using Diets;
using Biomes;

public abstract class Herbivore : Animal
{

    private const int DefaultNutritionalValue = 5;
    private const int DefaultMaxEnergy = 15;
    private const string DefaultSound = "Mlem-Mlem";
    protected Herbivore(IDiet diet,IBiome startBiome,Map map, Random rnd)
        : base(
            DefaultMaxEnergy, 
            DefaultNutritionalValue, 
            DefaultSound, 
            diet,
            startBiome, 
            map,
            rnd)
    {

    }



}

