namespace OOP_EncapsulationInheritance;

using Animals;
using Behaviour;
using Contracts;
using IO;
using Statistics;

public class Simulation
{
    private const int NumberOfAnimals = 3;
    private int dayCounter = 0;

    //private readonly List<Animal> animals;
    //private readonly List<IEatable> food;

    private readonly bool detailedStats;
    private readonly Random random;
    private readonly Map map;
    private readonly IStatistics statistics;
    private readonly IWriter writer;
    private readonly IBehaviour behaviour;

    private List<Animal> animals;
    private List<IEatable> food;
    public Simulation(Random random, IStatistics statistics, Map map, IWriter writer, bool detailedStats, IBehaviour behaviour)
    {
        this.map = map;
        this.statistics = statistics;





        //this.animals = animals.ToList();
        // this.food = food.ToList();
        this.random = random;
        this.detailedStats = detailedStats;
        this.writer = writer;
        this.behaviour = behaviour;
    }


    public void Start()
    {
        foreach (var tile in this.map.GetTiles)
        {
            (this.animals,this.food) = tile.GenerateBiom(NumberOfAnimals);
            var a = tile.GenerateBiom(NumberOfAnimals);

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
                string dailyStatistics = statistics.GenerateDailyStatistics(dayCounter, animals, detailedStats);
                this.writer.Write(dailyStatistics);

                RegenerateFood();
            }




            string generalStatistics = statistics.GenerateStatistics(animals);
            this.writer.Write(generalStatistics);
        }
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

