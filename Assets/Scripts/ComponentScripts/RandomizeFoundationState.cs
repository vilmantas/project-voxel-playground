using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class RandomizeFoundationState : MonoBehaviour, IRandomizableState
{
    public bool WasRandomizedO;

    public bool WasRandomized { get => WasRandomizedO; set => WasRandomizedO = value; }
}
