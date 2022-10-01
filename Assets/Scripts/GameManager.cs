using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LivesDisplay livesDisplay;

    // Simple singleton script. This is the easiest way to create and understand a singleton script.
    
    [SerializeField] private int lives = 3;

    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        lives -= 1;

        if (lives == 0)
        {
        SceneManager.LoadScene(0);
        Destroy(gameObject);    
        }

        else
        {  
            Debug.Log(lives);
            livesDisplay.UpdateScore(lives);
            SceneManager.LoadScene(GetCurrentBuildIndex());
        }
    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        
        SceneManager.LoadScene(nextSceneIndex);
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public GameObject[] hearts;
    public int life;
    private bool dead;

}
