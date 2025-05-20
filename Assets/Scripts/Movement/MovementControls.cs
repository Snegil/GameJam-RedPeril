using UnityEngine;
using UnityEngine.InputSystem;

public class MovementControls : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float rotationSpeed = 15f;
    
    [SerializeField, Header("For partial braking \ngets multiplied with linearvelocity Y")]
    float partialBrakeAmount;
    [SerializeField, Header("For full braking powah \ngets multiplied with linearvelocity Y")]
    float fullBrakeAmount;

    bool leftBrake = false;
    bool rightBrake = false;

    [Space, SerializeField, Header("--------------------")]
    Rigidbody rightRB;
    
    [SerializeField]
    Rigidbody leftRB;

    [SerializeField]
    GroundCheck groundCheck;

    [SerializeField]
    bool flying = false;

    public void Leftinput(InputAction.CallbackContext context)
    {       
        if (groundCheck.GroundedCheck() == false && flying == false) 
        {
            return;
        }

        if (context.started) 
        {
            leftRB.AddRelativeTorque(new Vector3(0, 1, 0) * rotationSpeed, ForceMode.Force);            
            if (leftBrake)
            {
                return;
            }

            leftRB.AddRelativeForce(new Vector3(0, 0, 1) * speed, ForceMode.Force);
        }  
    }
    public void Rightinput(InputAction.CallbackContext context)
    {        
        if (groundCheck.GroundedCheck() == false && flying == false) 
        {
            return;
        }
        if (context.started) 
        {
            rightRB.AddRelativeTorque(new Vector3(0, -1, 0) * rotationSpeed, ForceMode.Force);
            
            if (rightBrake)
            {
                return;
            }

            rightRB.AddRelativeForce(new Vector3(0, 0, 1) * speed, ForceMode.Force);
        }
    }
    public void LeftBrake(InputAction.CallbackContext context)
    {
        if (groundCheck.GroundedCheck() == false && flying == false) 
        {
            return;
        }

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
        if (groundCheck.GroundedCheck() == false && flying == false) 
        {
            return;
        }

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
            leftRB.linearVelocity *= fullBrakeAmount;
            rightRB.linearVelocity *= fullBrakeAmount;
            return;
        }

        if (leftBrake)
        {
            leftRB.linearVelocity *= partialBrakeAmount;
        }        
        if (rightBrake)
        {
            rightRB.linearVelocity *= partialBrakeAmount;
        }
    }
}
