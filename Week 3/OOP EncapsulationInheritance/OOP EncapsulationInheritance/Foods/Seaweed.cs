namespace OOP_EncapsulationInheritance.Foods;

using Contracts;
using Enums;

public class Seaweed : Food
{
    private const int DefaultNutritionalValue = 2;

    public Seaweed()
    {
        this.Type = IEatableTypes.Seaweed;
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
        return new Seaweed();
    }
}