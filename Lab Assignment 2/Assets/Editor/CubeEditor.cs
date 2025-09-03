using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

// Replace the usage of Selection.objects with the correct UnityEditor.Selection API
[CustomEditor(typeof(Cubes)), CanEditMultipleObjects]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Select all Cubes"))
        {
            var allShapes = GameObject.FindObjectsOfType<Cubes>();
            var allShapeGameObjects = allShapes
                .Select(enemy => enemy.gameObject)
                .ToArray();
            UnityEditor.Selection.objects = allShapeGameObjects; // Use UnityEditor.Selection
        }

        if (GUILayout.Button("Select all Spheres"))
        {
            var allShapes = GameObject.FindObjectsOfType<Spheres>();
            var allShapeGameObjects = allShapes
                .Select(enemy => enemy.gameObject)
                .ToArray();
            UnityEditor.Selection.objects = allShapeGameObjects; // Use UnityEditor.Selection
        }
    }
}
