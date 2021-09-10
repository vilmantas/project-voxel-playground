using UnityEngine;
using static GeneratorMap;

public interface IGenerationStrategy
{
    MapTiles GenerateMapTiles(Vector3Int size);
}