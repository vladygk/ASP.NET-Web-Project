namespace OOP_EncapsulationInheritance.Behaviour;

public interface IBehaviour
{
    string MakeSoundWhenHungry(string name, string sound);
    string MakeSoundWhenDying(string name, string sound);
    string MakeSoundWhenEating(string name, string sound);
}