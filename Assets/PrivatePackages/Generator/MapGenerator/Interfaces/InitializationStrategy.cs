using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InitializationStrategy : MonoBehaviour
{
    public abstract void DoChange(GeneratorMapTile tile);
}
