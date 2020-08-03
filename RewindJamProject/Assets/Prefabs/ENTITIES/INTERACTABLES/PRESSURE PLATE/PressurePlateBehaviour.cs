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

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entrato qualcosa");

        foreach (GameObject TheObject in ListOf_ObjectActivated)
        {
            TheObject.SetActive(true);
        }

        foreach (GameObject TheObject in ListOf_ObjectsDeactivated)
        {
            TheObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
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
