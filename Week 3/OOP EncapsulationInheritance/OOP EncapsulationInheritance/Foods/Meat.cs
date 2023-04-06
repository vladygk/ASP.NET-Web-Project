namespace OOP_EncapsulationInheritance.Foods;

using Contracts;
using Enums;

public class Meat : Food
{
    private const int DefaultNutritionalValue = 5;

    public Meat()
    {
        this.Type = IEatableTypes.Meat;
    }

    public override int NutritionalValue { get; set; } = DefaultNutritionalValue;

    public override void RestoreNutritionalValue()
    {
    }

    public override IEatable Instantiate()
    {
        return new Meat();
    }
}