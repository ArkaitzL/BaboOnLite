using UnityEngine;

[AddComponentMenu("baboOn/Limit")]
public class Limit : MonoBehaviour
{

    [System.Serializable]
    public class Manual
    {
        [SerializeField] internal Transform left, right;
    }

    [Space]

    [SerializeField] Manual manual;

    [Space]

    [SerializeField] bool autoHeight;
    [SerializeField] bool autoInstance;

    [Space]

    [SerializeField] bool confirmLog = true;
    string color = "white";

    //Valida el uso de height junto a instance
    private void OnValidate()
    {
        if (autoInstance) {
            autoHeight = true;
        }
    }
    //Posiciona los elementos a los bordes de la camara
    private void Start()
    {
        float camWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        if (autoInstance)
        {
            manual.left = Instance("left");
            manual.right = Instance("right");
        }

        if (autoHeight)
        {
            Height(manual.left);
            Height(manual.right);
        }

        manual.left.position = new Vector3(
            Camera.main.transform.position.x - (camWidth / 2) - (manual.left.localScale.z / 2),
        0, 0);
        manual.right.position = new Vector3(
            Camera.main.transform.position.x + (camWidth / 2) + (manual.right.localScale.z / 2),
        0, 0);

        if (confirmLog) {
            Debug.LogFormat($"<color={color}> Se han establecido los limites. </color>");
        }
    }
    //Instancia dos BoxCollider2D
    Transform Instance(string name)
    {
        GameObject ob = new GameObject(name);
        ob.AddComponent<BoxCollider>();
        ob.transform.SetParent(transform);

        return ob.transform;
    }
    //Adapta el tamaño a la altura de la camara
    void Height(Transform go)
    {
        float camHeight = Camera.main.orthographicSize * 2;

        Vector3 scale = go.localScale;
        scale.y = camHeight;
        go.localScale = scale;
    }

}
