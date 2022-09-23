using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {

        _gameManager = FindObjectOfType<GameManager>();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag("Player")) return;
        _gameManager.LoadNextScene();
    }

}
