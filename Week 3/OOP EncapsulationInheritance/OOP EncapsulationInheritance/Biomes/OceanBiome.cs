namespace OOP_EncapsulationInheritance.Biomes;
using Animals;
using Animals.Carnivore;
using Animals.Herbivore;
using Animals.Omnivore;
using Contracts;
using Diets;
using Factories;
using Food;

public class OceanBiome : IBiome
{
    private Dictionary<string, IDiet> diets = new Dictionary<string, IDiet>()
        {
            {
                "shark",
                new Diet(
                    new HashSet<string>(){"Meat","Bone","tilapia"},
                    new HashSet<string>(){"Meat","Bone","tilapia"})
            },
            {
                "whale",
                new Diet(
                    new HashSet<string>(){ "Seaweed"},
                    new HashSet<string>(){ "Seaweed", "Meat"})
            },
            {
                "tilapia",
                new Diet(
                    new HashSet<string>(){"Seaweed"},
                    new HashSet<string>(){"Seaweed"})
            }
        };

    private Dictionary<string, Func<IEatable>> foodTypes;
    private Dictionary<string, Func<IDiet, Animal>> animalTypes;
    private AnimalFactory animalFactory;
    private FoodFactory foodFactory;


    public OceanBiome()
    {
        animalTypes =
            new Dictionary<string, Func<IDiet, Animal>>()
            {
                    {"whale", new Whale( this.diets["whale"]).Instantiate },
                    {"tilapia", new Tilapia( this.diets["tilapia"]).Instantiate },
                    {"shark", new Shark( this.diets["shark"]).Instantiate },
            };

        foodTypes = foodTypes = new Dictionary<string, Func<IEatable>>()
            {
                {"bone", new Bone().Instantiate},
                {"meat", new Meat().Instantiate},
                {"seaweed", new Seaweed().Instantiate},
            
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
        return new OceanBiome();
    }
}

