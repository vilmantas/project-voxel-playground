using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHandComponent : Activatable
{
    public override void Activate()
    {
        var activatableItem = GetComponentInChildren<ActivatableItem>();
        activatableItem.Activate();
    }
}
