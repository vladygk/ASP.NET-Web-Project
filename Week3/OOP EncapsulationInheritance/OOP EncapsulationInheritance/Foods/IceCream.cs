namespace OOP_EncapsulationInheritance.Foods;

using Contracts;
using Enums;
public class IceCream : Food
{
    private const int DefaultNutritionalValue = 2;

    public IceCream()
    {
        this.Type = IEatableTypes.IceCream;
        this.NutritionalValue = DefaultNutritionalValue;
    }

    public  int NutritionalValue { get; set; } 

    public override void RestoreNutritionalValue()
    {
    }

    public override IEatable Instantiate()
    {
        return new IceCream();
    }
}
