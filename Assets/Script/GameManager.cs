using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        var numGameManagers = FindObjectsOfType<GameManager>().Length;
        if(numGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }

    }

    public void ProcessPlayerDeath()
    {
        RestartScene();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        var nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextSceneBuildIndex == SceneManager.sceneCountInBuildSettings){
        nextSceneBuildIndex = 0;
        }
        SceneManager.LoadScene(nextSceneBuildIndex);
    }
}
