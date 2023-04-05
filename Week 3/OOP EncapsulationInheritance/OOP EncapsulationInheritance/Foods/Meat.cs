using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance.Food;

public class Meat : Food
{
    private const int DefaultNutritionalValue = 5;
    public override int NutritionalValue { get; set; } = DefaultNutritionalValue;

    public override void RestoreNutritionalValue()
    {
     
    }

    public override IEatable Instantiate()
    {
        return new Meat();
    }
}

