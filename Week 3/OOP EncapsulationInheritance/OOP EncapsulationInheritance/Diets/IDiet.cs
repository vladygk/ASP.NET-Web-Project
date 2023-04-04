using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance.Diets;

public interface IDiet
{
    IEnumerable<string> DietMatureAnimal { get; }

    IEnumerable<string> DietYoungAnimal { get; }
}

