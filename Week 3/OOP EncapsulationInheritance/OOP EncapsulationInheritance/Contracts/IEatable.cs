namespace OOP_EncapsulationInheritance.Contracts;

public interface IEatable
{
    public string Name{ get; }
    public int NutritionalValue{ get; set; }
    public bool IsEaten{ get; }

    public void RestoreNutritionalValue();
    public int GetEaten(int amountEaten);

}