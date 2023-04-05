
namespace OOP_EncapsulationInheritance;

using Biomes;
public class Map
{
    private IBiome[,] tiles;
    private Func<IBiome>[] availableBiomes;
    private Random rnd;
    public Map(int size, Func<IBiome>[] availableBiomes, Random rnd)
    {
        this.rnd = rnd;
        this.tiles = new IBiome[size, size];
        this.availableBiomes = availableBiomes;
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                tiles[i, j] = GenerateBiomeForTile();
            }
        }
    }

    public IBiome[,] GetTiles => this.tiles;

    private IBiome GenerateBiomeForTile()
    {
        
        int index = this.rnd.Next(0,availableBiomes.Length);
        
        return availableBiomes[index].Invoke();
    }
}

