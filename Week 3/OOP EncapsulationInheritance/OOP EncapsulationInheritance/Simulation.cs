using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Contracts;


namespace OOP_EncapsulationInheritance;

public class Simulation
{
    private int dayCounter = 0;


    private readonly List<Animal> _animals;
    private readonly List<IEatable> _food;
    private readonly bool _detailedStats;
    private readonly Random _random;
    private readonly IBiom _biom;
    private readonly IStatistics _statistics;

    public Simulation(Random random, IStatistics statistics, IBiom biom, bool detailedStats)
    {
        this._biom = biom;
        this._statistics = statistics;
        (IEnumerable<Animal> animals, IEnumerable<IEatable> food) = biom.GenerateBiom();
        this._animals = animals.ToList();
        this._food = food.ToList();
        this._random = random;
        this._detailedStats = detailedStats;
    }


    public void Start()
    {
        while (_animals.Any(x => !x.IsDead))
        {
            dayCounter++;

            _statistics.GenerateDailyStatistics(dayCounter, this._animals, _detailedStats);

            foreach (var animal in _animals)
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
                animal.Eat(currentFood);

                if (!animal.IsDead)
                {
                    animal.Age++;

                }
            }


            RegenerateFood();
        }
        _statistics.GenerateDailyStatistics(dayCounter, this._animals, _detailedStats);

        _statistics.GenerateStatistics(this._animals);
    }

    public IEatable GetRandomFood()
    {
        int randomIndex = _random.Next(_food.Count);
        return this._food[randomIndex];
    }

    public void RegenerateFood()
    {
        foreach (var food in _food)
        {
            food.RestoreNutritionalValue();
        }
    }

}

