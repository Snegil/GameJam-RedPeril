using UnityEngine;

public class WinObject : MonoBehaviour
{
    public HighScore highScore;
    [SerializeField]
    SceneTransition sceneTransition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            highScore.GetScore();
            StartCoroutine(sceneTransition.ChangeSceneCoroutine("MainMenu", 5f));
            //sceneTransition.ChangeScene("MainMenu");
            Debug.Log("Klarade banan");
        }
    }
}
