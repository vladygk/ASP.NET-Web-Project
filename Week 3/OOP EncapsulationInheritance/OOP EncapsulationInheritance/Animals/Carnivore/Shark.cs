
namespace OOP_EncapsulationInheritance.Animals.Carnivore
{
    using Diets;
    public class Shark : Carnivore
    {
        public Shark(IDiet diet) : base(diet)
        {
        }

        public override Animal Instantiate(IDiet diet)
        {
            return new Shark(diet);
        }
    }
}
