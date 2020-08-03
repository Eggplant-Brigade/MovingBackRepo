using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBehaviour : MonoBehaviour
{
    #region Variable

    #region References
    public List<GameObject> ListOf_ObjectActivated;
    #endregion

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Qualcosa è entrato");
        foreach (GameObject TheObject in ListOf_ObjectActivated)
        {
            TheObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Qualcosa è uscito");
        foreach (GameObject TheObject in ListOf_ObjectActivated)
        {
            TheObject.SetActive(false);
        }
    }
}
