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

    public List<GameObject> DebugList;


    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DebugList.Add(collision.gameObject);

        foreach (GameObject TheObject in ListOf_ObjectActivated)
        {
            TheObject.SetActive(true);
        }

        foreach (GameObject TheObject in ListOf_ObjectsDeactivated)
        {
            TheObject.SetActive(false);
        }

        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DebugList.Remove(collision.gameObject);

        if (DebugList.Count == 0)
        {
            foreach (GameObject TheObject in ListOf_ObjectActivated)
            {
                TheObject.SetActive(false);
            }

            foreach (GameObject TheObject in ListOf_ObjectsDeactivated)
            {
                TheObject.SetActive(true);
            }
        }

    }
}
