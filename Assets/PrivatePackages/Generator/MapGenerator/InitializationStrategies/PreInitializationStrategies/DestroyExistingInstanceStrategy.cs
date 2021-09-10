using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExistingInstanceStrategy : PreInitializationStrategy
{
    public override void DoChange(GeneratorMapTile tile)
    {
        if (tile?.PrefabInstance != null)
        {
            DestroyImmediate(tile.PrefabInstance);
        }
    }
}
