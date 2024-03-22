using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject _options;

    public void StartGame()
    {
        SceneManager.LoadScene("DevScene");
    }

    public void OpenOptions()
    {
        _options.SetActive(true);
    }

    public void CloseOptions()
    {
        _options.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("DevScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
