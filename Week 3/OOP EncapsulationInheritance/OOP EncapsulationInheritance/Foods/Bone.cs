namespace OOP_EncapsulationInheritance.Food;

public class Bone : Food
{
    private const int DefaultNutritionalValue = 1;
    public override int NutritionalValue { get; set; } = DefaultNutritionalValue;

    public override void RestoreNutritionalValue()
    {
        if (NutritionalValue < DefaultNutritionalValue)
        {
            NutritionalValue++;
        }
    }
}

