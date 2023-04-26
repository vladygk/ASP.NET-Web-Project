namespace OOP_EncapsulationInheritance.Foods;

using Contracts;
using Enums;

public class Vegetable : Food
{
    private const int DefaultNutritionalValue = 3;

    public Vegetable()
    {
        this.Type = IEatableTypes.Vegetable;
        this.NutritionalValue = DefaultNutritionalValue;
    }

    public  int NutritionalValue { get; set; } 

    public override void RestoreNutritionalValue()
    {
        if (this.NutritionalValue < DefaultNutritionalValue)
        {
            this.NutritionalValue++;
        }
    }

    public override IEatable Instantiate()
    {
        return new Vegetable();
    }
}
