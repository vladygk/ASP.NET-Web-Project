using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance.Food;
public class Vegetable : Food
{
    private const int DefaultNutritionalValue = 3;
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
