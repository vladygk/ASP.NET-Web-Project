﻿namespace OOP_EncapsulationInheritance.Food;

    public class Fruit : Food
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
}
    
