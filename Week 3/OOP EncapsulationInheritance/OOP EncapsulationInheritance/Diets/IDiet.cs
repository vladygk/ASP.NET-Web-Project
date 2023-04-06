
namespace OOP_EncapsulationInheritance.Diets;
 using Enums;

public interface IDiet
{
    IEnumerable<IEatableTypes> DietMatureAnimal { get; }

    IEnumerable<IEatableTypes> DietYoungAnimal { get; }
}

