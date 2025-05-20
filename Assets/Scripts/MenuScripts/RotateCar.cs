using UnityEngine;

public class RotateCar : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
