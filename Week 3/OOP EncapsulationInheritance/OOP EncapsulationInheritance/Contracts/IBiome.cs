using OOP_EncapsulationInheritance.Animals;

namespace OOP_EncapsulationInheritance.Contracts;

public interface IBiom
{
    public (IEnumerable<Animal>, IEnumerable<IEatable>) GenerateBiom();
}