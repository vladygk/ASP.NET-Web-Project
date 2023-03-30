using OOP_EncapsulationInheritance.Contracts;
using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance.Factories
{
    internal class FoodFactory
    {
       
        public static IEatable CreateBone()
        {
            return new Bone();
        }
        public static IEatable CreateFruit()
        {
            return new Fruit();
        }
        public static IEatable CreateVegetable()
        {
            return new Vegetable();
        }

        public static IEatable CreateMeat()
        {
            return new Meat();
        }
        public static IEatable CreatePizza()
        {
            return new Pizza();
        }
        public static IEatable CreateIceCream()
        {
            return new IceCream();
        }


    }
}
