using UnityEngine;
using TMPro;
using baboOn;

namespace baboon {
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("baboOn/Languages")]
    public class Languages : MonoBehaviour
    {
        //Almacena los idiomas, los Textos(TMPro), el num del idioma y la instancia
        [SerializeField] Language[] languages = new Language[0];
        [SerializeField] TextMeshProUGUI[] texts = new TextMeshProUGUI[0];
        [SerializeField] int miLang = 0;
        static Languages instance;

        public static Languages Data { get => instance; }
        //Instancia una referencia al script
        void Instance()
        {
            if (instance == null)
            {
                instance = this;
                return;
            }

            Debug.LogError("Existen varias instancias de languages");
        }

        void Awake()
        {
            Instance();
            Text();
        }
        //Escribe en los textos
        void Text() {
            texts.ForEach((e, i) =>
            {
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
