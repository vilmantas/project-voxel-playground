using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[Serializable]
public class WeightItemSelectionStrategy : ItemPickingStrategy
{
    [SerializeField]
    public BucketHolder ItemBag;

    [NonSerialized]
    private bool IsSubscribed = false;

    [HideInInspector]
    public List<WeightItemBucket> CopiedItems = new List<WeightItemBucket>();

    private void OnValidate()
    {
        if (!IsSubscribed && ItemBag != null) 
        {
            Subscribe(ItemBag);
        }
    }

    public void SetList(IEnumerable<WeightItemBucket> itemBuckets) 
    {
        CopiedItems = itemBuckets.ToList();
    } 

    public void SetItems()
    {
        SetList(ItemBag.Buckets.Select(x =>
        {
            var instance = ScriptableObject.CreateInstance<WeightItemBucket>();
            instance.SetValues(x); 
            return instance;
        }));
    }

    private void ItemBag_ItemAdded(ItemBucket item)
    {
        var instance = ScriptableObject.CreateInstance<WeightItemBucket>();
        instance.SetValues(item);
        CopiedItems.Add(instance);
    }

    private void ItemBag_ItemRemoved(int index)
    {
        CopiedItems.RemoveAt(index);
    }

    public void RemoveItems()
    {
        CopiedItems = new List<WeightItemBucket>(); 
    }

    public void Unsubscribe(BucketHolder bag)
    {
        IsSubscribed = false;
        bag.ItemRemoved -= ItemBag_ItemRemoved; 
        bag.ItemAdded -= ItemBag_ItemAdded;

        CopiedItems.ForEach(x => x.Unsubscribe());
    }
     
    public void Subscribe(BucketHolder bag)
    {
        IsSubscribed = true; 
        bag.ItemAdded += ItemBag_ItemAdded;
        bag.ItemRemoved += ItemBag_ItemRemoved;

        CopiedItems.ForEach(x => x.Subscribe());
    }

    private List<(int from, int to, int itemIndex)> GetRanges(List<WeightItemBucket> Items)
    {
        var result = new List<(int from, int to, int itemIndex)>();

        int totalWeight = 0;

        for (int i = 0; i < Items.Count; i++)
        {
            result.Add((totalWeight, totalWeight + Items[i].Weight, i));
            totalWeight += Items[i].Weight;
        }

        return result;

    }

    public override GameObject FindItemByName(string name) 
    {
        throw new NotImplementedException(); 
    }

    public override GameObject GetItem() => GetItem(CopiedItems);

    private GameObject GetItem(List<WeightItemBucket> items)
    {
        int rand = UnityEngine.Random.Range(0, items.Sum(x => x.Weight));

        var index = GetRanges(items).First(x => rand >= x.from && rand < x.to).itemIndex;

        return GetItem(items[index]);
    }

    private GameObject GetItem(WeightItemBucket item)
    {
        if (item.WeightItems != null && item.WeightItems.Count > 0) return GetItem(item.WeightItems);

        return item.Item;
    }
}

[CustomEditor(typeof(WeightItemSelectionStrategy))]
public class WeightItemSelectionStrategyEditorV2 : Editor
{
    public override void OnInspectorGUI() 
    {
        var t = ((WeightItemSelectionStrategy)target);

        var initialValue = serializedObject.FindProperty(nameof(WeightItemSelectionStrategy.ItemBag)).objectReferenceValue;
        base.OnInspectorGUI();
        var newValue = serializedObject.FindProperty(nameof(WeightItemSelectionStrategy.ItemBag)).objectReferenceValue;

        if (initialValue != newValue && newValue != null)
        {
            t.SetItems();
        }

        if (initialValue != null && newValue == null)
        {
            t.Unsubscribe((BucketHolder)initialValue);
            t.RemoveItems();
        }

        if (GUILayout.Button("Get random item"))
        {
            var item = ((WeightItemSelectionStrategy)target).GetItem();
            Debug.Log(item?.name);

        }

        foreach (var item in t.CopiedItems)
        {
            DrawBucket(item, 0);
        }
    }

    private void DrawBucket(WeightItemBucket item, int indent)
    {
        EditorGUI.indentLevel = indent;

        EditorGUILayout.BeginHorizontal();

        string foldoutText = GenerateFoldoutText(item);

        item.DrawOnEditor = EditorGUILayout.Foldout(item.DrawOnEditor, foldoutText, true);

        if (!item.DrawOnEditor)
        {
            EditorGUILayout.EndHorizontal();
            return;
        }

        if (item.WeightItems == null) item.WeightItems = new List<WeightItemBucket>();

        EditorGUILayout.EndHorizontal();

        DrawMainSettings(item);

        HandleDrawing(item, indent, item.WeightItems.Count);
    }

    private void DrawMainSettings(WeightItemBucket item)
    {
        item.DrawAdditionalFields();
    }

    private void HandleDrawing(WeightItemBucket item, int indent, int size)
    {
        if (size == 0)
        {
            DrawItem(item);
        }

        if (item.Items == null) return;

        foreach (var i in item.WeightItems)
        {
            DrawBucket(i, indent + 1);
        }
    }

    private static string GenerateFoldoutText(WeightItemBucket item)
    {
        var foldoutText = item?.WeightItems?.Count > 0 ? "Bucket" : "Item";

        foldoutText = item?.Base.Item == null || item?.WeightItems?.Count > 0 ? foldoutText : item?.Base.Item?.name;

        foldoutText = string.IsNullOrEmpty(item?.Base.Name) ? foldoutText : item?.Base.Name;

        foldoutText += " " + (item?.WeightItems?.Count > 0 ? $"({item?.WeightItems?.Count})" : "");

        return foldoutText;
    }

    private void DrawItem(ItemBucket item)
    {
    }
}