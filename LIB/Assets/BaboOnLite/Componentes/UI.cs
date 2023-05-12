using UnityEngine;
using UnityEngine.SceneManagement;

namespace BaboOnLite
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/UI")]
    [DisallowMultipleComponent]
    //[HelpURL("")]

    public class UI : MonoBehaviour
    {
        //Cambia la escena
        public void ChangeScene(int scene) {
            SceneManager.LoadScene(scene);
        }
        public void ChangeScene(string scene){
            SceneManager.LoadScene(scene);
        }

        //Reinicia la escena
        public void RestartScene() {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name
            );
        }

        //Activa y desactiva un GameObject dependiendo su anterior estado
        public void ToggleOn(GameObject component) {
            component.SetActive(
                !component.activeSelf    
            );
        }

        //Activa o desactiva un GameObject dependiendo lo que quieras
        public void Activate(GameObject component) {
            component.SetActive(
                true
            );
        }
        public void Desactivate(GameObject component)
        {
            component.SetActive(
                false
            );
        }

        //Pausa o quita el pausa del juego
        public void Pause(bool pause = true) {
            Time.timeScale = (pause) ? 0 : 1;
        }
    }
}
