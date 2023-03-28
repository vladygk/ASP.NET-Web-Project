using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance.Animals.Herbivore;

public abstract class Herbivore : Animal
{
    static readonly HashSet<FoodType> _dietYoung;
    static readonly HashSet<FoodType> _dietMature;

    static Herbivore()
    {
        _dietYoung = new HashSet<FoodType>() { new Fruit() };
        _dietMature = new HashSet<FoodType>() { new Fruit(), new Vegetable() };
    }
    private const string animalSound = "Mlem-mlem";
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
        Console.ForegroundColor=ConsoleColor.Green;
        Console.WriteLine($"{this.GetType().Name} is hungry! {animalSound}");
    }

    public override void CryWhenDead()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{this.GetType().Name} is dead :((  {animalSound}");
    }
    public override void CryWhenEating()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{this.GetType().Name} is eating! {animalSound}");
    }

}

