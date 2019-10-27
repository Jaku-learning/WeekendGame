using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject settingsMenuUI;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        settingsMenuUI.SetActive(true);
    }

    public void Back()
    {
        settingsMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
