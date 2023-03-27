using OOP_EncapsulationInheritance.Enum;

namespace OOP_EncapsulationInheritance.Animals.Herbivore;

public abstract class Herbivore : Animal
{
   
    private const Diets diet = Diets.Herbivore;
    protected Herbivore()
    {
        
        Diet = diet;
    }

}

