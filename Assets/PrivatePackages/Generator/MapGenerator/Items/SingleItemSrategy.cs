using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleItemSrategy : ItemPickingStrategy
{
    public GameObject Item;

    public override GameObject FindItemByName(string name) => Item;

    public override GameObject GetItem() => Item;
}
