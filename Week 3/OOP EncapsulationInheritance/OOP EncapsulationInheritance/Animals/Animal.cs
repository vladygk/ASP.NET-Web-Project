
using OOP_EncapsulationInheritance.Enum;
using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance.Animals
{
    public abstract class Animal
    {
      
        const int MAXIMUM_ENERGY =10;
        protected Animal()
        {
           CurrentEnergy = MAXIMUM_ENERGY;
        }

        public int CurrentEnergy { get; set; }
        

        public Diets Diet { get; set; }
        public int LifeSpan { get; set; }
        public bool IsDead  => CurrentEnergy <= 0;
        public void Feed(FoodType food)
        {
            if (food.FoodDiet == Diet)
            {
                CurrentEnergy++;
                if (CurrentEnergy > MAXIMUM_ENERGY)
                {
                    CurrentEnergy= MAXIMUM_ENERGY;
                }
            }
            else
            {
                CurrentEnergy--;
            }
        }
    }
}
