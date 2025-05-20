using System.Collections;
using UnityEngine;

public class Salmon : MonoBehaviour
{
    [SerializeField]
    float power = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Right") || other.CompareTag("Left"))
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 2f), Random.Range(-1f, 1f)) * power, ForceMode.Impulse);
        }
    }
}
