using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}
