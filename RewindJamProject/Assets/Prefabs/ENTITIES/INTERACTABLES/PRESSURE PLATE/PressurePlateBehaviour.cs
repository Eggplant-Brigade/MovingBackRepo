using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBehaviour : MonoBehaviour
{
    #region Variable

    #region References
    public List<GameObject> ListOf_ObjectActivated;
    public List<GameObject> ListOf_ObjectsDeactivated;
    #endregion

    #region
    bool IsPlayerInside = false;
    bool IsCloneInside= false;
    #endregion

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {

        foreach (GameObject TheObject in ListOf_ObjectActivated)
        {
            TheObject.SetActive(true);
        }

        foreach (GameObject TheObject in ListOf_ObjectsDeactivated)
        {
            TheObject.SetActive(false);
        }

        if (collision.CompareTag("Player"))
        {
            IsPlayerInside = true;
        }
        else if(collision.CompareTag("clone"))
        {
            IsCloneInside = true;
        }

        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !IsCloneInside || collision.CompareTag("clone") && !IsPlayerInside)
        {
            foreach (GameObject TheObject in ListOf_ObjectActivated)
            {
                TheObject.SetActive(false);
            }

            foreach (GameObject TheObject in ListOf_ObjectsDeactivated)
            {
                TheObject.SetActive(true);
            }

            if (collision.CompareTag("Player"))
            {
                IsPlayerInside = false;
            }
            else if (collision.CompareTag("clone"))
            {
                IsCloneInside = false;
            }
        }

    }
}
