using OOP_EncapsulationInheritance.Behaviour;
using OOP_EncapsulationInheritance.Diets;
using OOP_EncapsulationInheritance.IO;

namespace OOP_EncapsulationInheritance.Animals.Carnivore;

public abstract class Carnivore : Animal
{
    private const int DefaultNutritionalValue = 3;
    private const int DefaultMaxEnergy = 9;
    private const string DefaultSound = "Grrr-Grrr";
   

    protected Carnivore(IDiet diet)
        :base(DefaultMaxEnergy,DefaultNutritionalValue, DefaultSound, diet)
    {
    }
    
}

