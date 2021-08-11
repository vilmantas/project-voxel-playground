using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public bool WallMode;

    public bool PreserveMap;

    public bool AlwaysGenerate;

    public bool Rotate90DegXAxis;

    public bool Rotate90DegZAxis;

    public bool Rotate90DegYAxis;

    [Range(1, 50)]
    [Header("X")]
    public int Width = 4;
    [Range(1, 50)]
    [Header("Z")]
    public int Length = 4;

    public TileWeights[] Tiles;

    [HideInInspector]
    public GameObject[][] Map;

    [Serializable]
    public struct TileWeights
    {
        public GameObject Tile;

        [Range(0, 100)]
        public int Weight;
    }

    private void ClearMap()
    {
        if (Map != null)
        {
            for (int i = 0; i < Map.Length; i++)
            {
                for (int j = 0; j < Map[i].Length; j++)
                { 
                    DestroyImmediate(Map[i][j]);  
                }
            }
        }
    }

    private (int from, int to, int index)[] GetWeightIndexes(out int total)
    {
        (int from, int to, int index)[] result = new (int, int, int)[Tiles.Length];

        total = 0;

        for (int i = 0; i < Tiles.Length; i++)
        {
            result[i] = (total, total + Tiles[i].Weight, i);
            total += Tiles[i].Weight;
        }

        return result;
    }

    private void GenerateTilesForMap(bool onlyNulls = false)
    {
        var weightIndexes = GetWeightIndexes(out int total);

        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (onlyNulls && Map[i][j] != null) continue;

                int rand = UnityEngine.Random.Range(0, total);
                Map[i][j] = Tiles[weightIndexes.First(x => rand >= x.from && rand < x.to).index].Tile;
            }
        }
    }

    private GameObject[][] GenerateEmptyMap()
    {
        var result = new GameObject[Length][];

        for (int i = 0; i < Length; i++)
        {
            result[i] = new GameObject[Width];
        }

        return result;
    }

    private void InstantiateTilesForMap(bool ignoreExisting = false)
    {
        Quaternion zeroQuaternion = new Quaternion();

        Renderer renderer;

        GameObject parent = GetComponentInChildren<OriginComponent>().gameObject;

        var offsetX = transform.position.x;

        var offsetZ = transform.position.z;

        var offsetY = transform.position.y;

        var tileDimX = 0f;

        var tileDimZ = 0f;

        var tileDimY = 0f;

        for (int i = 0; i < Length; i++)
        {
            offsetX = transform.position.x;

            Debug.Log(offsetX);

            for (int j = 0; j < Width; j++)
            {
                var tile = Map[i][j];

                if (ignoreExisting && tile.activeInHierarchy) continue;

                if (WallMode)
                {
                    Map[i][j] = Instantiate(tile, new Vector3(offsetX, offsetY, transform.position.z), zeroQuaternion, parent.transform);
                }
                else
                {
                    Map[i][j] = Instantiate(tile, new Vector3(offsetX, transform.position.y, offsetZ), zeroQuaternion, parent.transform);
                }

                renderer = Map[i][j].GetComponentInChildren<Renderer>();

                if (Rotate90DegXAxis)
                {
                    Map[i][j].transform.GetChild(0).RotateAround(renderer.bounds.center, Vector3.right, 90);
                }

                if (Rotate90DegYAxis)
                {
                    Map[i][j].transform.GetChild(0).RotateAround(renderer.bounds.center, Vector3.up, 90);
                }

                if (Rotate90DegZAxis)
                {
                    Map[i][j].transform.GetChild(0).RotateAround(renderer.bounds.center, Vector3.forward, 90);
                }

                Map[i][j].transform.GetChild(0).rotation = parent.transform.rotation;

                tileDimX = Map[i][j].GetComponentInChildren<Renderer>().bounds.size.x;

                tileDimZ = Map[i][j].GetComponentInChildren<Renderer>().bounds.size.z;

                tileDimY = Map[i][j].GetComponentInChildren<Renderer>().bounds.size.y;

                offsetX += tileDimX;
            }

            offsetY += tileDimY;

            offsetZ += tileDimZ;
        }
    }

    public void GenerateWithClearingExistingTiles()
    {
        ClearMap();

        Map = GenerateEmptyMap();

        GenerateTilesForMap();

        InstantiateTilesForMap();
    }

    public void GenerateWithAlreadyExistingTiles()
    {
        var NewMap = GenerateEmptyMap();

        if (Map != null)
        {
            // Copy stuff from old array to the new one
            for (int i = 0; i < Math.Min(Length, Map.Length); i++)
            {
                for (int j = 0; j < Math.Min(Width, Map[i].Length); j++)
                {
                    NewMap[i][j] = Map[i][j];
                }
            }

            // Destroy leftover rows
            if (NewMap.Length < Map.Length)
            {
                for (var i = NewMap.Length; i < Map.Length; i++)
                {
                    for (int j = 0; j < Map[i].Length; j++)
                    {
                        DestroyImmediate(Map[i][j]);
                    }
                }
            }


            // Destroy leftover colls
            if (NewMap[0].Length < Map[0].Length)
            {
                for (int i = 0; i < Map.Length; i++)
                {
                    for (int j = NewMap[0].Length; j < Map[0].Length; j++)
                    {
                        if (Map[i][j] != null)
                            DestroyImmediate(Map[i][j]);
                    }
                }
            }
        }

        Map = NewMap;

        GenerateTilesForMap(true);

        InstantiateTilesForMap(true);
    }

    public void RegenerateMissingTiles()
    {
        GenerateTilesForMap(true);

        InstantiateTilesForMap(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (AlwaysGenerate && (Map == null || Length != Map.Length || Width != Map[0].Length))
        {
            Generate();
        }
    }

    public void Generate()
    {
        if (PreserveMap)
        {
            GenerateWithAlreadyExistingTiles();
        }
        else
        { 
            GenerateWithClearingExistingTiles();
        } 
    }

    void OnEnable()
    {
        OriginComponent originComponent = GetComponentInChildren<OriginComponent>();

        if (originComponent.transform.childCount == 0) return;

        Transform[] children = new Transform[originComponent.transform.childCount]; 

        var index = 0;

        foreach (Transform item in originComponent.transform)
        {
            children[index] = item; 
            index++;
        }

        index = 0;

        Map = GenerateEmptyMap();

        for (int i = 0; i < Length; i++)
        {  
            for (int j = 0; j < Width; j++)
            {
                Map[i][j] = children[index].gameObject;
                index++;
            }
        }
    }
}
