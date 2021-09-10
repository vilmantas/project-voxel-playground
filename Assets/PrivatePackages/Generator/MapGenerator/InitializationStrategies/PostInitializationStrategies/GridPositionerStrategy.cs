using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPositionerStrategy : PostInitializationStrategy
{
    public override void DoChange(GeneratorMapTile tile)
    {
        var transform = tile.PrefabInstance.transform;
        var renderer = tile.PrefabInstance.GetComponentInChildren<Renderer>();

        if (renderer == null) renderer = tile.PrefabInstance.GetComponent<Renderer>();

        transform.localPosition = new Vector3(renderer.bounds.size.x / 2 + tile.Position.x * renderer.bounds.size.x, tile.Position.y * renderer.bounds.size.y, renderer.bounds.size.z / 2 + tile.Position.z * renderer.bounds.size.z);
    }
}
