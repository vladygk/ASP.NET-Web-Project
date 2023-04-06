
namespace OOP_EncapsulationInheritance.Food;
using Contracts;
using OOP_EncapsulationInheritance.Enums;

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
        if (NutritionalValue < DefaultNutritionalValue)
        {
            NutritionalValue++;
        }
    }

    public override IEatable Instantiate()
    {
        return new Fruit();
    }
    }
    

