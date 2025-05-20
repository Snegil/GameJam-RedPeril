using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int Score;
  
    public Timer timer;
    void Start()
    {
        
    }

   
    void Update()
    {
       
    }

   public void AddScore(int amount)
   {
      timer.sekunder -= amount;
   }
}
