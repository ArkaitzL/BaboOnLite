using UnityEditor;
using UnityEngine;

namespace baboOn {
    //Editor de save
    [CustomEditor(typeof(Save))]
    public class SaveEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Save ins = (Save)target;

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
    public class PlayerPrefabEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Language lang = (Language)target;

            if (GUILayout.Button("Copy"))
            {
                lang.Copy();
            }

            if (GUILayout.Button("Paste"))
            {
                lang.Paste();
            }
        }
    }
}