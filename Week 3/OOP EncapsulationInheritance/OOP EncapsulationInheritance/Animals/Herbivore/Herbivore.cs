namespace OOP_EncapsulationInheritance.Animals.Herbivore;

using Behaviour;
using IO;
using Diets;

public abstract class Herbivore : Animal
{

    private const int DefaultNutritionalValue = 5;
    private const int DefaultMaxEnergy = 15;
    private const string DefaultSound = "Mlem-Mlem";
    protected Herbivore(IDiet diet)
        : base(DefaultMaxEnergy, DefaultNutritionalValue, DefaultSound, diet)
    {

    }



}

