using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BaboOnLite
{
    public class Console : MonoBehaviour
    {
        // Se suscribe al evento de la consola
        private void OnEnable() => Application.logMessageReceived += LogMessage;
        private void OnDisable() => Application.logMessageReceived -= LogMessage;

        //Referencia los TMPro
        TextMeshProUGUI consoleText, pageText, countText;
        int l, w, e;

        void Awake()
        {
            consoleText = GameObject.Find("Message").GetComponent<TextMeshProUGUI>();

            pageText = GameObject.Find("Page").GetComponent<TextMeshProUGUI>();
            countText = GameObject.Find("Count").GetComponent<TextMeshProUGUI>();
        }

        private void LogMessage(string message, string stackTrace, LogType type)
        {
            //Imprime el mensaje con su color
            Dictionary<string, string> colors = new Dictionary<string, string>() {
                { "Log", "FFFFFF" },
                { "Warning", "FFA500" },
                { "Error", "FF0000" }
            };
            consoleText.text += $"<color=#{colors[type.ToString()]}>[{DateTime.Now.ToString("HH: mm: ss")}]</color>\t {message} \n";

            //Cambiar la cantidad de errores
            switch (type.ToString())
            {
                case "Log":
                    l++;
                    break;
                case "Warning":
                    w++;
                    break;
                case "Error":
                    e++;
                    break;
                default:
                    break;
            }
            countText.text = $"<color=#FFFFFF>Log: {l}</color>     <color=#FFA500>Warning: {w}</color>     <color=#FF0000>Error: {e}</color>";

            //Cambia la cantidad de paginas
            consoleText.ForceMeshUpdate();
            pageText.text = $"{consoleText.pageToDisplay}/{consoleText.textInfo.pageCount}";
        }
        public void ChangePage(int pageIndex)
        {
            //Cambia de pagina
            int page = consoleText.pageToDisplay + pageIndex;
            if (page > 0 && page <= consoleText.textInfo.pageCount) { 
                pageText.text = $"{page}/{consoleText.textInfo.pageCount}";
                consoleText.pageToDisplay = page;
            }
        }
        public void Clear() {
            l = 0; w = 0; e = 0;

            consoleText.text = "";
            pageText.text = $"0/0";
            countText.text = $"<color=#FFFFFF>Log: 0</color>     <color=#FFA500>Warning: 0</color>     <color=#FF0000>Error: 0</color>";
        }


        void Start()
        {
            Debug.Log("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :) PRIMERO");
            Debug.LogError("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.LogWarning("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.Log("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.LogError("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.LogWarning("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.Log("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.LogError("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.LogWarning("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.Log("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.LogError("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.LogWarning("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.Log("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.LogError("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.LogWarning("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.Log("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
            Debug.LogWarning("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :) ULTIMO");
        }
    }
}
