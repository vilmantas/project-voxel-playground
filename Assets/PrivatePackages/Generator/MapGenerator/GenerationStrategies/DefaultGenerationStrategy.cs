using Generator.Iterators;
using UnityEngine;

public class DefaultGenerationStrategy : IGenerationStrategy
{
    ItemPickingStrategy ItemPickingStrategy;

    public DefaultGenerationStrategy(ItemPickingStrategy itemPickingStrategy)
    {
        ItemPickingStrategy = itemPickingStrategy;
    }

    public MapTiles GenerateMapTiles(Vector3Int size)
    {
        MapTiles result = new MapTiles(size);

        var it = new WidthFirstVectorIterator(size);

        while (it.MoveNext())
        {
            result[it.Current] = MapTileBuilder.BuildTileWithPrefab(ItemPickingStrategy.GetItem());
        }

        return result;
    }
}
