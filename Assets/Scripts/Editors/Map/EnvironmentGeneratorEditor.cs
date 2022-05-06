using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif


#if UNITY_EDITOR
[CustomEditor(typeof(EnvironmentGenerator))]
public class TreeGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EnvironmentGenerator treeGen = (EnvironmentGenerator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            treeGen.Generate();
        }
        if (GUILayout.Button("Clear"))
        {
            treeGen.Clear();
        }

    }

}
#endif
