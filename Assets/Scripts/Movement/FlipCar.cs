using UnityEngine;

public class FlipCar : MonoBehaviour
{
    [SerializeField]
    GroundCheck groundCheck;

    [SerializeField]
    Rigidbody[] rb;

    [SerializeField]
    float lerpSpeed = 5f;
    float lerpTime = 0;

    [SerializeField]
    float timer = 5f;
    float setTimer;

    void Start()
    {
        setTimer = timer;
    }

    void FixedUpdate()
    {
        if (groundCheck.GroundedCheck() != false && rb[0].linearVelocity.magnitude <= 5)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                lerpTime += Time.deltaTime * lerpSpeed;
                transform.localScale = new Vector3(1, Mathf.Lerp(1, -1, lerpTime), 1);               
            }
            
            if (lerpTime >= 1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                timer = setTimer;
                lerpTime = 0;
            }
            return;
        }

        timer = setTimer;
        lerpTime = 0;
    }
}
