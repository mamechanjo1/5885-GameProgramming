using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgsoundfade;

    public void StartGame()
    {
        bgsoundfade.DOFade(0.0f, 1.0f);
        Invoke("LoadScene", 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
