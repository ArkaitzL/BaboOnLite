using UnityEngine;
using UnityEngine.SceneManagement;

namespace BaboOnLite
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/MenuUI")]
    [DisallowMultipleComponent]
    //[HelpURL("")]

    public class MenuUI : MonoBehaviour
    {
        //Cambia la escena
        public static void ChangeScene(int scene) {
            SceneManager.LoadScene(scene);
        }
        public static void ChangeScene(string scene){
            SceneManager.LoadScene(scene);
        }

        //Reinicia la escena
        public static void RestartScene() {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name
            );
        }

        //Activa y desactiva un GameObject dependiendo su anterior estado
        public static void ToggleOn(GameObject component) {
            component.SetActive(
                !component.activeSelf    
            );
        }

        //Activa o desactiva un GameObject dependiendo lo que quieras
        public static void Activate(GameObject component) {
            component.SetActive(
                true
            );
        }
        public static void Desactivate(GameObject component)
        {
            component.SetActive(
                false
            );
        }

        //Pausa o quita el pausa del juego
        public static void Pause(bool pause = true) {
            Time.timeScale = (pause) ? 0 : 1;
        }
    }
}
