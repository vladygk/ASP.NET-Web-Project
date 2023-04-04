using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Behaviour;
using OOP_EncapsulationInheritance.Biomes;
using OOP_EncapsulationInheritance.Contracts;
using OOP_EncapsulationInheritance.IO;
using OOP_EncapsulationInheritance.Statistics;

namespace OOP_EncapsulationInheritance;

public class Simulation
{
    private const int NumberOfAnimals = 3;
    private int dayCounter = 0;

    private readonly List<Animal> animals;
    private readonly List<IEatable> food;
    private readonly bool detailedStats;
    private readonly Random random;
    private readonly IBiome biome;
    private readonly IStatistics statistics;
    private readonly IWriter writer;
    private readonly IBehaviour behaviour;

    public Simulation(Random random, IStatistics statistics, IBiome biome, IWriter writer, bool detailedStats, IBehaviour behaviour)
    {
        this.biome = biome;
        this.statistics = statistics;
        (IEnumerable<Animal> animals, IEnumerable<IEatable> food) = this.biome.GenerateBiom(NumberOfAnimals);
        this.animals = animals.ToList();
        this.food = food.ToList();
        this.random = random;
        this.detailedStats = detailedStats;
        this.writer = writer;
        this.behaviour = behaviour;
    }


    public void Start()
    {
        while (animals.Any(x => !x.IsDead))
        {

            foreach (var animal in animals)
            {
                if (animal.IsDead)
                {
                    continue;
                }

                IEatable currentFood = GetRandomFood();
                if (currentFood.IsEaten)
                {
                    continue;
                }
                bool hasEaten = animal.Eat(currentFood);

                if (hasEaten)
                {
                    string eatingMessage = this.behaviour.MakeSoundWhenEating(animal.Name, animal.AnimalSound);

                    this.writer.Write(eatingMessage);
                }
                
                if (animal.IsHungry)
                {
                    string hungryMessage = this.behaviour.MakeSoundWhenHungry(animal.Name, animal.AnimalSound);

                    this.writer.Write(hungryMessage);
                }





                if (animal.IsDead)
                {
                    string deathMessage = this.behaviour.MakeSoundWhenDying(animal.Name, animal.AnimalSound);

                    this.writer.Write(deathMessage);

                }
                else
                {
                    animal.Age++;
                }
            }

            dayCounter++;
            string dailyStatistics = statistics.GenerateDailyStatistics(dayCounter, this.animals, detailedStats);
            this.writer.Write(dailyStatistics);

            RegenerateFood();
        }


        string generalStatistics = statistics.GenerateStatistics(this.animals);
        this.writer.Write(generalStatistics);
    }

    private IEatable GetRandomFood()
    {
        int randomIndex = random.Next(food.Count);
        return this.food[randomIndex];
    }

    private void RegenerateFood()
    {
        foreach (var food in food)
        {
            food.RestoreNutritionalValue();
        }
    }

}

