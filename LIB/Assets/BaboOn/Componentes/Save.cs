using UnityEngine;
using UnityEditor;
using System.IO;

namespace baboOn
{

    [DefaultExecutionOrder(0)]
    [AddComponentMenu("baboOn/Save")]
    public class Save : MonoBehaviour
    {
        [SerializeField] bool confirmLog = true;
        [SerializeField] [HideInInspector] internal string nameJson = "data";
        string color = "white";

        static SaveScript data = new SaveScript();
        static Save instance;

        public static SaveScript Data { get => data; }

        //Convierte el script en Singleton
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
        //Recoge los datos y lo guarda en data
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
        //Al acabar el uso de la aplicacion  guarda los datos en el archivo
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
        //Elimina el archivo
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
        //Abre una nueva ventana con la GUI necesaria
        [ContextMenu("Change Name")]
        void OpenWindow() {
            ChangeNameWindow.ShowWindow();
        }
        //Cambia el nombre al archivo
        public void ChangeName(string newName) {


            string oldPath = Application.persistentDataPath + $"/{nameJson}.json";
            string newPath = Application.persistentDataPath + $"/{newName}.json";


            if (File.Exists(oldPath)){
                File.Move(oldPath, newPath);
                nameJson = newName;

                if (confirmLog)
                {
                    Debug.LogFormat($"<color={color}> Nombre del archivo cambiado a \"{newName}\". </color>");
                }
            }


        }
    }
    //Crea el GUI de la ventana
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
