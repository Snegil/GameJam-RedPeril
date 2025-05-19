using UnityEngine;
using UnityEngine.InputSystem;

public class MovementControls : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float speed = 5f;

    [SerializeField]
    Vector2 direction = new(0, 0);
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /*
    void FixedUpdate()
    {
        rb.AddRelativeForce(new Vector3(0, 0, direction.y) * speed, ForceMode.Force);
    }
    */
    
    public void LTinput(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            rb.AddRelativeForce(new Vector3(0, 0, 1) * speed, ForceMode.Force);
            rb.AddRelativeTorque(new Vector3(0, 1, 0));
            // direction.y = 0.5f;
            // direction.x = 1f;
        }   
    }
    public void RTinput(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            rb.AddRelativeForce(new Vector3(0, 0, 1) * speed, ForceMode.Force);
            rb.AddRelativeTorque(new Vector3(0, -1, 0));
            // direction.y = 0.5f;
            // direction.x = -1f;
        }   
    }
}
