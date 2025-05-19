using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float spinSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 180f * spinSpeed * Time.deltaTime) ;
    }
}
