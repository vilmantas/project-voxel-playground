using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRandomTilesStrategy : PostInitializationStrategy
{
    [Range(0, 1)]
    public float DestroyChance;

    public override void DoChange(GeneratorMapTile tile)
    {
        if (Random.Range(0, 1f) < DestroyChance)
        {
            tile.PrefabInstance.SetActive(false);
        }
    }
}
