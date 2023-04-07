namespace OOP_EncapsulationInheritance.Foods;

using Contracts;
using Enums;

public class Pizza : Food
{
    private const int DefaultNutritionalValue = 4;

    public Pizza()
    {
        this.Type = IEatableTypes.Pizza;
        this.NutritionalValue = DefaultNutritionalValue;
    }

    public int NutritionalValue { get; set; } 

    public override void RestoreNutritionalValue()
    {
    }

    public override IEatable Instantiate()
    {
        return new Pizza();
    }
}