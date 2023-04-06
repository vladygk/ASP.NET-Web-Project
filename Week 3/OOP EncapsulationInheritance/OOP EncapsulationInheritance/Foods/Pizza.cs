namespace OOP_EncapsulationInheritance.Foods;

using Contracts;
using Enums;

public class Pizza : Food
{
    private const int DefaultNutritionalValue = 4;

    public Pizza()
    {
        this.Type = IEatableTypes.Pizza;
    }

    public override int NutritionalValue { get; set; } = DefaultNutritionalValue;

    public override void RestoreNutritionalValue()
    {
    }

    public override IEatable Instantiate()
    {
        return new Pizza();
    }
}