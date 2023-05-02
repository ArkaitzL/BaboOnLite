using UnityEngine;

namespace BaboOn {
    [DefaultExecutionOrder(-1)]
    [AddComponentMenu("BaboOn/Languages/LangController")]
    [DisallowMultipleComponent]
    //[HelpURL("")]
    public class LanguagesController : MonoBehaviour
    {
        [SerializeField] int miLang;

        //Cambia el idioma
        public void Alternate()
        {

        }
        //Cambia el idioma
        public void Change(int i)
        {
        }
    }
}
