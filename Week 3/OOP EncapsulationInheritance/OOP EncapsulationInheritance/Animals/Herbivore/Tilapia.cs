
namespace OOP_EncapsulationInheritance.Animals.Herbivore
{
    using Diets;
    public class Tilapia : Herbivore
    {
        public Tilapia(IDiet diet) : base(diet)
        {
        }

        public override Animal Instantiate(IDiet diet)
        {
            return new Tilapia(diet);
        }
    }
}
