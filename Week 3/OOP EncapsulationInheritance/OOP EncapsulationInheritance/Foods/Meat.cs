﻿namespace OOP_EncapsulationInheritance.Food;

public class Meat : Food
{
    private const int DefaultNutritionalValue = 5;
    public override int NutritionalValue { get; set; } = DefaultNutritionalValue;

    public override void RestoreNutritionalValue()
    {
        if (NutritionalValue < DefaultNutritionalValue)
        {
            NutritionalValue++;
        }
    }
}
