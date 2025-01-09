using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("JUEGO");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
