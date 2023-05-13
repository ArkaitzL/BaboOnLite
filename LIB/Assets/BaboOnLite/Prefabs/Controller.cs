using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using BaboOnLite;

public class Controller
{
    //Ruta de los prefabs
    static string path = "Assets/BaboOnLite/Prefabs/";

    //OBJETO 1
    [MenuItem("GameObject/BaboOnLite/Console")]
    private static void Instantiate(MenuCommand menuCommand)
    {
        //Nombre del prefab
        string name = "Console/Console.prefab";

        //Instancia el prefab
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path+name);
        GameObject instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        instance.name = prefab.name;

        //Busca el canvas y si no existe lo crea
        Canvas canvas = Object.FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasGO = new GameObject("Canvas");
            canvas = canvasGO.AddComponent<Canvas>();
            canvasGO.AddComponent<CanvasScaler>();
            canvasGO.AddComponent<GraphicRaycaster>();
        }
        //Lo añade dentro del Canvas
        instance.transform.SetParent(canvas.transform, false);

        //Otros
        Undo.RegisterCreatedObjectUndo(instance, "Instantiate Custom Prefab");
        Selection.activeGameObject = instance;
    }
}
