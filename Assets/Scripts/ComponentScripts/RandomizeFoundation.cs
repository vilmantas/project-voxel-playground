using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomizeFoundationState))]
public class RandomizeFoundation : Randomizable
{
    public override void DoRandomize()
    {
        Debug.Log("Foundation randomize");

        var rot = Random.Range(0, 3);

        var transform = GetComponent<Transform>();

        transform.Rotate(Vector3.up, rot * 90);
    }

    public override void DoInitialization()
    {
        State = GetComponent<RandomizeFoundationState>();
    }

    public override bool DoStateValidCheck()
    {
        return !State.WasRandomized;
    }

    public override bool DoInitializationCheck()
    {
        return State != null;
    }
}
