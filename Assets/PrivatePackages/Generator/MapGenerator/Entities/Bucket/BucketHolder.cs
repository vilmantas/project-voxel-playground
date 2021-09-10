using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BucketHolder : MonoBehaviour 
{
    public List<ItemBucket> Buckets = new List<ItemBucket>();
     
    public void SetList(IEnumerable<ItemBucket> itemBuckets)
    {
        Buckets = itemBuckets.ToList(); 
    }

    public void AddItem(ItemBucket item)
    {
        Buckets.Add(item);
        if (ItemAdded == null) return;

        ItemAdded(item);
    }

    public void RemoveAt(int index)
    {
        Buckets.RemoveAt(index);
        if (ItemRemoved == null) return;

        ItemRemoved(index);
    }

    public event ItemAddedHandler ItemAdded;

    public delegate void ItemAddedHandler(ItemBucket item);

    public event ItemRemovedHandler ItemRemoved;

    public delegate void ItemRemovedHandler(int index);
}
