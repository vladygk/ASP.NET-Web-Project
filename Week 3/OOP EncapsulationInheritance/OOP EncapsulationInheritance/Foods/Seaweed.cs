namespace OOP_EncapsulationInheritance.Food;
using Contracts;

public class Seaweed : Food
{
    private const int DefaultNutritionalValue = 2;
    public override int NutritionalValue { get; set; } = DefaultNutritionalValue;
    public override void RestoreNutritionalValue()
    {
        if (NutritionalValue < DefaultNutritionalValue)
        {
            NutritionalValue++;
        }
    }

    public override IEatable Instantiate()
    {
        return new Seaweed();
    }
}

