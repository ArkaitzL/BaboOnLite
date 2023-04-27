using UnityEditor;
using UnityEngine;

namespace baboOn 
{
    [CreateAssetMenu(fileName = "Language", menuName = "baboOn/New language", order = 1)]
    public class Language : ScriptableObject
    {
        [SerializeField] public string[] texts = new string[0];

        public void Copy()
        {
            GUIUtility.systemCopyBuffer = texts.inString();
            Debug.Log("Idioma copiado en el portapaeles");
        }

        public void Paste()
        {
            texts = GUIUtility.systemCopyBuffer.inArray<string>();
            Debug.Log("Idioma pegado");
        }
    }

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
