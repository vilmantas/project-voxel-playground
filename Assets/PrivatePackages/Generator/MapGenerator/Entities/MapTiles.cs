using Generator.Iterators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTiles : IEnumerable<GeneratorMapTile>
{
    public readonly Vector3Int Size;

    public GeneratorMapTile[][][] Tiles;

    public MapTiles(Vector3Int size)
    {
        Size = size;

        PrepareTiles(size);
    }

    private void PrepareTiles(Vector3Int size)
    {
        int depth = size.z;
        int height = size.y;
        int width = size.x;

        Tiles = new GeneratorMapTile[depth][][];

        for (int z = 0; z < depth; z++)
        {
            Tiles[z] = new GeneratorMapTile[height][];

            for (int y = 0; y < height; y++)
            {
                Tiles[z][y] = new GeneratorMapTile[width];
            }
        }
    }

    public GeneratorMapTile this[Vector3Int position]
    {
        get => Tiles[position.z][position.y][position.x];
        set
        {
            value.Position = position;
            Tiles[position.z][position.y][position.x] = value;
        }
    }

    public IEnumerator<GeneratorMapTile> GetEnumerator()
    {
        return new WidthFirstMapIterator(Tiles);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new WidthFirstMapIterator(Tiles);
    }
}
