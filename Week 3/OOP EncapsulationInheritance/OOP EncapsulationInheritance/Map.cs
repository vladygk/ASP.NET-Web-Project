

namespace OOP_EncapsulationInheritance;

using Enums;
using Biomes;
using System;

public class Map
{
    private IBiome[,] tiles;
    private Func<IBiome>[] availableBiomes;
    private Random rnd;
    public Map(int size, Random rnd, int numberOfAnimals)
    {
        this.rnd = rnd;
        this.tiles = new IBiome[size, size];
        
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                var type = GetRandomBiomeForTile();
                switch (type)
                {
                    case BiomeTypes.ForestBiome:
                        tiles[i, j] = new ForestBiome(numberOfAnimals, this, rnd);
                        break;
                    case BiomeTypes.OceanBiome:
                        tiles[i, j] = new OceanBiome(numberOfAnimals, this, rnd);
                        break;
                }

                tiles[i, j].Coordinates = (i, j);
            }
        }
    }

    public IBiome[,] GetTiles => this.tiles;

    private BiomeTypes GetRandomBiomeForTile()
    {
        var values = Enum.GetValues(typeof(BiomeTypes));

        BiomeTypes randomBiome = (BiomeTypes)values.GetValue(this.rnd.Next(values.Length));

        
        
        return randomBiome;
    }
}

