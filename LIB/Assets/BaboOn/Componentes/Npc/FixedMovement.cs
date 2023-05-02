using System.Collections;
using UnityEngine;

namespace BaboOn
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOn/Npc/FixedMovement(NPC)")]
    [DisallowMultipleComponent]
    //[HelpURL("")]
    public class FixedMovement : MonoBehaviour
    {
        [SerializeField] Path path;
        [Space]
        [SerializeField] float waitTime = 2;
        [SerializeField] float speed = 2, rotateSpeed = 2;
        int i;
        [Space]
        [SerializeField] bool move2D;
        [SerializeField] bool goBack;
        bool back;

        private void Start()
        {
            //Se pone en la posicion inicial
            transform.position = path.positions[i++];
            StartCoroutine(Move());
        }

        IEnumerator Move()
        {
            yield return new WaitForSeconds(waitTime);

            //Calcula la direccion a la que se va a mover
            Vector3 currentPos = (back) 
                ? path.positions[--i]
                : path.positions[i++];
            Vector3 direction = (currentPos - transform.position).normalized;

            //Rota a la direccion a donde se va a mover
            while (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(direction)) > 0.01f)
            {
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(direction),
                    rotateSpeed * Time.deltaTime
                );
                yield return null;
            }

            //Se mueva a su proxima posicion
            while (Vector3.Distance(currentPos, transform.position) > 0.1f)
            {
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
                yield return null;
            }
            transform.position = currentPos;

            //Reinicia el proceso
            if (goBack) {
                if (i == path.positions.Length) back = true;
                if (i == 0) { 
                    back = false;
                    i = 1;
                }
            }
            else {
                if (i == path.positions.Length) i = 0;
            }
            StartCoroutine(Move());
        }

        [ContextMenu("Cancel Movement")]
        public void CancelMovement()
        {
            i--;
            StopAllCoroutines();
        }

        [ContextMenu("Start Movement")]
        public void StartMovement() {
            StartCoroutine(Move());
        }
    }
}