using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupScript : MonoBehaviour
{

    public GameObject Item;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        var inventoryManager = other.gameObject.GetComponentInChildren<IInventoryManager>();

        if (inventoryManager == null) return;

        inventoryManager.HandleItemPickup(Item);

        //var it = Instantiate(Item);

        //it.transform.SetParent(itemHolder.transform);

        //it.transform.localPosition = Vector3.zero;

        //it.transform.localEulerAngles = Vector3.zero;

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);

        var inventoryManager = collision.gameObject.GetComponentInChildren<IInventoryManager>();

        if (inventoryManager == null) return;

        inventoryManager.HandleItemPickup(Item);

        //var it = Instantiate(Item);

        //it.transform.SetParent(itemHolder.transform);

        //it.transform.localPosition = Vector3.zero;

        //it.transform.localEulerAngles = Vector3.zero;

        Destroy(gameObject);
    }
}
