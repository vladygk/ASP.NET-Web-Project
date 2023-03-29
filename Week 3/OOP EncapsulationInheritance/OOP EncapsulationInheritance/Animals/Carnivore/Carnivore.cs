using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance.Animals.Carnivore;

public abstract class Carnivore : Animal
{
    static readonly HashSet<string> _dietYoung;
    static readonly HashSet<string> _dietMature;
    private const int DefaultNutritionalValue = 3;
    static Carnivore()
    {
        _dietYoung = new HashSet<string>() { "Meat", "Zebra" };
        _dietMature = new HashSet<string>() { "Bone", "Meat","Zebra" };
    }

    public override int MaximumEnergy { get; set; } = 9;

    protected Carnivore()
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
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{this.GetType().Name} is hungry.. {animalSound}");
    }

    protected override void MakeSoundWhenDying()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{this.GetType().Name} is dead.  {animalSound}");
    }
    protected override void MakeSoundWhenEating(string foodName)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{this.GetType().Name} is eating a {foodName}! {animalSound}");
    }
}

