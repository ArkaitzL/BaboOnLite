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

    private void OnValidate()
    {
        if (autoInstance) {
            autoHeight = true;
        }
    }

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
    }

    Transform Instance(string name)
    {
        GameObject ob = new GameObject(name);
        ob.AddComponent<BoxCollider>();
        ob.transform.SetParent(transform);

        return ob.transform;
    }

    void Height(Transform go)
    {
        float camHeight = Camera.main.orthographicSize * 2;

        Vector3 scale = go.localScale;
        scale.y = camHeight;
        go.localScale = scale;
    }

}
