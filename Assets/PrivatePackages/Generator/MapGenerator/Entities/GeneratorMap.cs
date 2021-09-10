using Generator.Iterators;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratorMap : IEnumerable<GeneratorMapTile>
{
    private static DestroyExistingInstanceStrategy DestroyStrategy = new DestroyExistingInstanceStrategy();

    public Vector3Int Size => Tiles.Size;

    public readonly MapTiles Tiles;

    public GeneratorMap(IGenerationStrategy strategy, Vector3Int size)
    {
        Tiles = strategy.GenerateMapTiles(size);
    }

    public void ApplyStrategies(List<InitializationStrategy> initializationStrategies)
    {
        foreach (var item in Tiles)
        {
            initializationStrategies.ForEach(x => x.DoChange(item));
        }
    }


    public void ApplyStrategy(InitializationStrategy initializationStrategy)
    {
        foreach (var item in Tiles)
        {
            initializationStrategy.DoChange(item);
        }
    }

    public void DestroyInstantiatedTiles() => ApplyStrategy(DestroyStrategy);
    public void InstantiateTiles(Transform parent) => ApplyStrategy(new InstantiateTilesStrategy(parent));

    IEnumerator IEnumerable.GetEnumerator() => Tiles.GetEnumerator();

    public IEnumerator<GeneratorMapTile> GetEnumerator() => Tiles.GetEnumerator();
}

public class GeneratorMapTile
{
    public Vector3Int Position;

    public TileValue Original;

    public GameObject PrefabInstance;
}

public class TileValue
{
    public string Name;
    public GameObject Prefab;
}