namespace OOP_EncapsulationInheritance.Animals.Herbivore;

    using Biomes;
    using Diets;
    using Enums;

    public class Tilapia : Herbivore
    {
        private static readonly IDiet _diet = new Diet(
            new HashSet<IEatableTypes>() { IEatableTypes.Seaweed },
            new HashSet<IEatableTypes>() { IEatableTypes.Seaweed });

        public Tilapia(IBiome startBiome, Map map, Random rnd)
            : base(_diet, startBiome, map, rnd)
        {
            this.Type = IEatableTypes.Tilapia;
        }

        public override Animal Instantiate(IBiome startBiome, Map map, Random rnd)
        {
            return new Tilapia(startBiome, map, rnd);
        }
    }