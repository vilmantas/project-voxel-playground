using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffhandComponent : Activatable
{
    public bool HasEquipedItem => EquipedItem != null;

    public GameObject EquipedItem;

    public override void Activate()
    {
        var activatableItem = GetComponentInChildren<ActivatableItem>();

        if (activatableItem == null) return;

        activatableItem.Activate();
    }

    public bool EquipItem(GameObject item)
    {
        transform.Rotate(Vector3.right, -90);

        var mainHandSlot = GetComponentInChildren<EquipSpotComponent>();

        EquipedItem = Instantiate(item, mainHandSlot.transform);

        EquipedItem.transform.localPosition = Vector3.zero;

        EquipedItem.transform.localEulerAngles = Vector3.zero;

        return true;
    }

    public override void Activate(ActivationContender triggerer)
    {
        throw new System.NotImplementedException();
    }
}
