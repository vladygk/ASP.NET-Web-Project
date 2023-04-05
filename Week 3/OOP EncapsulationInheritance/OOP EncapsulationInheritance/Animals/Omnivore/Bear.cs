
namespace OOP_EncapsulationInheritance.Animals.Omnivore;

using Diets;

public class Bear : Omnivore
{
    public Bear(IDiet diet) : base(diet)
    {
    }

    public override Animal Instantiate(IDiet diet)
    {
        return new Bear(diet);
    }
}

