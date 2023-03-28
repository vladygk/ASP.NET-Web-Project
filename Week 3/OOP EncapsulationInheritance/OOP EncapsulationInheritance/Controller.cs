using System.Text;
using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance;

public class Controller
{

    private List<Animal> animals;
    private List<FoodType> food;

    public Controller(List<Animal> animals, List<FoodType> food,Random rnd)
    {
        this.animals = animals;
        this.food = food;
        this.rnd = rnd;
    }

    public  Random rnd { get; set; } 
    public void Simulate()
    {
        while (animals.Any(x => !x.IsDead))
        {
           
            foreach (var animal in animals)
            {

                if (animal.IsDead)
                {
                   
                    continue;
                }

                if (animal.IsHungry)
                {
                    animal.CryWhenHungry();
                }

                FoodType food = GetRandomFood();
                animal.Feed(food);
                animal.LifeSpan++;


            }
        }
    }

    public string GetStatistics()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"Average lifespan: {animals.Average(a => a.LifeSpan) :f0}");
        result.AppendLine($"Maximum lifespan: {animals.Max(a => a.LifeSpan)}");
        result.AppendLine($"Minimum lifespan: {animals.Min(a => a.LifeSpan)}");

        return result.ToString().Trim();
    }

    private FoodType GetRandomFood()
    {
       
        int index = rnd.Next(food.Count);

        return food[index];
    }
}

