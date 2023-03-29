using System.ComponentModel;

namespace OOP_EncapsulationInheritance.Animals.Herbivore;

public abstract class Herbivore : Animal
{
    static readonly HashSet<string> _dietYoung;
    static readonly HashSet<string> _dietMature;
    private const int DefaultNutritionalValue = 5;
    static Herbivore()
    {
        _dietYoung = new HashSet<string>() {"Fruit" };
        _dietMature = new HashSet<string>() { "Fruit","Vegetable" };
    }
    public override int MaximumEnergy { get; set; } = 10;

    protected Herbivore()
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
        Console.ForegroundColor=ConsoleColor.Green;
        Console.WriteLine($"{this.GetType().Name} is hungry.. {animalSound}");
    }

    protected override void MakeSoundWhenDying()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{this.GetType().Name} is dead.  {animalSound}");
    }
    protected override void MakeSoundWhenEating(string foodName)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{this.GetType().Name} is eating a {foodName}! {animalSound}");
    }

}

