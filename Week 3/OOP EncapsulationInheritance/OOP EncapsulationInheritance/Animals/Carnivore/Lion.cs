namespace OOP_EncapsulationInheritance.Animals.Carnivore;

using Diets;

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

