using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable] 
public class ItemBucket : ScriptableObject
{ 
    public event ItemAddedHandler ItemAdded;

    public delegate void ItemAddedHandler(ItemBucket item);

    public event ItemRemovedHandler ItemRemoved;

    public delegate void ItemRemovedHandler(int index);

    public bool DrawOnEditor = false; 

    public string Name;
     
    public GameObject Item;

    [SerializeField]
    public List<ItemBucket> Items = new List<ItemBucket>();

    public void SetItems(IEnumerable<ItemBucket> items)
    {
        Items = items.ToList();
    }

    public virtual void AddItem(ItemBucket item)
    {
        Items.Add(item);
        if (ItemAdded == null) return;

        ItemAdded(item);
    }

    public virtual void RemoveAt(int index)
    {
        Items.RemoveAt(index);
        if (ItemRemoved == null) return;

        ItemRemoved(index);
    }

    public virtual void SetValues(ItemBucket baseBucket)
    {
        DrawOnEditor = baseBucket.DrawOnEditor;
        Name = baseBucket.Name;
        Item = baseBucket.Item;

        if (baseBucket.Items == null) return;

        SetItems(baseBucket.Items.Select(x =>
        {
            var instance = CreateInstance<ItemBucket>();
            instance.SetValues(x);
            return instance;
        }));
    }

    public virtual void DrawAdditionalFields()
    {
        return;
    }
}
