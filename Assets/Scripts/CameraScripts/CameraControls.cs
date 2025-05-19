using UnityEngine;

public class CameraControls : MonoBehaviour
{
    Transform playerTransform;

    [SerializeField]
    Vector3 offset = new(0, 2, -5);

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
