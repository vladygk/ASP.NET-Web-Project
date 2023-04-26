namespace OOP_EncapsulationInheritance.Foods;

using Contracts;
using Enums;

public class Cactus : Food
{
    private const int DefaultNutritionalValue = 3;

    public Cactus()
    {
        this.Type = IEatableTypes.Fruit;
        this.NutritionalValue = DefaultNutritionalValue;
    }

    public override void RestoreNutritionalValue()
    {
        if (this.NutritionalValue < DefaultNutritionalValue)
        {
            this.NutritionalValue++;
        }
    }

    public override IEatable Instantiate()
    {
        return new Cactus();
    }
}