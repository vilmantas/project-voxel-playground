using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHandComponent : Activatable
{
    public override void Activate()
    {
        var activatableItem = GetComponentInChildren<ActivatableItem>();

        if (activatableItem == null) return;

        activatableItem.Activate();
    }

    public override void Activate(ActivatableTriggerer triggerer)
    {
        throw new System.NotImplementedException();
    }
}
