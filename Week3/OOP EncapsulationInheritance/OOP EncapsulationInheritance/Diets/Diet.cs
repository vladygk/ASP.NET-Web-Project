namespace OOP_EncapsulationInheritance.Diets;

using Enums;

public class Diet : IDiet
{
    public Diet(IEnumerable<IEatableTypes> matureDiet, IEnumerable<IEatableTypes> youngDiet)
    {
        this.DietMatureAnimal = matureDiet;
        this.DietYoungAnimal = youngDiet;
    }

    public IEnumerable<IEatableTypes> DietMatureAnimal { get; }

    public IEnumerable<IEatableTypes> DietYoungAnimal { get; }
}