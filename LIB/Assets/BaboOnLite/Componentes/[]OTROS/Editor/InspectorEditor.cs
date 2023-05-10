using UnityEditor;
using UnityEngine;

namespace BaboOn
{
    //Editor de save
    [CustomEditor(typeof(Save))]
    public class SaveEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Save ins = (Save)target;

            GUILayout.Space(10);

            if (GUILayout.Button("Remove Data"))
            {
                ins.Remove();
            }

            if (GUILayout.Button("Change Name"))
            {
                ins.OpenWindow();
            }
        }
    }
    //Editor de language
    [CustomEditor(typeof(Language))]
    public class LanguageEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Language lang = (Language)target;

            GUILayout.Space(10);

            if (GUILayout.Button("Copy"))
            {
                lang.Copy();
            }

            if (GUILayout.Button("Paste"))
            {
                lang.Paste();
            }

            if (GUILayout.Button("Paste as new"))
            {
                lang.PasteAsNew();
            }
        }
    }
    //Editor de PathMaker
    [CustomEditor(typeof(PathMaker))]
    public class PathMakerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            PathMaker pathMaker = (PathMaker)target;

            GUILayout.Space(10);

            if (GUILayout.Button("Add position"))
            {
                pathMaker.Add();
            }

            if (GUILayout.Button("Save path"))
            {
                pathMaker.Save();
            }
        }
    }
}