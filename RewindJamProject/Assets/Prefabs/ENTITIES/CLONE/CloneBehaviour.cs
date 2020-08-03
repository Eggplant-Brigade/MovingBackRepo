using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneBehaviour : MonoBehaviour
{
    #region Variables

    [HideInInspector]
    public List<Vector3> ListOf_Movements;
    public List<float> ListOf_Timing;

    #region Timers
    [HideInInspector]
    public float _Timer;
    #endregion

    #endregion

    private void Start()
    {
        ListOf_Movements.RemoveAt(ListOf_Movements.Count - 1); //tolgo l'ultima coordinata che non mi serve visto che ci sono già sopra
    }

    // Update is called once per frame
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
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    }
}
