using UnityEngine;
using System.IO;
using UnityEditor;

namespace baboOn
{

    [DefaultExecutionOrder(0)]
    [AddComponentMenu("baboOn/Save")]
    [DisallowMultipleComponent]
    //[HelpURL("")]
    public class Save : MonoBehaviour
    {
        [SerializeField] [HideInInspector] public string nameJson = "data";

        [SerializeField] bool confirmLog = false;
        string color = "white";

        static SaveScript data = new SaveScript();
        static Save instance;

        public static SaveScript Data { get => data; }

        //Convierte el script en Singleton
        void Instance()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
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
                return;
            }
            //No se ha encontrado un archivo del cual cargar datos
            Debug.LogWarning("baboOn: 2.3.-El archivo no ha sido cargado");
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

            if (File.Exists(path)) {
                //No se ha podido crear un archivo, por lo que no se han guardado los datos
                Debug.LogError("baboOn: 2.2.-El archivo no se ha creado correctamente");
            }
        }
        //Elimina el archivo
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
                return;
            }
            //No se ha eliminado el archivo ya que no existe
            Debug.LogError("baboOn: 2.1.-No existe ningun archivo que se pueda eliminar");
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
        //Abre una nueva ventana con la GUI necesaria
        public void OpenWindow()
        {
           
            ChangeNameWindow.ShowWindow();
        }
    }

    //Ventana de Save
    public class ChangeNameWindow : EditorWindow
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
