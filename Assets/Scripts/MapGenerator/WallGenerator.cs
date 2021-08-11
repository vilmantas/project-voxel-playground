using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(WeightDistributionComponent))]
[RequireComponent(typeof(TileRandomizerComponent))]
public class WallGenerator : MonoBehaviour
{
    public bool Rotate90DegXAxis;

    public bool Rotate90DegZAxis;

    public bool Rotate90DegYAxis;

    WeightDistributionComponent distributionComponent;

    TileRandomizerComponent tileRandomizer;

    int[][][] Map;

    GameObject[][][] InitializedMap;


    // Start is called before the first frame update
    void Start()
    {
        distributionComponent = GetComponent<WeightDistributionComponent>();
        tileRandomizer = GetComponent<TileRandomizerComponent>();
    }

    public void DoRedrawMap()
    {
        TileInitializerComponent.ClearMap(InitializedMap);

        TileInitializerComponent.InstantiateTilesForMap(Map, GetComponentInChildren<OriginComponent>(), transform, true, distributionComponent.Tiles, out InitializedMap, (false, Rotate90DegXAxis, Rotate90DegYAxis, Rotate90DegZAxis));
    }

    public void DoRun()
    {
        if (InitializedMap != null)
        { 
            TileInitializerComponent.ClearMap(InitializedMap);
            InitializedMap = null;
        }

        Map = tileRandomizer.Generate();

        TileInitializerComponent.InstantiateTilesForMap(Map, GetComponentInChildren<OriginComponent>(), transform, true, distributionComponent.Tiles, out InitializedMap, (false, Rotate90DegXAxis, Rotate90DegYAxis, Rotate90DegZAxis));
    }

    void OnEnable()
    {
        OriginComponent originComponent = GetComponentInChildren<OriginComponent>();

        if (originComponent.transform.childCount == 0) return;

        var maxZ = -1;

        var maxY = -1;

        var maxX = -1;

        foreach (Transform item in originComponent.transform)
        {
            var tokens = item.name.Split('.');

            if (tokens.Length != 3) return;
             
            int z = int.Parse(tokens[0]);
            int y = int.Parse(tokens[1]);
            int x = int.Parse(tokens[2]);

            if (z > maxZ) maxZ = z;
            if (y > maxY) maxY = y;
            if (x > maxX) maxX = x;
        }

        maxX++;
        maxY++;
        maxZ++;

        InitializedMap = new GameObject[maxZ][][];

        for (int i = 0; i < maxZ; i++)
        {
            InitializedMap[i] = new GameObject[maxY][];

            for (int j = 0; j < maxY; j++)
            {
                InitializedMap[i][j] = new GameObject[maxX];
            }
        }

        foreach (Transform item in originComponent.transform)
        {
            var tokens = item.name.Split('.');
             
            int z = int.Parse(tokens[0]);
            int y = int.Parse(tokens[1]); 
            int x = int.Parse(tokens[2]);

            InitializedMap[z][y][x] = item.gameObject; 
        }
    }
}

[CustomEditor(typeof(WallGenerator))]
public class WallGeneratorButtons : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WallGenerator generator = (WallGenerator)target;
        if (GUILayout.Button("Generate Tiles"))
        {
            generator.DoRun();
        }
        if (GUILayout.Button("Redraw (debug)"))
        {
            generator.DoRedrawMap();
        }
    }
}