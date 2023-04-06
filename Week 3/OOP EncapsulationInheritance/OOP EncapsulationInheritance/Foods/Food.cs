namespace OOP_EncapsulationInheritance.Food;
using Contracts;
using Enums;

public abstract class Food : IEatable
{
  
    
    public IEatableTypes Type { get; set; }
    public virtual int NutritionalValue { get; set; }
    public bool IsEaten { get; set; }

    public abstract void RestoreNutritionalValue();
    
    public int GetEaten(int amountEaten)
    {
       
      
        if (amountEaten > this.NutritionalValue)
        {
            return this.NutritionalValue;
        }

        NutritionalValue = 0;
        return amountEaten;
    }

    public abstract IEatable Instantiate();

}

