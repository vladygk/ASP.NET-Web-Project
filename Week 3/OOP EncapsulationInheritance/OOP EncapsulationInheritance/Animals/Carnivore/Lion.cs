namespace OOP_EncapsulationInheritance.Animals.Carnivore;

using Behaviour;
using Diets;
using IO;
using OOP_EncapsulationInheritance.Animals.Herbivore;

public class Lion : Carnivore
{
    public Lion(IDiet diet) : base(diet)
    {
    }


    public override Animal Instantiate(IDiet diet)
    {
        return new Lion(diet);
    }
}

