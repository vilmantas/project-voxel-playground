using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(WeightDistributionComponent))]
public class TileRandomizerComponent : MonoBehaviour
{
    [Range(1, 80)]
    public int Length = 5;

    [Range(1, 80)]
    public int Height = 5;

    [Range(1, 80)]
    public int Depth = 5;

    public int Target = 300;

    public bool UseTargetAndUnits;

    WeightDistributionComponent distributionComponent;

    private static int[][][] PrepareGrid(int depth, int height)
    {
        int[][][] result = new int[depth][][];

        for (int i = 0; i < depth; i++)
        {
            result[i] = new int[height][];
        }

        return result;
    }

    private static int[][][] Generate3dMatrix(int depth, int height, Func<int[]> Generator)
    {
        var result = PrepareGrid(depth, height);

        for (int i = 0; i < depth; i++)
        {
            for (int j = 0; j < height; j++)
            {
                result[i][j] = Generator();
            }
        }

        return result;
    }

    public int[][][] Generate()
    {
        if (UseTargetAndUnits)
        {
            return Generate3dMatrix(Depth, Height, GenerateWithTarget);
        } else
        {
            return Generate3dMatrix(Depth, Height, GenerateFixed);
        }
    }

    public int[] GenerateFixed()
    {
        var weightIndexes = distributionComponent.GetWeightIndexes(out int total, out int _);

        var result = new int[Length];

        for (int i = 0; i < Length; i++)
        {
            int rand = UnityEngine.Random.Range(0, total);
            result[i] = weightIndexes.First(x => rand >= x.From && rand < x.To).TileIndex;
        }

        return result;
    }

    public int[] GenerateWithTarget()
    {
        var firstPart = GenerateUntilThreshold(out int leftovers);

        var secondPart = GenerateCombinationByTarget(leftovers);

        return Shuffle(secondPart.Concat(firstPart).ToArray());
    }

    private int[] GenerateCombinationByTarget(int target)
    {
        var combinations = FindAllCombos(target);
        return combinations[UnityEngine.Random.Range(0, combinations.Count())].ToArray();
    }

    private int[] GenerateUntilThreshold(out int leftovers)
    {
        var weightIndexes = distributionComponent.GetWeightIndexes(out int totalWeight, out int threshold);

        List<int> result = new List<int>();

        var target = Target;

        while (target > threshold)
        {
            int rand = UnityEngine.Random.Range(0, totalWeight);

            var index = weightIndexes.First(x => rand >= x.From && rand < x.To).TileIndex;

            result.Add(index);
            target -= distributionComponent.Tiles[index].UnitCost;
        }

        leftovers = target;

        return result.ToArray();
    }

    public List<List<int>> FindAllCombos(int target)
    {
        if (target < 0)
        {
            return new List<List<int>>();
        }

        if (target == 0)
        {
            return new List<List<int>> { new List<int>() };
        }

        var result = new List<List<int>>();

        for (int i = 0; i < distributionComponent.Tiles.Length; i++)
        {
            var tile = distributionComponent.Tiles[i];

            var lastUsedCoint = tile.UnitCost;
            var combos = FindAllCombos(target - lastUsedCoint);
            foreach (var combo in combos)
            {
                combo.Add(i);
                result.Add(combo);
            }
        }

        return result;
    }

    private void Start()
    {
        distributionComponent = GetComponent<WeightDistributionComponent>();
    }

    public static void LeftShiftArray<T>(T[] arr, int shift)
    {
        shift = shift % arr.Length;
        T[] buffer = new T[shift];
        Array.Copy(arr, buffer, shift);
        Array.Copy(arr, shift, arr, 0, arr.Length - shift);
        Array.Copy(buffer, 0, arr, arr.Length - shift, shift);
    }

    private static int[] Shuffle(int[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = UnityEngine.Random.Range(1, n);
            int t = array[r];
            array[r] = array[n];
            array[n] = t;
        }

        return array;
    }
}
