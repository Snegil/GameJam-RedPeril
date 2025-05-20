using UnityEngine;
using UnityEngine.InputSystem;

public class OldMovement : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float rotationSpeed = 5f;
    
    [SerializeField, Header("For partial braking \ngets multiplied with linearvelocity Y")]
    float partialBrakeAmount;
    [SerializeField, Header("For full braking powah \ngets multiplied with linearvelocity Y")]
    float fullBrakeAmount;

    bool leftBrake = false;
    bool rightBrake = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Leftinput(InputAction.CallbackContext context)
    {        
        if (context.started) 
        {
            rb.AddRelativeTorque(new Vector3(0, 1, 0) * rotationSpeed, ForceMode.Force);            
            if (leftBrake)
            {
                return;
            }

            rb.AddRelativeForce(new Vector3(0, 0, 1) * speed, ForceMode.Force);
        }  
    }
    public void Rightinput(InputAction.CallbackContext context)
    {        
        if (context.started) 
        {
            rb.AddRelativeTorque(new Vector3(0, -1, 0) * rotationSpeed, ForceMode.Force);
            if (rightBrake)
            {
                return;
            }

            rb.AddRelativeForce(new Vector3(0, 0, 1) * speed, ForceMode.Force);
        }
    }
    public void LeftBrake(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            leftBrake = true;
            BrakeCheck();
        }
        else if (context.canceled)
        {
            leftBrake = false;
        }
    }
    public void RightBrake(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            rightBrake = true;
            BrakeCheck();
        }
        else if (context.canceled)
        {
            rightBrake = false;
        }
    }
    void BrakeCheck() 
    {
        if (leftBrake && rightBrake)
        {
            rb.linearVelocity *= fullBrakeAmount;
            return;
        }

        if (leftBrake || rightBrake)
        {
            rb.linearVelocity *= partialBrakeAmount;
        }        
    }
}
