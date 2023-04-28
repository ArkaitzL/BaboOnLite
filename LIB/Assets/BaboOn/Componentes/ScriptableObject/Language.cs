using UnityEngine;

namespace BaboOn
{
    [CreateAssetMenu(fileName = "Language", menuName = "baboOn/New language", order = 1)]
    public class Language : ScriptableObject
    {
        //Almacena las palabras del idioma
        [SerializeField] public string[] dictionary = new string[0];
        //Copia el diccionario
        public void Copy()
        {
            GUIUtility.systemCopyBuffer = dictionary.inString();
            Debug.Log("Idioma copiado en el portapaeles");
        }
        //Crea un nuevo diccionario como el que le pasas
        public void Paste()
        {
            dictionary = GUIUtility.systemCopyBuffer.inArray<string>();
            Debug.Log("Idioma pegado");
        }
    }
}
