using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class RandomizeGrass : MonoBehaviour
{
    public bool Regenerate;

    public bool PreserveMap;

    [Range(1, 15)]
    public int Width = 4;
    [Range(1, 15)]
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

    public void Generate()
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

        var tileDim = Tiles.First().Tile.GetComponentInChildren<Renderer>().bounds.size.x;

        (int from, int to, int index)[] weightIndexes = new (int, int, int)[Tiles.Length];

        int total = 0;

        for (int i = 0; i < Tiles.Length; i++)
        {
            weightIndexes[i] = (total, total + Tiles[i].Weight, i);
            total += Tiles[i].Weight;
        }

        Map = new GameObject[Length][];

        for (int i = 0; i < Length; i++)
        {
            Map[i] = new GameObject[Width];
        }

        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                int rand = UnityEngine.Random.Range(0, total);
                Map[i][j] = Tiles[weightIndexes.First(x => rand >= x.from && rand < x.to).index].Tile;
            }
        }

        Quaternion zeroQuaternion = new Quaternion();

        Renderer renderer = null;

        GameObject parent = GetComponentInChildren<OriginComponent>().gameObject;

        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                Map[i][j] = Instantiate(Map[i][j], new Vector3(transform.position.x + j * tileDim, transform.position.y, transform.position.z + i * tileDim), zeroQuaternion, parent.transform);

                Map[i][j].name = $"{i}.{j}";

                renderer = Map[i][j].GetComponentInChildren<Renderer>();

                Map[i][j].transform.RotateAround(renderer.bounds.center, Vector3.up, UnityEngine.Random.Range(0, 3) * 90);
            }
        }
    }

    public void GenerateNew()
    {
        (int from, int to, int index)[] weightIndexes = new (int, int, int)[Tiles.Length];

        int total = 0;

        for (int i = 0; i < Tiles.Length; i++)
        {
            weightIndexes[i] = (total, total + Tiles[i].Weight, i);
            total += Tiles[i].Weight;
        }

        var NewMap = new GameObject[Length][];

        for (int i = 0; i < Length; i++)
        {
            NewMap[i] = new GameObject[Width];
        }

        if (Map != null)
        {
            for (int i = 0; i < Math.Min(Length, Map.Length); i++)
            {
                for (int j = 0; j < Math.Min(Width, Map[i].Length); j++)
                {
                    NewMap[i][j] = Map[i][j];
                }
            }

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

        Quaternion zeroQuaternion = new Quaternion();

        Renderer renderer = null;

        GameObject parent = GetComponentInChildren<OriginComponent>().gameObject;

        var tileDim = Tiles.First().Tile.GetComponentInChildren<Renderer>().bounds.size.x;

        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (NewMap[i][j] == null)
                {
                    int rand = UnityEngine.Random.Range(0, total);
                    NewMap[i][j] = Tiles[weightIndexes.First(x => rand >= x.from && rand < x.to).index].Tile;

                    NewMap[i][j] = Instantiate(NewMap[i][j], new Vector3(transform.position.x + j * tileDim, transform.position.y, transform.position.z + i * tileDim), zeroQuaternion, parent.transform);

                    renderer = NewMap[i][j].GetComponentInChildren<Renderer>();

                    NewMap[i][j].transform.RotateAround(renderer.bounds.center, Vector3.up, UnityEngine.Random.Range(0, 3) * 90);
                }
            }
        }

        Map = NewMap;
    }

    void RegenerateTiles()
    {
        (int from, int to, int index)[] weightIndexes = new (int, int, int)[Tiles.Length];

        int total = 0;

        for (int i = 0; i < Tiles.Length; i++)
        {
            weightIndexes[i] = (total, total + Tiles[i].Weight, i);
            total += Tiles[i].Weight;
        }

        Quaternion zeroQuaternion = new Quaternion();

        Renderer renderer = null;

        GameObject parent = GetComponentInChildren<OriginComponent>().gameObject;

        var tileDim = Tiles.First().Tile.GetComponentInChildren<Renderer>().bounds.size.x;

        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (Map[i][j] == null)
                {
                    int rand = UnityEngine.Random.Range(0, total);
                    Map[i][j] = Tiles[weightIndexes.First(x => rand >= x.from && rand < x.to).index].Tile;

                    Map[i][j] = Instantiate(Map[i][j], new Vector3(transform.position.x + j * tileDim, transform.position.y, transform.position.z + i * tileDim), zeroQuaternion, parent.transform);

                    renderer = Map[i][j].GetComponentInChildren<Renderer>();

                    Map[i][j].transform.RotateAround(renderer.bounds.center, Vector3.up, UnityEngine.Random.Range(0, 3) * 90);
                }
            }
        }

        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (Map[i][j] == null)
                {
                    int rand = UnityEngine.Random.Range(0, total);
                    Map[i][j] = Tiles[weightIndexes.First(x => rand >= x.from && rand < x.to).index].Tile;

                    Map[i][j] = Instantiate(Map[i][j], new Vector3(transform.position.x + j * tileDim, transform.position.y, transform.position.z + i * tileDim), zeroQuaternion, parent.transform);

                    renderer = Map[i][j].GetComponentInChildren<Renderer>();

                    Map[i][j].transform.RotateAround(renderer.bounds.center, Vector3.up, UnityEngine.Random.Range(0, 3) * 90);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Map == null || Length != Map.Length || Width != Map[0].Length)
        {
            if (PreserveMap)
            {
                GenerateNew();
            } else
            {
                Generate();
            }
        }

        if (Regenerate)
        {
            Regenerate = false;

            RegenerateTiles();
        }
    }
}
