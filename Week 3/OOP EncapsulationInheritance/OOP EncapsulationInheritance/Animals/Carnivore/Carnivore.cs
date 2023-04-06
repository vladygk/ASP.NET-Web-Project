namespace OOP_EncapsulationInheritance.Animals.Carnivore;

using Biomes;
using Diets;

public abstract class Carnivore : Animal
{
    private const int DefaultNutritionalValue = 3;
    private const int DefaultMaxEnergy = 9;
    private const string DefaultSound = "Grrr-Grrr";
   

    protected Carnivore(IDiet diet, IBiome startBiome, Map map, Random rnd)
        :base(
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

