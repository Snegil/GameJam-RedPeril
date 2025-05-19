using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int Score;
    float scoreLoss;
    void Start()
    {
        
    }

   
    void Update()
    {
        Score -= (int)scoreLoss;
    }

   public void AddScore(int amount)
   {
        Score += amount;
   }
}
