namespace OOP_EncapsulationInheritance.Animals;

using Biomes;
using Enums;
using Diets;
using Contracts;

public abstract class Animal : IEatable
{
    private readonly int _maxEnergy;
    private readonly IDiet _diet;
    private readonly Map _map;
    private readonly Random _rnd;
    private int _currentEnergy;

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
        this._maxEnergy = maxEnergy;
        this.CurrentBiome = startBiome;
        this._currentEnergy = maxEnergy;
        this._map = map;
        this.CurrentBiome = startBiome;
        this._rnd = random;
        this.NutritionalValue = nutritionalValue;
        this.AnimalSound = animalSound;
        this._diet = diet;
    }

    public HashSet<IEatableTypes> CurrentDiet
    {
        get
        {
            if (this.IsMature)
            {
                return this._diet.DietMatureAnimal.ToHashSet();
            }
            else
            {
                return this._diet.DietYoungAnimal.ToHashSet();
            }
        }
    }

    public int CurrentEnergy
    {
        get => this._currentEnergy;
        set
        {
            if (this._currentEnergy > this._maxEnergy)
            {
                this._currentEnergy = this._maxEnergy;
            }
            else
            {
                this._currentEnergy = value;
            }
        }
    }

    public int NutritionalValue { get; set; }

    public IEatableTypes Type { get; set; }

    public int Age { get; set; }

    public bool IsHungry => this.CurrentEnergy < this._maxEnergy / 2;

    protected bool IsMature => this.Age > 18;

    public bool IsEaten => this.NutritionalValue == 0;

    public bool IsDead => this.IsEaten || this.CurrentEnergy <= 0;

    public string AnimalSound { get; set; }

    public void Move()
    {
        List<IBiome> neighbourBiomes = this.GetNeighbours();
        int index = this.GetRandomIndex(neighbourBiomes.Count);

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

        if (this.CurrentDiet.Contains(food.Type))
        {
            int amountCanEat = this._maxEnergy - this.CurrentEnergy;

            this.CurrentEnergy += food.GetEaten(amountCanEat);

            return true;
        }

        this.CurrentEnergy--;
        return false;
    }

    public abstract Animal Instantiate(IBiome startBiome, Map map, Random rnd);

    private int GetRandomIndex(int neighboursCount)
    {
        return this._rnd.Next(neighboursCount);
    }

    private List<IBiome> GetNeighbours()
    {
        List<IBiome> neighbours = new List<IBiome>();
        int currentX = this.CurrentBiome.Coordinates.x;
        int currentY = this.CurrentBiome.Coordinates.y;

        if (currentX > 0)
        {
            neighbours.Add(this._map.GetTiles[currentX - 1, currentY]);
        }

        if (currentX > 0 && currentY > 0)
        {
            neighbours.Add(this._map.GetTiles[currentX - 1, currentY - 1]);
        }

        if (currentX > 0 && currentY < this._map.GetTiles.GetLength(1) - 1)
        {
            neighbours.Add(this._map.GetTiles[currentX - 1, currentY + 1]);
        }

        if (currentY > 0)
        {
            neighbours.Add(this._map.GetTiles[currentX, currentY - 1]);
        }

        if (currentY < this._map.GetTiles.GetLength(1) - 1)
        {
            neighbours.Add(this._map.GetTiles[currentX, currentY + 1]);
        }

        if (currentX < this._map.GetTiles.GetLength(0) - 1)
        {
            neighbours.Add(this._map.GetTiles[currentX + 1, currentY]);
        }

        if (currentX < this._map.GetTiles.GetLength(0) - 1 && currentY > 0)
        {
            neighbours.Add(this._map.GetTiles[currentX + 1, currentY - 1]);
        }

        if (currentX < this._map.GetTiles.GetLength(0) - 1 && currentY < this._map.GetTiles.GetLength(1) - 1)
        {
            neighbours.Add(this._map.GetTiles[currentX + 1, currentY + 1]);
        }

        return neighbours;
    }
}
