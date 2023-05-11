using UnityEngine;
using TMPro;

namespace BaboOnLite
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/Languages")]
    [DisallowMultipleComponent]
    //[HelpURL("")]

    public class Languages : MonoBehaviour
    {
        //Almacena los idiomas, los Textos(TMPro), el num del idioma y la instancia
        [SerializeField] Language[] languages = new Language[0];
        [SerializeField] TextMeshProUGUI[] texts = new TextMeshProUGUI[0];
        [Space]
        [SerializeField] int miLang = 0;

        static Languages instance;

        private void OnValidate()
        {
            //Valida la longitud de miLang
            int length = languages.Length - 1;

            if (miLang < 0)
            {
                miLang = 0;
                return;
            }
            if (miLang >= length)
            {
                miLang = languages.Length - 1;
                return;
            }
        }
        void Instance()
        {
            if (instance == null)
            {
                instance = this;
                return;
            }

            //No se puede poner dos scripts de este tipo en la misma escena
            Debug.LogError($"baboOn: 3.1.-Existen varias instancias de languages, se ha destruido la instancia de \"{gameObject.name}\"");
            Destroy(this);
        }
        void Awake()
        {
            Instance();
            Validate();
            Text();
        }
        //Valida que no tenga errores
        void Validate()
        {
            int length = texts.Length;

            languages.ForEach(e => {
                if (e == null)
                {
                    //No puedes dejar en null un elemento del array Language
                    Debug.LogError($"baboOn: 3.4- No puedes dejar un campo de Idioma sin asignar");
                }
                if (e.dictionary.Length != length)
                {
                    //La longitud de los diccionarios tienen que ser iguales al de los textos
                    Debug.LogError($"baboOn: 3.2-La longitud del diccionario de {e.name}, no coincide con la cantidad de textos");
                }
            });
        }
        //Cambia el idioma
        public void Alternate()
        {
            miLang = (miLang < (languages.Length - 1))
                ? ++miLang
                : 0;
            Text();
        }
        //Cambia el idioma
        public void Change(int i)
        {
            //Valida la longitud de miLang
            int length = languages.Length - 1;

            if (i >= length || i < 0)
            {
                //No hay elementos en esa posicion del array
                Debug.LogError($"baboOn: 3.5- No existe un elemento asignado, a la posicion {i} del array languages");
                return;
            }

            miLang = i;
            Text();
        }
        //Escribe en los textos
        void Text()
        {
            texts.ForEach((e, i) =>
            {
                if (e == null)
                {
                    //No puedes dejar en null un elemento del array Text
                    Debug.LogError($"baboOn: 3.3- No puedes dejar un campo de Texto sin asignar");
                    return;
                }
                e.text = languages[miLang].dictionary[i];
            });
        }
    }
}
