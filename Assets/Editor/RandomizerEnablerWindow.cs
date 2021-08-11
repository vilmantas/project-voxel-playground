using System.Linq;
using UnityEditor;
using UnityEngine;

public class RandomizerEnablerWindow : EditorWindow
{
    [MenuItem("Window/OPEN THIS WINDOW IF YOU WANT TO HAVE RANDOMIZER WORKING")]
    static void CreateWindow()
    {
        EditorWindow.GetWindow<RandomizerEnablerWindow>();
    }

    void OnHierarchyChange()
    {
        if (EditorApplication.isPlaying) return;

        var addedObjects = Resources.FindObjectsOfTypeAll<Randomizable>()
                                    .Where(x => x.IsAdded < 2);

        foreach (var item in addedObjects)
        {
            Debug.Log("PASS " + item.IsAdded);
            if (item.IsAdded == 1)
            {
                item.Randomize();
            }
            item.IsAdded++;
        }
    }
}
