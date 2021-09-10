using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemPickingStrategy : MonoBehaviour
{
    public abstract GameObject GetItem();

    public abstract GameObject FindItemByName(string name);
}
