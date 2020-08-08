using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float _SecondsBeforeRewind;

    public KeyCode PauseButton;

    public static float _RewindTime;

    public GameObject Player;

    //public static List<CloneBehaviour> ListOf_Clones;

    private void Start()
    {
        _RewindTime = _SecondsBeforeRewind;

        PlayerPrefs.SetInt("LL", SceneManager.GetActiveScene().buildIndex);

        Debug.Log("carico "+ PlayerPrefs.GetInt("LL"));
    }

    private void Update()
    {
        if (Input.GetKeyDown(PauseButton))
        {
            TogglePause();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene("Transition");
        PlayerBehaviour._Timer = 0;
    }

    public void TogglePause()
    {
        Player.GetComponent<PlayerBehaviour>().IsGamePaused = !Player.GetComponent<PlayerBehaviour>().IsGamePaused;

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        GetComponent<UIManager>().TogglePauseMenu();
    }

    public void ChangeVolume(Scrollbar VolumeScrollBar)
    {
        AudioListener.volume = VolumeScrollBar.value;
    }
}
