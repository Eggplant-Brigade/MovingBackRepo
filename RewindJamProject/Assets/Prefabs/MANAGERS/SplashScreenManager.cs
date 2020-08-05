using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenManager : MonoBehaviour
{
    public Image Logo;
    public TextMeshProUGUI Title;
    public float _AppearingTime;
    public float _EndTime;

    float _Timer=0;
    float _AlphaTimer = 0;


    // Update is called once per frame
    void Update()
    {

        _Timer += Time.deltaTime;


        if (_Timer > _AppearingTime)
        {
            _AlphaTimer += Time.deltaTime;

            Logo.color = new Color(1, 1, 1, _AlphaTimer / _EndTime);
            Title.color = new Color(1, 1, 1, _AlphaTimer / _EndTime);
        }

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
