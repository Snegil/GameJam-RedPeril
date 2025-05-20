using UnityEngine;

public class CenterOnWorld : MonoBehaviour
{
    [SerializeField]
    Transform placeToAppear;

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = placeToAppear.position;
    }
}
