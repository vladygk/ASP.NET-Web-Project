namespace OOP_EncapsulationInheritance.Foods;

using Contracts;
using Enums;

public class Meat : Food
{
    private const int DefaultNutritionalValue = 5;

    public Meat()
    {
        this.Type = IEatableTypes.Meat;
        this.NutritionalValue = DefaultNutritionalValue;
    }

    public int NutritionalValue { get; set; } 

    public override void RestoreNutritionalValue()
    {
    }

    public override IEatable Instantiate()
    {
        return new Meat();
    }
}