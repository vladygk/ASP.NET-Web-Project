
namespace OOP_EncapsulationInheritance.Animals;

using Biomes;
using Enums;
using Diets;
using Contracts;

public abstract class Animal : IEatable
{

    private int maxEnergy;
    private int currentEnergy;
    private readonly IDiet diet;
    private readonly Map map;
    private readonly Random rnd;

    public IBiome CurrentBiome { get; set; }

    protected Animal(
        int maxEnergy, 
        int nutritionalValue, 
        string animalSound, 
        IDiet diet, 
        IBiome startBiome,
        Map map,
        Random random)
    {
        this.maxEnergy = maxEnergy;
        this.CurrentBiome = startBiome;
        this.currentEnergy = maxEnergy;
        this.map = map;
        this.CurrentBiome = startBiome;
        this.rnd = random;
        this.NutritionalValue = nutritionalValue;
        this.AnimalSound = animalSound;
        this.diet = diet;

    }
    public HashSet<IEatableTypes> CurrentDiet
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

    public void Move()
    {
        List<IBiome> neighbourBiomes = this.GetNeighbours();
        int index = GetRandomIndex(neighbourBiomes.Count);

        IBiome biomeToMoveTo = neighbourBiomes[index];

        if (biomeToMoveTo.AnimalTypes.ContainsKey(this.Type))
        {
            this.CurrentBiome.Animals.Remove(this);
            this.CurrentBiome.Foods.Remove(this);

            this.CurrentBiome = biomeToMoveTo;

            this.CurrentBiome.Animals.Add(this);
            this.CurrentBiome.Foods.Add(this);
        }
    }

    private int GetRandomIndex(int neighboursCount)
    {
        return this.rnd.Next(neighboursCount);
    }
     
    private List<IBiome> GetNeighbours()
    {
        List<IBiome> neighbours = new List<IBiome>();
        int currentX = this.CurrentBiome.Coordinates.x;
        int currentY = this.CurrentBiome.Coordinates.y;

        if (currentX > 0)
        {
            neighbours.Add(map.GetTiles[currentX-1,currentY]);
        }

        if (currentX > 0 && currentY > 0)
        {
            neighbours.Add(map.GetTiles[currentX - 1, currentY-1]);
        }

        if (currentX > 0 && currentY < map.GetTiles.GetLength(1)-1)
        {
            neighbours.Add(map.GetTiles[currentX - 1, currentY + 1]);
        }

        if (currentY > 0)
        {
            neighbours.Add(map.GetTiles[currentX , currentY - 1]);
        }

        if (currentY < map.GetTiles.GetLength(1) - 1)
        {
            neighbours.Add(map.GetTiles[currentX, currentY + 1]);
        }

        if (currentX < map.GetTiles.GetLength(0)-1)
        {
            neighbours.Add(map.GetTiles[currentX + 1, currentY]);
        }

        if (currentX < map.GetTiles.GetLength(0) - 1 && currentY > 0)
        {
            neighbours.Add(map.GetTiles[currentX + 1, currentY-1]);
        }

        if (currentX < map.GetTiles.GetLength(0) - 1 && currentY < map.GetTiles.GetLength(1) - 1)
        {
            neighbours.Add(map.GetTiles[currentX + 1, currentY + 1]);
        }

        return neighbours;
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

    public IEatableTypes Type { get;  set; }

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

        if (CurrentDiet.Contains(food.Type))
        {

            int amountCanEat = this.maxEnergy - this.CurrentEnergy;

            this.CurrentEnergy += food.GetEaten(amountCanEat);



            return true;

        }

        this.CurrentEnergy--;
        return false;

    }

   

    public abstract Animal Instantiate(IBiome startBiome, Map map, Random rnd);

    
}
