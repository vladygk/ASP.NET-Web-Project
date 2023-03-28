using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance.Animals.Carnivore;

public abstract class Carnivore : Animal
{
    static readonly HashSet<FoodType> _dietYoung;
    private static readonly HashSet<FoodType> _dietMature;

     static Carnivore()
    {
        _dietYoung = new HashSet<FoodType>() { new Meat() };
        _dietMature =  new HashSet<FoodType>() { new Meat(), new Bone() };
    }
    private const string animalSound = "Grrr-Grrr";
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
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{this.GetType().Name} is hungry! {animalSound}");
    }

    public override void CryWhenDead()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{this.GetType().Name} is dead :((  {animalSound}");
       
    }
    public override void CryWhenEating()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{this.GetType().Name} is eating! {animalSound}");
    }
}

