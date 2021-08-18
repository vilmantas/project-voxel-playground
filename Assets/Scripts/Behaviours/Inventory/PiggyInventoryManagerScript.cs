using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyInventoryManagerScript : MonoBehaviour, IInventoryManager
{
    public bool TryPickupItem(GameObject item)
    {
        return TryEquipMainHand(item) || TryEquipOffHand(item);
    }

    public bool TryEquipMainHand(GameObject item)
    {
        var mainHand = GetComponentInChildren<MainHandComponent>();

        if (mainHand.HasEquipedItem) return false;

        return mainHand.EquipItem(item);
    }

    public bool TryEquipOffHand(GameObject item)
    {
        var offHand = GetComponentInChildren<OffhandComponent>();

        if (offHand.HasEquipedItem) return false;

        return offHand.EquipItem(item);
    }
}

public interface IInventoryManager
{
    bool TryPickupItem(GameObject item);
}
