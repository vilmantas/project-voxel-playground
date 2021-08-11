using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyInventoryManagerScript : MonoBehaviour, IInventoryManager
{
    public void HandleItemPickup(GameObject item)
    {
        Debug.Log("Item picked up!");
        var mainHand = GetComponentInChildren<MainHandComponent>();

        mainHand.transform.Rotate(Vector3.right, -90);

        var mainHandSlot = mainHand.GetComponentInChildren<MainHandEquipSpotComponent>();

        var itemInstance = Instantiate(item, mainHandSlot.transform);

        itemInstance.transform.localPosition = Vector3.zero;

        itemInstance.transform.localEulerAngles = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public interface IInventoryManager
{
    void HandleItemPickup(GameObject item);
}
