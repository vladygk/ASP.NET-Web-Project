namespace OOP_EncapsulationInheritance.Contracts;
using Enums;

public interface IEatable
{
    public IEatableTypes Type{ get;  set; }
    public int NutritionalValue{ get; set; }
    public bool IsEaten{ get; }

 
    public void RestoreNutritionalValue();
    public int GetEaten(int amountEaten);

}