namespace OOP_EncapsulationInheritance.Behaviour;

public class BehaviourSpanish : IBehaviour
{
    public string MakeSoundWhenHungry(string name, string sound)
    {
        return $"{name} tiene hambre.. {sound}";
    }

    public string MakeSoundWhenDying(string name, string sound)
    {
        return $"{name} ha morido.  {sound}";
    }

    public string MakeSoundWhenEating(string name, string sound )
    {
        return $"{name} esta comiendo! {sound}";
    }
}
