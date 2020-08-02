using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    #region Variables

    #region References
    public Vector3 Spawn;
    public GameObject Clone;
    #endregion

    #region Inputs
    [Header("INPUT")]
    public KeyCode MoveUp;
    public KeyCode MoveUp_Alt;
    [Space(5)]
    public KeyCode MoveLeft;
    public KeyCode MoveLeft_Alt;
    [Space(5)]
    public KeyCode MoveRight;
    public KeyCode MoveRight_Alt;
    [Space(5)]
    public KeyCode MoveDown;
    public KeyCode MoveDown_Alt;

    #endregion

    #region Tuning
    [Header("TUNING")]
    public float _Step = 1;
    public float _RewindTimer = 30;
    
    #endregion

    #region Timers
    float _Timer = 0;
    #endregion

    [HideInInspector]
    public List<Vector3> ListOf_Movements;
    public List<float> ListOf_Timing;

    #endregion

    private void Update()
    {
        
        _Timer += Time.deltaTime;

        #region Rewind

        if (_Timer >= _RewindTimer)
        {
            _Timer = 0;

            if (ListOf_Movements.Count > 0) //Se mi sono mosso almeno una volta
            {
                #region Crea Clone
                GameObject newClone = Instantiate(Clone, transform.position, Quaternion.identity); //creo clone

                newClone.GetComponent<CloneBehaviour>().ListOf_Movements = new List<Vector3>(ListOf_Movements); //gli do la lista dei movimenti
                newClone.GetComponent<CloneBehaviour>().ListOf_Timing = new List<float>(ListOf_Timing); //e la lista dei tempi
                newClone.GetComponent<CloneBehaviour>()._Timer = _RewindTimer; //e il tempo totale
                #endregion

                //Riporta giocatore alla partenza
                transform.position = Spawn;

                //Pulisco liste
                for (int i = ListOf_Movements.Count - 1; i > -1; i--)
                {
                    ListOf_Movements.RemoveAt(i);
                    ListOf_Timing.RemoveAt(i);
                }
            }
        }

        #endregion


        #region Input Handling
        if (Input.GetKeyDown(MoveUp)|| Input.GetKeyDown(MoveUp_Alt))
        {
            transform.position = transform.position + new Vector3(0, _Step);
            ListOf_Movements.Add(transform.position);

            float currentTime = _Timer;
            ListOf_Timing.Add(currentTime);
        }
        else if (Input.GetKeyDown(MoveLeft) || Input.GetKeyDown(MoveLeft_Alt))
        {
            transform.position = transform.position + new Vector3(-_Step, 0);
            ListOf_Movements.Add(transform.position);

            float currentTime = _Timer;
            ListOf_Timing.Add(currentTime);
        }
        else if (Input.GetKeyDown(MoveRight) || Input.GetKeyDown(MoveRight_Alt))
        {
            transform.position = transform.position + new Vector3(_Step, 0);
            ListOf_Movements.Add(transform.position);

            float currentTime = _Timer;
            ListOf_Timing.Add(currentTime);
        }
        else if (Input.GetKeyDown(MoveDown) || Input.GetKeyDown(MoveDown_Alt))
        {
            transform.position = transform.position + new Vector3(0, -_Step);
            ListOf_Movements.Add(transform.position);

            float currentTime = _Timer;
            ListOf_Timing.Add(currentTime);
        }
        #endregion
    }
}
