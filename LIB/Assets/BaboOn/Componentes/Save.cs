using UnityEngine;
using UnityEditor;
using System.IO;

namespace onFunc {

    [DefaultExecutionOrder(0)]
    [AddComponentMenu("OnFunc/Save")]
    public class Save : MonoBehaviour
    {
        [SerializeField] bool confirmLog = true;
        internal string nameJson = "data";
        string color = "white";

        static SaveScript data = new SaveScript();
        static Save instance;

        public static SaveScript Data { get => data; }

        private void Instance()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Awake()
        {

            Instance();

            string path = Application.persistentDataPath + $"/{nameJson}.json";

            if (File.Exists(path))
            {
                data = JsonUtility.FromJson<SaveScript>(
                    File.ReadAllText(path)
                );
                if (confirmLog)
                {
                    Debug.LogFormat($"<color={color}> Datos cargados correctamente. </color>");
                }
            }            
        }

        private void OnApplicationQuit()
        {
            string Json = JsonUtility.ToJson(data);
            string path = Application.persistentDataPath + $"/{nameJson}.json";

            File.WriteAllText(path, Json);

            if (confirmLog)
            {
                Debug.LogFormat($"<color={color}> El archivo se a creado en:\n {path} </color>");
            }
        }

        [ContextMenu("Remove Data")]
        public void Remove()
        {
            string path = Application.persistentDataPath + $"/{nameJson}.json";

            if (File.Exists(path))
            {
                File.Delete(path);
                if (confirmLog)
                {
                    Debug.LogFormat($"<color={color}> Archivo eliminado correctamente. </color>");
                }
            }
        }

        [ContextMenu("Change Name")]
        void OpenWindow() {
            ChangeNameWindow.ShowWindow();
        }

        public void ChangeName(string newName) {


            string oldPath = Application.persistentDataPath + $"/{nameJson}.json";
            string newPath = Application.persistentDataPath + $"/{newName}.json";

            nameJson = newName;

            if (File.Exists(oldPath)){ 
                File.Move(oldPath, newPath);
            }

            if (confirmLog) {
                Debug.LogFormat($"<color={color}> Nombre del archivo cambiado correctamente. </color>");
            }
        }
    }

    internal class ChangeNameWindow : EditorWindow
    {
        string newName;

        internal static void ShowWindow()
        {
            GetWindow<ChangeNameWindow>("Change Name");
        }

        private void OnGUI()
        {
            Save save = FindObjectOfType<Save>();

            EditorGUILayout.LabelField($"Cambiar \"{save.nameJson}\" como nombre del archivo:");
            newName = EditorGUILayout.TextField("Enter new name:", newName);

            if (GUILayout.Button("Change"))
            {
                if (save != null)
                {
                    save.ChangeName(newName);
                }
                Close();
            }
        }
    }
}
