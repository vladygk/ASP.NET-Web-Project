namespace OOP_EncapsulationInheritance.Behaviour;

public class BehaviourEnglish : IBehaviour
{
    public string MakeSoundWhenHungry(string name, string sound)
    {
        return $"{name} is hungry.. {sound}";
    }

    public string MakeSoundWhenDying(string name, string sound)
    {
        return $"{name} is dead.  {sound}";
    }

    public string MakeSoundWhenEating(string name, string sound)
    {
        return $"{name} is eating! {sound}";
    }
}
