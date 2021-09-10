using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapTileBuilder
{
    public static GeneratorMapTile BuildEmptyTile()
    {
        return new GeneratorMapTile();
    }

    public static GeneratorMapTile BuildWithPositionAndInstance(int x, int y, int z, GameObject instance, string name)
    {
        return new GeneratorMapTile()
        {
            Position = new Vector3Int(x, y, z),
            PrefabInstance = instance,
            Original = new TileValue()
            {
                Name = name
            }
        };
    }

    public static GeneratorMapTile BuildTileWithPrefab(GameObject prefab)
    {
        return new GeneratorMapTile()
        {
            Original = new TileValue()
            {
                Name = prefab.name,
                Prefab = prefab
            }
        };
    }
}
