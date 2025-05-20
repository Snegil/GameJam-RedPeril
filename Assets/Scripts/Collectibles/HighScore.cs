using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    float highScore;
    float score;
    public Timer timer;
    [SerializeField] TextMeshProUGUI highscore;

    [SerializeField]
    SceneTransition sceneTransition;
    
    private void Start()
    {       
        highscore.text = PlayerPrefs.GetFloat("HighScore", 1000).ToString();
    }
    public void GetScore()
    {
        score = timer.minuter * 60 + timer.sekunder;
        if(score <PlayerPrefs.GetFloat("Highscore",10000))
        {           
            PlayerPrefs.SetFloat("HighScore", score);
            highscore.text = Mathf.RoundToInt(score).ToString() + ": sekunder";
        }
    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
