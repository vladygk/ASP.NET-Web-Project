using OOP_EncapsulationInheritance.Food;

namespace OOP_EncapsulationInheritance.Animals
{
    public abstract class Animal
    {

        const int MAXIMUM_ENERGY = 10;

        protected Animal()
        {
            CurrentEnergy = MAXIMUM_ENERGY;
        }

        private int CurrentEnergy { get; set; }

        protected abstract IEnumerable<FoodType> Diet { get;  }
        public int LifeSpan { get; set; }
        public bool IsDead => CurrentEnergy <= 0;
        protected bool IsMature => LifeSpan > 18;

        public bool IsHungry => CurrentEnergy < MAXIMUM_ENERGY / 2;
        public abstract void CryWhenEating();
        
        public abstract void CryWhenHungry();

        public abstract void CryWhenDead();
        
        

        public void Feed(FoodType food)
        {

            if (this.Diet.Contains(food))
            {
                CurrentEnergy++;
                if (CurrentEnergy > MAXIMUM_ENERGY)
                {
                    CurrentEnergy = MAXIMUM_ENERGY;
                   
                }
                else
                {
                    CryWhenEating();
                }
            }
            else
            {
                CurrentEnergy--;
                
                if (IsDead)
                {
                    CryWhenDead();
                }
            }
        }


    }
}
