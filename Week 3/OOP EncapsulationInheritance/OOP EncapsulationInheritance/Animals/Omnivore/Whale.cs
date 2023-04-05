namespace OOP_EncapsulationInheritance.Animals.Omnivore
{
    using Diets;
    public class Whale : Omnivore
    {
        public Whale(IDiet diet) : base(diet)
        {
        }

        public override Animal Instantiate(IDiet diet)
        {
            return new Whale(diet);
        }
    }
}
