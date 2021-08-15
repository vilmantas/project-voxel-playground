using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WeightDistributionComponent;

public class TileInitializerComponent : MonoBehaviour
{
    public static GameObject[][][] GenerateEmptyMap(int[][][] map)
    {
        var result = new GameObject[map.Length][][];

        for (int i = 0; i < map.Length; i++)
        {
            result[i] = new GameObject[map[i].Length][];

            for (int j = 0; j < map[i].Length; j++)
            {
                result[i][j] = new GameObject[map[i][j].Length];
            }
        }

        return result;
    }

    public static void ClearMap(GameObject[][][] instantiatedMap)
    {
        if (instantiatedMap != null)
        {
            for (int i = 0; i < instantiatedMap.Length; i++)
            {
                for (int j = 0; j < instantiatedMap[i].Length; j++)
                {
                    for (int k = 0; k < instantiatedMap[i][j].Length; k++)
                    {
                        DestroyImmediate(instantiatedMap[i][j][k]);
                    }
                }
            }
        }
    }

    public static void InstantiateTilesForMap(int[][][] map, OriginComponent parent, Transform transform, bool WallMode, TilesWithWidthsAndWeights[] tiles, out GameObject[][][] instantiatedMap, (bool ignoreExisting, bool x, bool y, bool z) options)
    {
        Renderer renderer;

        instantiatedMap = GenerateEmptyMap(map);

        var offsetX = 0f;

        var offsetZ = 0f;

        var offsetY = 0f;

        var tileDimX = 0f;

        var tileDimZ = 0f;

        var tileDimY = 0f;
        
        for (int z = 0; z < map.Length; z++)
        {
            var current2dMatrix = map[z];

            offsetY = 0f;

            for (int i = 0; i < current2dMatrix.Length; i++)
            {
                offsetX = 0f;

                for (int j = 0; j < current2dMatrix[i].Length; j++)
                {
                    var tile = tiles[current2dMatrix[i][j]].Tile;

                    if (options.ignoreExisting && tile.activeInHierarchy) continue;

                    instantiatedMap[z][i][j] = Instantiate(tile, parent.transform);

                    renderer = instantiatedMap[z][i][j].GetComponentInChildren<Renderer>();

                    Func<Vector3, float> newX = (position) => position.x;
                    Func<Vector3, float> newY = (position) => position.y;
                    Func<Vector3, float> newZ = (position) => position.z;

                    if (options.x)
                    {
                        newY = (position) => position.z;
                        newZ = (position) => position.y;
                        instantiatedMap[z][i][j].transform.GetChild(0).RotateAround(renderer.bounds.center, Vector3.right, 90);
                    }

                    if (options.y)
                    {
                        newX = (position) => position.z;
                        newZ = (position) => position.x;
                        instantiatedMap[z][i][j].transform.GetChild(0).RotateAround(renderer.bounds.center, Vector3.up, 90);
                    }

                    if (options.z)
                    {
                        newX = (position) => position.y;
                        newY = (position) => position.x;
                        instantiatedMap[z][i][j].transform.GetChild(0).RotateAround(renderer.bounds.center, Vector3.forward, 90);
                    }

                    instantiatedMap[z][i][j].transform.localPosition = new Vector3(offsetX, offsetY, offsetZ);

                    instantiatedMap[z][i][j].name = $"{z}.{i}.{j}";

                    var origDims = tile.GetComponentInChildren<Renderer>().bounds.size;

                    tileDimX = origDims.x;

                    tileDimZ = origDims.z;

                    tileDimY = origDims.y;

                    // Assuming tile origin is centered, we're attempting to move from origin
                    var entryTransform = instantiatedMap[z][i][j].transform;

                    // Division by 2 is here because the models in use had their center set at X/Z axises (at the middle of the bottom)
                    entryTransform.localPosition = new Vector3(newX(entryTransform.localPosition) + newX(origDims)/ 2, newY(entryTransform.localPosition) + newY(origDims) / 2, newZ(entryTransform.localPosition) + newZ(origDims) / 2);

                    offsetX += tileDimX;
                }

                offsetY += tileDimY;
            }

            offsetZ += tileDimZ;
        }
    }
}
