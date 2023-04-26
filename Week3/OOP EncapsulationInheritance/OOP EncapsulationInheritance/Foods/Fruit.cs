namespace OOP_EncapsulationInheritance.Foods;

using Contracts;
using Enums;

public class Fruit : Food
{
    private const int DefaultNutritionalValue = 2;

    public Fruit()
    {
        this.Type = IEatableTypes.Fruit;
        this.NutritionalValue = DefaultNutritionalValue;
    }

    public int NutritionalValue { get; set; }

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