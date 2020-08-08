using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{

    public GameObject RewindSprites;

    public GameObject PlaySprites;

    public AudioSource RewindSound;
    public AudioSource PlaySound;

    GameObject TheSprites;

    float _BlinkTimer = 0;
    float _Timer = 0;
    private void Start()
    {
        if (PlayerPrefs.GetInt("LL") == 1) //se proviene dal menu
        {
            //Transition Rewind
            TheSprites = RewindSprites;
            RewindSound.Play();
        }
        else
        {
            //Transition Forward
            TheSprites = PlaySprites;
            PlaySound.Play();

        }
    }


    private void Update()
    {
        _Timer += Time.deltaTime;
        _BlinkTimer += Time.deltaTime;

        if (_BlinkTimer >= 1)
        {
            TheSprites.SetActive(!TheSprites.activeInHierarchy);
            if (PlayerPrefs.GetInt("LL") == 3 && TheSprites.transform.childCount >0)
            {
                TheSprites.transform.GetChild(0).gameObject.SetActive(true);
                TheSprites.transform.GetChild(0).parent = TheSprites.transform.parent;
            }
            _BlinkTimer = 0;
        }

        if (_Timer >= 10 - PlayerPrefs.GetInt("LL"))
        {
            Debug.Log("leggo" + PlayerPrefs.GetInt("LL"));

            SceneManager.LoadScene(PlayerPrefs.GetInt("LL") + 1);
        }
    }



}
