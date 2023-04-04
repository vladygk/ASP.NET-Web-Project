using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance.Diets;

public class Diet : IDiet
{
    public Diet(IEnumerable<string> matureDiet, IEnumerable<string> youngDiet)
    {
        this.DietMatureAnimal = matureDiet;
        this.DietYoungAnimal = youngDiet;
    }
    public IEnumerable<string> DietMatureAnimal { get; }
    public IEnumerable<string> DietYoungAnimal { get; }
}

