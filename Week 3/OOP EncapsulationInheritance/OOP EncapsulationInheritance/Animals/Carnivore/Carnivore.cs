using OOP_EncapsulationInheritance.Enum;

namespace OOP_EncapsulationInheritance.Animals.Carnivore;

public abstract class Carnivore : Animal
{
   
    private const Diets diet = Diets.Carnivore;

    protected Carnivore()
    {
        
        Diet = diet;
    }


}

