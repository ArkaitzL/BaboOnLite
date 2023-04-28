using UnityEngine;
using TMPro;
using baboOn;

namespace baboon 
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("baboOn/Languages")]
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

        public static Languages Data { get => instance; }
        //Valida la longitud de miLang
        private void OnValidate()
        {
            int length = texts.Length-1;

            if (miLang >= length) {
                miLang = texts.Length-1;
            }
            if (miLang <= 0) {
                miLang = 0;
            }
        }
        //Instancia una referencia al script
        void Instance()
        {
            if (instance == null)
            {
                instance = this;
                return;
            }

            Debug.LogError($"baboOn: 3.1-Existen varias instancias de languages, se ha destruido la instancia de \"{gameObject.name}\"");
            Destroy(this);
        }

        void Awake()
        {
            Instance();
            Validate();
            Text();
        }
        //Valida que no tenga errores
        void Validate() {
            int length = texts.Length;

            languages.ForEach(e => {
                if (e.dictionary.Length != length) {
                    Debug.LogError($"baboOn: 3.2-La longitud del diccionario de {e.name}, no coincide con la cantidad de textos");
                }
            });
        }
        //Escribe en los textos
        void Text() {
            texts.ForEach((e, i) =>
            {
                if (e == null) {
                    Debug.LogError($"baboOn: 3.3- No puedes dejar un campo texto sin asignar");
                    return;
                }
                e.text = languages[miLang].dictionary[i];
            });
        }
        //Cambia el idioma
        public void Alternate()
        {
            miLang = (miLang < (languages.Length-1))
                ? ++miLang
                : 0;
            Text();
        }
        //Cambia el idioma
        public void Change(int i)
        {
            miLang = i;
            Text();
        }

    }
}
