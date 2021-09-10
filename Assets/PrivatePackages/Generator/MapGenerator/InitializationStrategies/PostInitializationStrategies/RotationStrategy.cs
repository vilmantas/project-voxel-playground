using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationStrategy : PostInitializationStrategy
{
    public Vector3 Angles = new Vector3(0, 0, 0);

    public override void DoChange(GeneratorMapTile prefabInstance)
    {
        prefabInstance.PrefabInstance.transform.Rotate(Angles);
    }
}
