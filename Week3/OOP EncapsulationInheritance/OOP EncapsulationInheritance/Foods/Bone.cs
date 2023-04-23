namespace OOP_EncapsulationInheritance.Foods;

using Enums;
using Contracts;

public class Bone : Food
{
    private const int DefaultNutritionalValue = 1;

    public Bone()
    {
        this.Type = IEatableTypes.Bone;
        this.NutritionalValue = DefaultNutritionalValue;
    }

    public int NutritionalValue { get; set; }

    public override void RestoreNutritionalValue()
    {
    }

    public override IEatable Instantiate()
    {
        return new Bone();
    }
}