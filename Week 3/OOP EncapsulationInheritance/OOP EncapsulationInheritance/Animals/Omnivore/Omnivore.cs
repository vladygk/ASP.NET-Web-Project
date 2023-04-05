namespace OOP_EncapsulationInheritance.Animals.Omnivore;

using Behaviour;
using Diets;
using IO;
public abstract class Omnivore : Animal
{
    private const int DefaultNutritionalValue = 4;
    private const int DefaultMaxEnergy = 12;
    private const string DefaultSound = "Oink-Oink";

    protected Omnivore(IDiet diet)
        : base(DefaultMaxEnergy, DefaultNutritionalValue, DefaultSound, diet)
    {
    }
}
