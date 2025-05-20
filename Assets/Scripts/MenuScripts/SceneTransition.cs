using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        AudioListener.pause = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    public IEnumerator ChangeSceneCoroutine(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioListener.pause = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
