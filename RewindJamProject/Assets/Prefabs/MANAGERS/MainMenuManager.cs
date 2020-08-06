using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI VersionText;
    public TextMeshProUGUI TitleText;
    private void Start()
    {

        PlayerPrefs.SetInt("LL", SceneManager.GetActiveScene().buildIndex);
        Debug.Log(PlayerPrefs.GetInt("LL"));

        VersionText.text = Application.version;
        TitleText.text = Application.productName;
    }


    public void LoadScene(string theSceneName)
    {
        SceneManager.LoadScene(theSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static void ChangeVolume(float volumevalue)
    {
        AudioListener.volume = volumevalue / 100;
    }

    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }
}
