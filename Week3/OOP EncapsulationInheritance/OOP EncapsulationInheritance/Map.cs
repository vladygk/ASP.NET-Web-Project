namespace OOP_EncapsulationInheritance;

using Enums;
using Biomes;
using System;

public class Map
{
    private IBiome[,] _tiles;
    private Func<IBiome>[] _availableBiomes;
    private Random _rnd;

    public Map(int size, Random rnd, int numberOfAnimals)
    {
        this._rnd = rnd;
        this._tiles = new IBiome[size, size];
        for (int i = 0; i < _tiles.GetLength(0); i++)
        {
            for (int j = 0; j < _tiles.GetLength(1); j++)
            {
                var type = this.GetRandomBiomeForTile();
                switch (type)
                {
                    case BiomeTypes.ForestBiome:
                        this._tiles[i, j] = new ForestBiome(numberOfAnimals, this, rnd);
                        break;
                    case BiomeTypes.OceanBiome:
                        this._tiles[i, j] = new OceanBiome(numberOfAnimals, this, rnd);
                        break;
                    case BiomeTypes.DessertBiome:
                        this._tiles[i, j] = new DessertBiome(numberOfAnimals, this, rnd);
                        break;
                }

                this._tiles[i, j].Coordinates = (i, j);
            }
        }
    }

    public IBiome[,] GetTiles => this._tiles;

    private BiomeTypes GetRandomBiomeForTile()
    {
        var values = Enum.GetValues(typeof(BiomeTypes));

        BiomeTypes randomBiome = (BiomeTypes)values.GetValue(this._rnd.Next(values.Length))!;

        return randomBiome;
    }
}