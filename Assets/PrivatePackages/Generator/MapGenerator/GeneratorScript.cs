using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

[ExecuteAlways]
public class GeneratorScript : MonoBehaviour
{
    public Vector3Int Size;

    public Transform InstantiationOrigin;

    [SerializeField]
    public ItemPickingStrategy Strategy;

    [SerializeField]
    public List<PostInitializationStrategy> PostInitializationStrategies = new List<PostInitializationStrategy>();

    [SerializeField]
    public List<PreInitializationStrategy> PreInitializationStrategies = new List<PreInitializationStrategy>();

    [SerializeField]
    public GeneratorMap Map;

    public void DoRun()
    {
        Map?.DestroyInstantiatedTiles();  

        Map = MapBuilder.BuildMapWithPrefabs(Size, Strategy);

        Map.ApplyStrategies(PreInitializationStrategies.Cast<InitializationStrategy>().ToList());

        Map.InstantiateTiles(transform);

        Map.ApplyStrategies(PostInitializationStrategies.Cast<InitializationStrategy>().ToList());
    }

    private void OnEnable()
    {
        if (Strategy == null) return; 

        GeneratorMapTile tile;

        List<GeneratorMapTile> tiles = new List<GeneratorMapTile>();

        foreach (Transform item in transform)
        {
            Regex r = new Regex(@"(\d\.\d\.\d) \((\w+)\)");

            var result = r.Match(item.name);

            if (!result.Success) continue;

            var position = result.Groups[1].Value;

            var prefabName = result.Groups[2].Value;

            var tokens = position.Split('.');

            if (tokens.Length != 3) return;

            int z = int.Parse(tokens[0]);
            int y = int.Parse(tokens[1]);  
            int x = int.Parse(tokens[2]);

            tile = MapTileBuilder.BuildWithPositionAndInstance(x, y, z, item.gameObject, prefabName);

            tiles.Add(tile);
        }

        Map = MapBuilder.BuildFromExisting(tiles, Strategy, Size); 
    }
}
