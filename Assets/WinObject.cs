using UnityEngine;

public class WinObject : MonoBehaviour
{
    public HighScore highScore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            highScore.GetScore();
            Debug.Log("Klarade banan");
        }
    }
}
