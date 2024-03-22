using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject _options;

    public void StartGame()
    {
        ScAudioManager.Instance.PlaySong("MenuButton");
        SceneManager.LoadScene("DevScene"); 
    }

    public void OpenOptions()
    {
        ScAudioManager.Instance.PlaySong("MenuButton");
        _options.SetActive(true);
    }

    public void CloseOptions()
    {
        ScAudioManager.Instance.PlaySong("MenuButton");
        _options.SetActive(false);
    }

    public void QuitGame()
    {
        ScAudioManager.Instance.PlaySong("MenuButton");
        Application.Quit();
    }

    public void Restart()
    {
        ScAudioManager.Instance.PlaySong("MenuButton");
        SceneManager.LoadScene("DevScene");
    }

    public void MainMenu()
    {
        ScAudioManager.Instance.PlaySong("MenuButton");
        SceneManager.LoadScene("MainMenu");
    }
}
