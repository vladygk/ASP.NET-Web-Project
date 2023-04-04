namespace OOP_EncapsulationInheritance.Animals;

using Diets;
using Contracts;

public abstract class Animal : IEatable
{

    private int maxEnergy;
    private int currentEnergy;
    private readonly IDiet diet;



    protected Animal(int maxEnergy, int nutritionalValue, string animalSound, IDiet diet)
    {
        this.maxEnergy = maxEnergy;

        this.currentEnergy = maxEnergy;

        this.NutritionalValue = nutritionalValue;
        this.AnimalSound = animalSound;
        this.diet = diet;

    }
    public HashSet<string> CurrentDiet
    {
        get
        {
            if (IsMature)
            {
                return diet.DietMatureAnimal.ToHashSet();
            }
            else
            {
                return diet.DietYoungAnimal.ToHashSet();
            }
        }
    }



    public int CurrentEnergy
    {
        get => currentEnergy;
        set
        {
            if (currentEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
            else
            {
                currentEnergy = value;
            }
        }
    }


    public int NutritionalValue { get; set; }

    public string Name => this.GetType().Name;

    public int Age { get; set; }

    public bool IsHungry => CurrentEnergy < this.maxEnergy / 2;

    protected bool IsMature => Age > 18;

    public bool IsEaten => this.NutritionalValue == 0;

    public bool IsDead => IsEaten || CurrentEnergy <= 0;

    public string AnimalSound { get; set; }



    public void RestoreNutritionalValue() { }

    public int GetEaten(int amountEaten)
    {
        int nutritionalValueGiven;

        if (amountEaten > this.NutritionalValue)
        {
            nutritionalValueGiven = this.NutritionalValue;
            this.NutritionalValue = 0;

        }
        else
        {
            this.NutritionalValue -= amountEaten;
            nutritionalValueGiven = amountEaten;
        }

        return nutritionalValueGiven;


    }

    public bool Eat(IEatable food)
    {

        if (CurrentDiet.Contains(food.Name))
        {

            int amountCanEat = this.maxEnergy - this.CurrentEnergy;

            this.CurrentEnergy += food.GetEaten(amountCanEat);



            return true;

        }

        this.CurrentEnergy--;
        return false;

    }

    public override string ToString()
    {
        int energy = this.CurrentEnergy < 0 ? 0 : this.CurrentEnergy;
        return $"{this.Name}-> Energy:{energy} Dead:{this.IsDead}";
    }

    public abstract Animal Instantiate(IDiet diet);


}
