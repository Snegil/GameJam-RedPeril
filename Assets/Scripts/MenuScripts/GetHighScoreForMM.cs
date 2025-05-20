using TMPro;
using UnityEngine;

public class GetHighScoreForMM : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
        }
    }
}
