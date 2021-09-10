using Generator.GenerationStrategies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapBuilder
{
    public static GeneratorMap BuildEmptyMap(Vector3Int size)
    {
        return new GeneratorMap(new SimpleTileGenerationStrategy(MapTileBuilder.BuildEmptyTile), size);
    }

    public static GeneratorMap BuildMapWithPrefabs(Vector3Int size, ItemPickingStrategy prefabPickingStrategy)
    {
        return new GeneratorMap(new DefaultGenerationStrategy(prefabPickingStrategy), size);
    }

    public static GeneratorMap BuildFromExisting(List<GeneratorMapTile> tiles, ItemPickingStrategy itemPickingStrategy, Vector3Int size)
    {
        return new GeneratorMap(new FromExistingTilesGenerationStrategy(tiles, itemPickingStrategy), size);
    }
}
