using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightDistributionComponent : MonoBehaviour
{
    public TilesWithWidthsAndWeights[] Tiles;

    [Serializable]
    public struct TilesWithWidthsAndWeights
    {
        public GameObject Tile;
        public int Weight;
        public int UnitCost;
    }


    public struct WeightDistribution
    {
        public int From;
        public int To;
        public int TileIndex;

        public WeightDistribution(int from, int to, int tileIndex)
        {
            From = from;
            To = to;
            TileIndex = tileIndex;
        }
    }

    public WeightDistribution[] GetWeightIndexes(out int totalWeight, out int sumOfUnits)
    {
        WeightDistribution[] result = new WeightDistribution[Tiles.Length];

        totalWeight = 0;

        sumOfUnits = 0;

        for (int i = 0; i < Tiles.Length; i++)
        {
            result[i] = new WeightDistribution(totalWeight, totalWeight + Tiles[i].Weight, i);
            totalWeight += Tiles[i].Weight;
            sumOfUnits += Tiles[i].UnitCost;
        }

        return result;
    }
}
