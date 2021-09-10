using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceNamingStrategy : PostInitializationStrategy
{
    public override void DoChange(GeneratorMapTile instantiatedTile)
    {
        var position = instantiatedTile.Position;
        instantiatedTile.PrefabInstance.name = $"{position.z}.{position.y}.{position.x} ({instantiatedTile.Original.Name})";
    }
}
