using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BucketHolder))]
public class BucketHolderEditor : Editor
{
    BucketHolder g;

    public override void OnInspectorGUI()
    {
        g = (BucketHolder)target;

        var size = EditorGUILayout.IntSlider(g.Buckets.Count, 0, 10);

        HandleItemCount(g, size);

        foreach (var item in g.Buckets)
        {
            DrawBucket(item, 0); 
        }
    } 

    private void DrawBucket(ItemBucket item, int indent)
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

        if (item.Items == null) item.Items = new List<ItemBucket>();

        var size = EditorGUILayout.IntSlider(item.Items.Count, 0, 10);

        EditorGUILayout.EndHorizontal();

        DrawMainSettings(item);

        HandleItemCount(item, size);

        HandleDrawing(item, indent, size);
    }

    private void DrawMainSettings(ItemBucket item)
    {
        item.Name = EditorGUILayout.TextField("Name", item.Name);
        item.DrawAdditionalFields();
    }

    private void HandleDrawing(ItemBucket item, int indent, int size)
    {
        if (size == 0) 
        {
            DrawItem(item);
        }

        if (item.Items == null) return;

        foreach (var i in item.Items)
        {
            DrawBucket(i, indent + 1);
        }
    }

    private static void HandleItemCount(BucketHolder bucket, int size)
    {
        while (bucket.Buckets.Count < size)
        {
            bucket.AddItem(CreateInstance<ItemBucket>());
        }

        while (bucket.Buckets.Count > size)
        {
            bucket.RemoveAt(bucket.Buckets.Count - 1);
        }
    }

    private static void HandleItemCount(ItemBucket items, int size)
    {
        while (items.Items.Count < size)
        {
            items.AddItem(CreateInstance<ItemBucket>());
        }

        while (items.Items.Count > size)
        {
            items.RemoveAt(items.Items.Count - 1);
        }
    }

    private static string GenerateFoldoutText(ItemBucket item)
    {
        var foldoutText = item?.Items?.Count > 0 ? "Bucket" : "Item";
         
        foldoutText = item?.Item == null || item?.Items?.Count > 0 ? foldoutText : item?.Item?.name;
         
        foldoutText = string.IsNullOrEmpty(item?.Name) ? foldoutText : item?.Name;

        foldoutText += " " + (item?.Items?.Count > 0 ? $"({item?.Items?.Count})" : "");

        return foldoutText;
    }

    private void DrawItem(ItemBucket item)
    {
        item.Item = (GameObject)EditorGUILayout.ObjectField("Prefab", item.Item, typeof(GameObject), true);

        EditorGUILayout.Space();
    }
}
