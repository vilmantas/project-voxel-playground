using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GeneratorScript))]
public class GeneratorScriptButtons : Editor
{
    public override void OnInspectorGUI()
    {
        var g = (GeneratorScript)target;

        DrawDefaultInspector();

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Generate Tiles"))
        {
            g.DoRun();
        }

        EditorGUILayout.EndHorizontal();
    }
}
