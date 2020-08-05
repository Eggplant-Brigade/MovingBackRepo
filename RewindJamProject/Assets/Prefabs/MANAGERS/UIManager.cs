using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject SliderObject;

    public GameObject PausePanel;

    void Update()
    {
        SliderObject.GetComponent<Slider>().value = PlayerBehaviour._Timer / GameManager._RewindTime;
    }

    public void TogglePauseMenu()
    {
        PausePanel.SetActive(!PausePanel.activeSelf);
    }
}
