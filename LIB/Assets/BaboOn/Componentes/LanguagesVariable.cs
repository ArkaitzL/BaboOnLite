using UnityEngine;
using TMPro;

namespace BaboOn
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOn/Languages/LangVariable")]
    [DisallowMultipleComponent]
    //[HelpURL("")]

    public class LanguagesVariable : MonoBehaviour
    {
        //Almacena los idiomas, los Textos(TMPro), el num del idioma y la instancia
        [SerializeField] Language[] languages = new Language[0];
        [SerializeField] TextMeshProUGUI[] texts = new TextMeshProUGUI[0];
        int[] textAssign;

        [Space]

        [SerializeField] int miLang = 0;

        private void OnValidate()
        {
            //Valida la longitud de miLang
            int length = languages.Length - 1;

            if (miLang >= length)
            {
                miLang = languages.Length - 1;
            }
            if (miLang < 0)
            {
                miLang = 0;
            }
        }

        void Awake()
        {
            Validate();

            textAssign = new int[texts.Length];
            textAssign.ForEach((text) => {
                text = -1;
            });

            texts.ForEach((t, i) => {
                UnassignedText(i);
            });
        }
        //Valida que no tenga errores
        void Validate()
        {
            int length = texts.Length;

            languages.ForEach(e => {
                if (e == null)
                {
                    //No puedes dejar en null un elemento del array Language
                    Debug.LogError($"baboOn: 3.3- No puedes dejar un campo de Idioma sin asignar");
                }
            });
            texts.ForEach((e, i) =>
            {
                if (e == null)
                {
                    //No puedes dejar en null un elemento del array Text
                    Debug.LogError($"baboOn: 3.2- No puedes dejar un campo de Texto sin asignar");
                }
            });
        }

        //Asignar Texto
        public void AssignedText(int tmPro, int text) {
            if (tmPro > texts.Length-1 )
            {
                //No hay elementos en esa posicion del array
                Debug.LogError($"baboOn: 3.4- No existe un elemento asignado, a la posicion {tmPro} del array de texts");
                return;
            }
            if (text > texts.Length - 1)
            {
                //No hay elementos en esa posicion del array
                Debug.LogError($"baboOn: 3.4- No existe un elemento asignado, a la posicion {text} del array de dictionary del idioma \"{languages[miLang].name}\"");
                return;
            }

            textAssign[tmPro] = text;
            texts[tmPro].text = languages[miLang].dictionary[text];
        }
        //Desasignar texto
        public void UnassignedText(int tmPro) {
            if (tmPro > texts.Length-1)
            {
                //No hay elementos en esa posicion del array
                Debug.LogError($"baboOn: 3.4- No existe un elemento asignado, a la posicion {tmPro} del array de texts");
                return;
            }
            texts[tmPro].text = "";
        }

        //Cambia el idioma
        public void Alternate()
        {
            miLang = (miLang < (languages.Length - 1))
                ? ++miLang
                : 0;
        }
        //Cambia el idioma
        public void Change(int i)
        {
            //Valida la longitud de miLang
            int length = languages.Length - 1;

            if (i > length || i < 0)
            {
                //No hay elementos en esa posicion del array
                Debug.LogError($"baboOn: 3.4- No existe un elemento asignado, a la posicion {i} del array languages");
                return;
            }

            miLang = i;

            texts.ForEach((text, i) => {
                if (textAssign[i] == -1) {
                    text.text = "";
                    return;
                }
                text.text = languages[miLang].dictionary[textAssign[i]];
            });
        }

    }
}
