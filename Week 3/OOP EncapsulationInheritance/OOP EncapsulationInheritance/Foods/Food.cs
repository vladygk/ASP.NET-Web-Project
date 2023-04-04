using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance.Food;

public abstract class Food : IEatable
{
    
    public string Name => this.GetType().Name;
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

