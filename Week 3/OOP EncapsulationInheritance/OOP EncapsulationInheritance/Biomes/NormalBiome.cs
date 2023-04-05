using OOP_EncapsulationInheritance.Animals.Carnivore;
using OOP_EncapsulationInheritance.Animals.Herbivore;
using OOP_EncapsulationInheritance.Animals.Omnivore;
using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance.Biomes;

using Diets;
using Animals;
using Contracts;
using Factories;

public class NormalBiome : IBiome
{
    private   Dictionary<string, IDiet> diets = new Dictionary<string, IDiet>()
    {
        {
            "lion",
            new Diet(
                new HashSet<string>(){"Meat","Bone","Zebra"},
                new HashSet<string>(){"Meat","Zebra"})
        },
        {
            "bear",
            new Diet(
                new HashSet<string>(){"IceCream","Pizza"},
                new HashSet<string>(){"IceCream"})
        },
        {
            "zebra",
            new Diet(
                new HashSet<string>(){"Vegetable","Fruit"},
                new HashSet<string>(){"Fruit"})
        }
    };

    private Dictionary<string, Func<IEatable>> foodTypes;

    private Dictionary<string, Func<IDiet, Animal>> animalTypes;
      
    private AnimalFactory animalFactory;

    private FoodFactory foodFactory;
    public NormalBiome()
    {
        animalTypes =
            new Dictionary<string, Func<IDiet, Animal>>()
            {
                {"lion", new Lion( this.diets["lion"]).Instantiate },
                {"bear", new Bear( this.diets["lion"]).Instantiate },
                {"zebra", new Zebra( this.diets["lion"]).Instantiate },
            };

        foodTypes = foodTypes = new Dictionary<string, Func<IEatable>>()
        {
            {"bone", new Bone().Instantiate},
            {"meat", new Meat().Instantiate},
            {"iceCream", new IceCream().Instantiate},
            {"pizza", new Pizza().Instantiate},
            {"vegetable", new Vegetable().Instantiate},
            {"fruit", new Fruit().Instantiate},
        };

        this.animalFactory = new AnimalFactory(animalTypes);
        this.foodFactory = new FoodFactory(foodTypes);
    }
    public (List<Animal>, List<IEatable>) GenerateBiom(int numberOfAnimals)
    {
        


        List<IEatable> food = new List<IEatable>();

        foreach (var foodType in this.foodTypes)
        {
           
            food.Add(foodType.Value.Invoke());
        }

        List<Animal> animals = new List<Animal>();

        foreach (var animalType in animalTypes)
        {
            string animalName = animalType.Key;

            for (int i = 0; i < numberOfAnimals; i++)
            {


                animals.Add(animalType.Value.Invoke(this.diets[animalName]));

                food.Add(animalType.Value.Invoke(this.diets[animalName]));
            }
        }

        return (animals, food);
    }

    public IBiome Instantiate()
    {
        return new NormalBiome();
    }
}