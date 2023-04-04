using OOP_EncapsulationInheritance.Animals.Omnivore;
using OOP_EncapsulationInheritance.Behaviour;
using OOP_EncapsulationInheritance.Diets;
using OOP_EncapsulationInheritance.IO;

namespace OOP_EncapsulationInheritance.Animals.Herbivore;

public class Zebra : Herbivore
{
    public Zebra(IDiet diet) : base(diet)
    {
    }

    public override Animal Instantiate(IDiet diet)
    {
        return new Zebra(diet);
    }
}

