using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTilesStrategy : PreInitializationStrategy
{
    private readonly Transform Parent;

    public InstantiateTilesStrategy(Transform parent)
    {
        Parent = parent;
    }

    public override void DoChange(GeneratorMapTile tile)
    {
        tile.PrefabInstance = Instantiate(tile.Original.Prefab, Parent);
    }
}
