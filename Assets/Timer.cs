using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    int timmar;
    public int minuter;
    public float sekunder;
    float millisekunder;
    
    [SerializeField] TextMeshProUGUI timerText;
   
    void Start()
    {
        sekunder = 0;
    }

    // Update is called once per frame
    void Update()
    {
        sekunder += Time.deltaTime;
        
        if(sekunder > 60)
        {
            minuter++;
            if(minuter >= 60)
            {
                minuter = 0;
                timmar++;
            }
            sekunder = 0;
        }    
        timerText.text = (timmar + (minuter + (":") + Mathf.RoundToInt(sekunder)).ToString());
      
    }
}
