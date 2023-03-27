using OOP_EncapsulationInheritance.Enum;

namespace OOP_EncapsulationInheritance.Animals.Omnivore
{
    public abstract class Omnivore : Animal
    {
  
        private const Diets diet = Diets.Omnivore;

        protected Omnivore()
        {
            Diet = diet;
        }


    }
}
