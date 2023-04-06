namespace OOP_EncapsulationInheritance.Food;

using Contracts;
using OOP_EncapsulationInheritance.Enums;

public class Vegetable : Food
{
  
    private const int DefaultNutritionalValue = 3;

    public Vegetable()
    {
        this.Type = IEatableTypes.Vegetable;
    }
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
        return new Vegetable();
    }
}
