using Codice.CM.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.VersionControl.Asset;
using static UnityEngine.EventSystems.EventTrigger;

// Replace the usage of Selection.objects with the correct UnityEditor.Selection API
[CustomEditor(typeof(Spheres)), CanEditMultipleObjects]
public class SphereEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var size = serializedObject.FindProperty("size");

        serializedObject.ApplyModifiedProperties();

        if(size.floatValue > 2.0F )
        {
            EditorGUILayout.HelpBox("Size cannot be bigger than 2", MessageType.Warning);
        }
        else if(size.floatValue < 1.0f)
        {
            EditorGUILayout.HelpBox("Size cannot be smaller than 1", MessageType.Warning);
        }


            base.OnInspectorGUI();


        EditorGUILayout.BeginHorizontal();
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
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Clear selection"))
        {
            UnityEditor.Selection.objects = new UnityEngine.Object[0];
        }

        Color cachedColor = GUI.backgroundColor; // Cache the current background color
        GUI.backgroundColor = Color.green;       // Set the button background color 

        if (GUILayout.Button("Disable/Enable all enemy", GUILayout.Height(40)))
        {
            foreach (var enemy in GameObject.FindObjectsOfType < Spheres > (true))
            {
               enemy.gameObject.SetActive(!enemy.gameObject.activeSelf);
            }
        }

        GUI.backgroundColor = cachedColor; // Reset it to original after the button

    }
}