using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaboOn 
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOn/Sound")]
    [DisallowMultipleComponent]
    //[HelpURL("")]

    public class Sound : MonoBehaviour
    {
        [SerializeField] AudioClip[] sounds;

        static Sound instance;
        public static Sound sound { get => instance; set => instance = value; }

        void Instance()
        {
            if (instance == null)
            {
                instance = this;
                return;
            }

            //No se puede poner dos scripts de este tipo en la misma escena
            Debug.LogError($"baboOn: 5.1.-Existen varias instancias de languages, se ha destruido la instancia de \"{gameObject.name}\"");
            Destroy(this);
        }
        void Awake()
        {
            Instance();
        }

        //Crea sonidos de una sola vez. Puedes elegir que sonidos y en que posicion
        public void CreateSound(int sound, Vector3 position = default(Vector3))
        {
            if (Error5_2(sound)) return;
            AudioSource.PlayClipAtPoint(sounds[sound], position);
        }
        public void CreateSound(int[] sound, Vector3 position = default(Vector3))
        {
            sound.ForEach((i) => {
                if (!Error5_2(i)) { 
                    AudioSource.PlayClipAtPoint(sounds[i], position);
                }
            });
        }

        //Crea sonidos en bucle. Puedes elegir que sonidos y en que posicion
        public GameObject CreateInfinitySound(int sound, Vector3 position = default(Vector3)) 
        {
            if (!Error5_2(sound)) return null;

            GameObject soundInstance = new GameObject("LoopingSoundInstance");
            AudioSource audioSource = soundInstance.AddComponent<AudioSource>();
            audioSource.clip = sounds[sound];
            audioSource.loop = true;

            soundInstance.transform.position = position;
            audioSource.Play();

            return soundInstance;
        }

        public GameObject[] CreateInfinitySound(int[] sound, Vector3 position = default(Vector3)) 
        {
            List<GameObject> soundsInstance = new List<GameObject>();
            sound.ForEach((i) => {
                if (!Error5_2(i))
                {
                    GameObject soundInstance = new GameObject("LoopingSoundInstance");
                    soundsInstance.Add(soundInstance);
                    AudioSource audioSource = soundInstance.AddComponent<AudioSource>();
                    audioSource.clip = sounds[i];
                    audioSource.loop = true;

                    soundInstance.transform.position = position;
                    audioSource.Play();
                }
            });
            return soundsInstance.ToArray();
        }

        public void CreateVibration(int duration = 0)
        {
           
        }


        bool Error5_2(int value) {
            if (sounds.Inside(value)){
                Debug.Log($"baboOn: 5.2.-No existe el sonido {value} dentro de Sounds");
                return true;
            }
            return false;
        }

    }

}