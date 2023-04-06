namespace OOP_EncapsulationInheritance.Foods;

using Contracts;
using Enums;

public class Fruit : Food
{
    private const int DefaultNutritionalValue = 2;

    public Fruit()
    {
        this.Type = IEatableTypes.Fruit;
    }

    public override int NutritionalValue { get; set; } = DefaultNutritionalValue;

    public override void RestoreNutritionalValue()
    {
        if (this.NutritionalValue < DefaultNutritionalValue)
        {
            this.NutritionalValue++;
        }
    }

    public override IEatable Instantiate()
    {
        return new Fruit();
    }
}