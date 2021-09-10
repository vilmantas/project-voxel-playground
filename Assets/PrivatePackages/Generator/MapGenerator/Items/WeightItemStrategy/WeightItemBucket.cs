using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[Serializable]
public class WeightItemBucket : ItemBucket
{
    public int Weight;

    public ItemBucket Base;

    public new GameObject Item => Base.Item;

    public List<WeightItemBucket> WeightItems = new List<WeightItemBucket>();

    public override void SetValues(ItemBucket baseBucket)
    {
        Base = baseBucket;
        Weight = 1;

        Subscribe();

        WeightItems = baseBucket.Items.Select(x =>
        {
            var instance = CreateInstance<WeightItemBucket>();
            instance.SetValues(x);
            return instance;
        }).ToList();
    }

    public void Subscribe()
    {
        Base.ItemAdded += BaseBucket_ItemAdded;
        Base.ItemRemoved += BaseBucket_ItemRemoved;

        WeightItems.ForEach(x => x.Subscribe());
    }

    public void Unsubscribe()
    {
        Base.ItemAdded -= BaseBucket_ItemAdded;
        Base.ItemRemoved -= BaseBucket_ItemRemoved;

        WeightItems.ForEach(x => x.Unsubscribe());
    }

    private void BaseBucket_ItemAdded(ItemBucket item)
    {
        var instance = CreateInstance<WeightItemBucket>();
        instance.SetValues(item);
        WeightItems.Add(instance);
    }

    private void BaseBucket_ItemRemoved(int index)
    {
        WeightItems.RemoveAt(index);
    }

    public override void DrawAdditionalFields()
    {
        Weight = EditorGUILayout.IntSlider("Weight", Weight, 1, 100);
        base.DrawAdditionalFields();
    }
}

