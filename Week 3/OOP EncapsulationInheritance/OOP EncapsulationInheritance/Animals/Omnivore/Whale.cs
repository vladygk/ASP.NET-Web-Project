namespace OOP_EncapsulationInheritance.Animals.Omnivore;

    using Biomes;
    using Diets;
    using Enums;

    public class Whale : Omnivore
    {
        private static IDiet _diet = new Diet(
            new HashSet<IEatableTypes>() { IEatableTypes.Seaweed },
            new HashSet<IEatableTypes>() { IEatableTypes.Seaweed, IEatableTypes.Meat });

        public Whale(IBiome startBiome, Map map, Random rnd)
            : base(_diet, startBiome, map, rnd)
        {
            this.Type = IEatableTypes.Whale;
        }

        public override Animal Instantiate(IBiome startBiome, Map map, Random rnd)
        {
            return new Whale(startBiome, map, rnd);
        }
    }