using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromExistingTilesGenerationStrategy : IGenerationStrategy
{
    private readonly List<GeneratorMapTile> ExistingTiles;
    private readonly ItemPickingStrategy ItemPickingStrategy;

    public FromExistingTilesGenerationStrategy(List<GeneratorMapTile> existingTiles, ItemPickingStrategy itemPickingStrategy)
    {
        ExistingTiles = existingTiles;
        ItemPickingStrategy = itemPickingStrategy;
    }
    public MapTiles GenerateMapTiles(Vector3Int size)
    {
        var result = new MapTiles(size);

        foreach (var item in ExistingTiles)
        {
            item.Original.Prefab = ItemPickingStrategy.FindItemByName(item.Original.Name);
            result[item.Position] = item;
        }

        return result;
    }
}
