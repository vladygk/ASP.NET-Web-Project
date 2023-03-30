using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Animals.Carnivore;
using OOP_EncapsulationInheritance.Animals.Herbivore;
using OOP_EncapsulationInheritance.Animals.Omnivore;


namespace OOP_EncapsulationInheritance.Factories
{
    internal class AnimalFactory
    {


        public static Animal CreateLion()
        {
            return new Lion();
        }

        public static Animal CreateBear()
        {
            return new Bear();
        }

        public static Animal CreateZebra()
        {
            return new Zebra();
        }

    }
}
