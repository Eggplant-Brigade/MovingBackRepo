using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObjectBehaviour : MonoBehaviour
{
    [Tooltip("Inserite il Manager qui")]
    public UIManager UiManagerscript;

    public string _DialogueText;

    bool IsPlayerInsideTrigger = false;

    public KeyCode InteractInput;

    

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInsideTrigger)
        {
            if (Input.GetKeyDown(InteractInput))
            {
                Debug.Log("Ha premuto");
                UiManagerscript.OpenDialogueBox(_DialogueText);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerInsideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            IsPlayerInsideTrigger = false;
        }
    }
}
