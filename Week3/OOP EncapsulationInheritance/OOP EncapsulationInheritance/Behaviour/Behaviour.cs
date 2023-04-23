namespace OOP_EncapsulationInheritance.Behaviour;

using Enums;

public class Behaviour : IBehaviour
{
    public string MakeSoundWhenHungry(IEatableTypes type, string sound)
    {
        return $"{type} is hungry.. {sound}";
    }

    public string MakeSoundWhenDying(IEatableTypes type, string sound)
    {
        return $"{type} is dead.  {sound}";
    }

    public string MakeSoundWhenEating(IEatableTypes type, string sound)
    {
        return $"{type} is eating! {sound}";
    }
}
