using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using BaboOnLite;

[InitializeOnLoad]
public static class Hierarchy
{
    static Hierarchy() =>EditorApplication.hierarchyWindowItemOnGUI += ColorGUI;

    private static void ColorGUI(int instanceID, Rect selectionRect)
    {
        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        List<(string, Color)> colors = new List<(string, Color)>() { 
            ("!", Color.red),
            ("?", Color.blue),
            ("*", Color.yellow),
            ("-", Color.black),
            ("$", Color.cyan),
        };

        if (gameObject != null)
        {
            colors.ForEach(element =>
            {
                (string symbol, Color color) = element;

                if (gameObject.name.Contains(symbol))
                {
                    Rect colorRect = new Rect(selectionRect);
                    colorRect.x -= 28f;
                    colorRect.width = 5f;

                    EditorGUI.DrawRect(colorRect, color);
                }
            });
        }
    }
}