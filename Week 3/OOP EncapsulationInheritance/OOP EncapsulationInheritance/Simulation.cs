namespace OOP_EncapsulationInheritance;

using Biomes;
using Animals;
using Behaviour;
using Contracts;
using IO;
using Statistics;

public class Simulation
{
    private readonly bool _detailedStats;
    private readonly Random _random;
    private readonly Map _map;
    private readonly IStatistics _statistics;
    private readonly IWriter _writer;
    private readonly IBehaviour _behaviour;
    private int _dayCounter = 0;

    private List<Animal> _animals;
    // private readonly List<IEatable> food;



    public Simulation(Random random,
        IStatistics statistics,
        Map map, IWriter writer, bool detailedStats, IBehaviour behaviour)
    {
        this._map = map;
        this._statistics = statistics;

        List<Animal> allAnimals = new List<Animal>();
        foreach (var tile in this._map.GetTiles)
        {
            // add animals from each Biom
            allAnimals.AddRange(tile.Animals);
        }

        this._animals = allAnimals;
        this._random = random;
        this._detailedStats = detailedStats;
        this._writer = writer;
        this._behaviour = behaviour;
    }

    public void Start()
    {
        List<Animal> aliveAnimals = this._animals;
        List<Animal> deadAnimals = this._animals;
        while (_animals.Any(x => !x.IsDead))
        {
            foreach (var animal in _animals)
            {
                IEatable currentFood = GetRandomFood(animal);
                if (currentFood.IsEaten)
                {
                    animal.Age++;
                    continue;
                }

                bool hasEaten = animal.Eat(currentFood);

                animal.Move();

                this.CheckStatus(hasEaten, animal);
                if (animal.IsDead)
                {
                    aliveAnimals.Remove(animal);
                    deadAnimals.Add(animal);
                }
            }

            this._animals = new List<Animal>(aliveAnimals);
            this._dayCounter++;

            string dailyStatistics = _statistics.GenerateDailyStatistics(this._dayCounter, _animals, _detailedStats);

            this._writer.Write(dailyStatistics);
            foreach (var tile in this._map.GetTiles)
            {
                this.RegenerateFood(tile);
            }
        }

        string generalStatistics = this._statistics.GenerateStatistics(deadAnimals);
        this._writer.Write(generalStatistics);
    }

    private void CheckStatus(bool hasEaten, Animal animal)
    {
        if (hasEaten)
        {
            string eatingMessage = this._behaviour.MakeSoundWhenEating(animal.Type, animal.AnimalSound);

            this._writer.Write(eatingMessage);
        }

        if (animal.IsHungry)
        {
            string hungryMessage = this._behaviour.MakeSoundWhenHungry(animal.Type, animal.AnimalSound);

            this._writer.Write(hungryMessage);
        }

        if (animal.IsDead)
        {
            string deathMessage = this._behaviour.MakeSoundWhenDying(animal.Type, animal.AnimalSound);

            this._writer.Write(deathMessage);
        }
        else
        {
            animal.Age++;
        }
    }

    private IEatable GetRandomFood(Animal animal)
    {
        var currentAnimalBiomeFood = animal.CurrentBiome.Foods;
        int randomIndex = _random.Next(currentAnimalBiomeFood.Count);
        return currentAnimalBiomeFood[randomIndex];
    }

    private void RegenerateFood(IBiome biome)
    {
        foreach (var food in biome.Foods)
        {
            food.RestoreNutritionalValue();
        }
    }
}