using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject buttonRetry;
    [SerializeField] private GameObject buttonYouWon;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void WinGame()
    {
        StopGame();
        buttonYouWon.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void GameOver()
    {
        StopGame();
        buttonRetry.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu()
    {
        ContinueGame();
        SceneManager.LoadScene("MENU");
    }

    public void RestartGame()
    {
        ContinueGame();
        SceneManager.LoadScene("JUEGO");
        Cursor.lockState = CursorLockMode.Locked;
    }
}
