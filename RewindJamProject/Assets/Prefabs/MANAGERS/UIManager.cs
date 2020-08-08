using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject SliderObject;

    public GameObject PausePanel;

    public GameObject OptionPanel;

    public GameObject DialogueBox;

    void Update()
    {
        SliderObject.GetComponent<Slider>().value = PlayerBehaviour._Timer / GameManager._RewindTime;

        if (DialogueBox.activeInHierarchy && Input.anyKeyDown && !Input.GetKeyDown("space"))
        {
            DialogueBox.SetActive(false);
        }
    }

    public void TogglePauseMenu()
    {
        PausePanel.SetActive(!PausePanel.activeSelf);
    }

    public void ToggleOptionMenu()
    {
        OptionPanel.SetActive(!OptionPanel.activeSelf);
    }

    public void OpenDialogueBox(string theDialogue)
    {
        DialogueBox.SetActive(true);
        DialogueBox.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = theDialogue;
    }
}
