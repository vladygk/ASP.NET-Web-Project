using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance.Animals.Omnivore
{
    public abstract class Omnivore : Animal
    {
        static readonly IEnumerable<FoodType> _dietYoung;
        static readonly IEnumerable<FoodType> _dietMature;

        static Omnivore()
        {
            _dietYoung = new HashSet<FoodType>() { new IceCream() };
            _dietMature = new HashSet<FoodType>() { new IceCream(), new Pizza() };
        }
        private const string animalSound = "Oink-Oink";
        protected override IEnumerable<FoodType> Diet
        {

            get
            {
                if (IsMature)
                {
                    return _dietMature;
                }
                else
                {
                    return _dietYoung;
                }
            }
        }

        public override void CryWhenHungry()
        {
            Console.ForegroundColor=ConsoleColor.Blue;
            Console.WriteLine($"{this.GetType().Name} is hungry! {animalSound}");
        }

        public override void CryWhenDead()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{this.GetType().Name} is dead :((  {animalSound}");

        }

        public override void CryWhenEating()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{this.GetType().Name} is eating! {animalSound}");
        }
    }
}
