using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupScript : MonoBehaviour
{
    public GameObject Item;

    private void OnTriggerEnter(Collider other)
    {
        var inventoryManager = other.gameObject.GetComponentInChildren<IInventoryManager>();

        if (inventoryManager == null) return;

        if (inventoryManager.TryPickupItem(Item))
            Destroy(gameObject);
    }
}
