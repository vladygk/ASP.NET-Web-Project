using OOP_EncapsulationInheritance.Biomes;

namespace OOP_EncapsulationInheritance;

using Animals;
using Behaviour;
using Contracts;
using IO;
using Statistics;

public class Simulation
{
    
    private int dayCounter = 0;

    private List<Animal> animals;
    //private readonly List<IEatable> food;

    private readonly bool detailedStats;
    private readonly Random random;
    private readonly Map map;
    private readonly IStatistics statistics;
    private readonly IWriter writer;
    private readonly IBehaviour behaviour;


    public Simulation(int numberOfAnimals,
        Random random,
        IStatistics statistics, 
        Map map, IWriter writer, bool detailedStats, IBehaviour behaviour)
    {
        this.map = map;
        this.statistics = statistics;

        List<Animal> allAnimals = new List<Animal>();
        foreach (var tile in this.map.GetTiles)
        {
            // add animals from each Biom
            allAnimals.AddRange(tile.Animals);
        }
        this.animals = allAnimals;
       

        this.random = random;
        this.detailedStats = detailedStats;
        this.writer = writer;
        this.behaviour = behaviour;
    }


    public void Start()
    {

        List<Animal> aliveAnimals = this.animals;
        List<Animal> deadAnimals = this.animals;
        while (animals.Any(x => !x.IsDead))
        {

            foreach (var animal in animals)
            {
              

                IEatable currentFood = GetRandomFood(animal);
                if (currentFood.IsEaten)
                {
                    continue;
                }

                bool hasEaten = animal.Eat(currentFood);
                if (animal.IsDead)
                {
                    aliveAnimals.Remove(animal);
                    deadAnimals.Add(animal);
                    
                }
                CheckStatus(hasEaten, animal);
            }

            this.animals = new List<Animal>(aliveAnimals);
            dayCounter++;

            string dailyStatistics = statistics.GenerateDailyStatistics(dayCounter, animals, detailedStats);

            this.writer.Write(dailyStatistics);
            foreach (var tile in this.map.GetTiles)
            {
                RegenerateFood(tile);
            }
        }

        string generalStatistics = statistics.GenerateStatistics(deadAnimals);
        this.writer.Write(generalStatistics);

    }

    private void CheckStatus(bool hasEaten, Animal animal)
    {
        if (hasEaten)
        {
            string eatingMessage = this.behaviour.MakeSoundWhenEating(animal.Type, animal.AnimalSound);

            this.writer.Write(eatingMessage);
        }

        if (animal.IsHungry)
        {
            string hungryMessage = this.behaviour.MakeSoundWhenHungry(animal.Type, animal.AnimalSound);

            this.writer.Write(hungryMessage);
        }

        if (animal.IsDead)
        {
            string deathMessage = this.behaviour.MakeSoundWhenDying(animal.Type, animal.AnimalSound);

            this.writer.Write(deathMessage);

        }
        else
        {
            animal.Age++;
        }
    }
    private IEatable GetRandomFood(Animal animal)
    {
        var currentAnimalBiomeFood = animal.CurrentBiome.Foods;
        int randomIndex = random.Next(currentAnimalBiomeFood.Count);
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

