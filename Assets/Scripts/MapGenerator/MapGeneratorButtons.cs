using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorButtons : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MapGenerator generator = (MapGenerator)target;
        if (GUILayout.Button("Generate Tiles"))
        {
            generator.Generate();
        }
        if (GUILayout.Button("Regenerate All Tiles"))
        {
            generator.GenerateWithClearingExistingTiles();
        }
        if (GUILayout.Button("Regenerate Missing Tiles"))
        {
            generator.RegenerateMissingTiles();
        }
    }
}
