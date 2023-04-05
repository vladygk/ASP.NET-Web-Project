namespace OOP_EncapsulationInheritance.Animals.Herbivore;
using Diets;

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

