using OOP_EncapsulationInheritance.Animals;
using OOP_EncapsulationInheritance.Diets;

namespace OOP_EncapsulationInheritance.Factories
{
    public class AnimalFactory
    {
        private readonly Dictionary<string, Func<IDiet, Animal>> animalTypes;

        
        public AnimalFactory(Dictionary<string, Func<IDiet, Animal>> animalTypes)
        {
            this.animalTypes = animalTypes;
        }

        public  Animal Create(string animalName, IDiet diet)
        {
            return animalTypes[animalName].Invoke(diet);
        }

       

    }
}
