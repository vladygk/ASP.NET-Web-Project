
namespace OOP_EncapsulationInheritance.Factories;

using Contracts;

using Food;
    public class FoodFactory
    {
        private readonly Dictionary<string, Func<IEatable>> foodTypes;

        public FoodFactory(Dictionary<string, Func<IEatable>> foodTypes)
        {
            this.foodTypes = foodTypes;
        }
        public  IEatable Create(string foodName)
        {
            return foodTypes[foodName].Invoke();
        }
        


    }

