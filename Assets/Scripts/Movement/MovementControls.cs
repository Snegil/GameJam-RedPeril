using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    GameObject[] wizardObjects;

    [SerializeField]
    Material particleMaterial;

    [SerializeField]
    Color[] colours;

    [SerializeField, Header("AUDIO THINGIES")]
    AudioSource audioSource;

    [Space, SerializeField]
    AudioClip brakingOneSide;
    [SerializeField]
    AudioClip brakingBothSides;

    [Space, SerializeField]
    AudioClip wizardModeOn;
    

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
            audioSource.PlayOneShot(brakingBothSides);
            return;
        }

        if (leftBrake)
        {
            leftRB.linearVelocity *= partialBrakeAmount;
            audioSource.PlayOneShot(brakingOneSide);
        }        
        if (rightBrake)
        {
            rightRB.linearVelocity *= partialBrakeAmount;
            audioSource.PlayOneShot(brakingOneSide);
        }
    }
    public void ToggleWizardMode(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            flying = !flying;

            particleMaterial.color = flying ? colours[1] : colours[0];
            audioSource.PlayOneShot(wizardModeOn);
            if (wizardObjects.Length > 0)
            {
                foreach (GameObject obj in wizardObjects)
                {
                    obj.SetActive(flying);
                }
            }
        }
    }
    public void ResetButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AudioListener.pause = false;
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
