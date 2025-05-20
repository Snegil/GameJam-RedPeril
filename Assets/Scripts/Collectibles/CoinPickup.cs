using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int Value;
    public ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            scoreManager.AddScore(Value);
            gameObject.SetActive(false);
        }
    }
   
}
