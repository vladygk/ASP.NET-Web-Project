namespace OOP_EncapsulationInheritance.Food;
public abstract class FoodType
{
    protected abstract string Name { get; }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }

    public override bool Equals(object? obj)
    {
        return Name.Equals(((FoodType)obj).Name);
    }
}

