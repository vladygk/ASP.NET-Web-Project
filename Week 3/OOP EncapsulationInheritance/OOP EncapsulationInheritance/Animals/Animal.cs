using OOP_EncapsulationInheritance.Contracts;
using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance.Animals;

public abstract class Animal : IEatable
{
    protected virtual IEnumerable<string> Diet { get; }
    protected bool IsHungry => CurrentEnergy < MaximumEnergy / 2;
    protected bool IsMature => Age > 18;

    protected abstract void MakeSoundWhenHungry();
    protected abstract void MakeSoundWhenDying();
    protected abstract void MakeSoundWhenEating(string foodName);

    public virtual int MaximumEnergy { get; set; }
    public  int NutritionalValue { get; set; }
    public int CurrentEnergy { get; set; }
    public string Name => this.GetType().Name;

    public bool IsEaten { get; set; }
    public bool IsDead => IsEaten || CurrentEnergy <= 0;
    public int Age { get; set; }
    public void RestoreNutritionalValue(){}



    public void GetEaten()
    {
        CurrentEnergy = 0;
        NutritionalValue = 0;
        IsEaten = true;
    }

    public void Eat(IEatable food)
    {
        if (Diet.Contains(food.Name))
        {
            CurrentEnergy += food.NutritionalValue;
            if (CurrentEnergy > MaximumEnergy)
            {
                CurrentEnergy = MaximumEnergy;
            }
            else
            {
                food.GetEaten();
                MakeSoundWhenEating(food.Name);
            }

        }
        else
        {
            CurrentEnergy--;
        }

        if (IsHungry)
        {
            MakeSoundWhenHungry();
        }

        if (IsDead)
        {
            MakeSoundWhenDying();
        }
    }

    public override string ToString()
    {
        int energy = CurrentEnergy < 0 ? 0 : CurrentEnergy;
        return $"{this.Name}-> Energy:{energy} Dead:{IsDead}";
    }
}
