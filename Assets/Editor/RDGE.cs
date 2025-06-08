using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ADG), true)]
public class RDGE : Editor
{
    ADG generator;

    private void Awake()
    {
        generator = (ADG)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Create Dungeon"))
        {
            generator.GenerateDungeon();
        }
    }
}
