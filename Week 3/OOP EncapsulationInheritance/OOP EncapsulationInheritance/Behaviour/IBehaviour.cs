
namespace OOP_EncapsulationInheritance.Behaviour;
using Enums;

public interface IBehaviour
{
    string MakeSoundWhenHungry(IEatableTypes type, string sound);
    string MakeSoundWhenDying(IEatableTypes type, string sound);
    string MakeSoundWhenEating(IEatableTypes type, string sound);
}