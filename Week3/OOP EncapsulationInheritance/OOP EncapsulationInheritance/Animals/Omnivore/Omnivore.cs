namespace OOP_EncapsulationInheritance.Animals.Omnivore;

using Biomes;
using Diets;

public abstract class Omnivore : Animal
{
    private const int DefaultNutritionalValue = 4;
    private const int DefaultMaxEnergy = 12;
    private const string DefaultSound = "Oink-Oink";

    protected Omnivore(IDiet diet,IBiome startBiome, Map map, Random rnd)
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
