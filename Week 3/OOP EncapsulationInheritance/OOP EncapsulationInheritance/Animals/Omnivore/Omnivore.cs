using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance.Animals.Omnivore;

    public abstract class Omnivore : Animal
    {
        static readonly HashSet<string> _dietYoung;
        static readonly HashSet<string> _dietMature;
        private const int DefaultNutritionalValue = 4;
        static Omnivore()
        {
            _dietYoung = new HashSet<string>() { "IceCream" };
            _dietMature = new HashSet<string>() { "IceCream", "Pizza" };
        }

    public override int MaximumEnergy { get; set; } = 12;

    protected Omnivore()
    {
        CurrentEnergy = MaximumEnergy;
        NutritionalValue = DefaultNutritionalValue;
    }

    private const string animalSound = "Mlem-Mlem";
        protected override IEnumerable<string> Diet
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

        protected override void MakeSoundWhenHungry()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{this.GetType().Name} is hungry.. {animalSound}");
        }

        protected override void MakeSoundWhenDying()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{this.GetType().Name} is dead.  {animalSound}");
        }
        protected override void MakeSoundWhenEating(string foodName)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{this.GetType().Name} is eating a {foodName}! {animalSound}");
        }
    }
