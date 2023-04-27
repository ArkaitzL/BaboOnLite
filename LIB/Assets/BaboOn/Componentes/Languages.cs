using UnityEngine;
using TMPro;
using baboOn;

namespace baboon {
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("baboOn/Languages")]
    public class Languages : MonoBehaviour
    {
        [SerializeField] Language[] languages = new Language[0];
        [SerializeField] TextMeshProUGUI[] texts = new TextMeshProUGUI[0];
        [SerializeField] int miLang = 0;
        static Languages instance;

        public static Languages Data { get => instance; }

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

        void Text() {
            texts.ForEach((e, i) =>
            {
                e.text = languages[miLang].texts[i];
            });
        }

        public void Alternate()
        {
            miLang = (miLang < (languages.Length-1))
                ? ++miLang
                : 0;
            Text();
        }

        public void Change(int i)
        {
            miLang = i;
            Text();
        }

    }
}
