using OOP_EncapsulationInheritance.Contracts;

namespace OOP_EncapsulationInheritance.Food;

public abstract class Food : IEatable
{
    
    public string Name => this.GetType().Name;
    public virtual int NutritionalValue { get; set; }
    public bool IsEaten { get; set; }
    public abstract void RestoreNutritionalValue();
    
    public void GetEaten()
    {
        NutritionalValue = 0;
    }
}

