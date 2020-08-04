using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneBehaviour : MonoBehaviour
{
    #region Variables

    [HideInInspector]
    public List<Vector3> ListOf_Movements;
    [HideInInspector]
    public List<float> ListOf_Timing;
    [HideInInspector]
    public List<bool> ListOf_Interactions;

    #region Timers
    [HideInInspector]
    public float _Timer;
    #endregion

    [HideInInspector]
    public bool IsInteracting = false;
    #endregion

    #region Behaviour
    private void Start()
    {
        ListOf_Movements.RemoveAt(ListOf_Movements.Count - 1); //tolgo l'ultima coordinata che non mi serve visto che ci sono già sopra
    }

    void Update()
    {
        _Timer -= Time.deltaTime;
        if (_Timer <= 0 || ListOf_Timing.Count == 0)
        {
            Destroy(gameObject);
        }
        else if (_Timer <= ListOf_Timing[ListOf_Timing.Count -1] )
        {

            if (ListOf_Movements.Count == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = ListOf_Movements[ListOf_Movements.Count - 1];

                ListOf_Movements.RemoveAt(ListOf_Movements.Count - 1);
                ListOf_Timing.RemoveAt(ListOf_Timing.Count - 1);


                
                ListOf_Interactions.RemoveAt(ListOf_Interactions.Count - 1);

                IsInteracting = ListOf_Interactions[ListOf_Interactions.Count - 1];
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    }
    #endregion
}
