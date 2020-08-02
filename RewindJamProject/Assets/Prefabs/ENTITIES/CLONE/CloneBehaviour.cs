using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneBehaviour : MonoBehaviour
{
    #region Variables

    public List<Vector3> ListOf_Movements;

    #region Timers
    public float _Timer = 1;
    #endregion

    #endregion



    // Update is called once per frame
    void Update()
    {
        _Timer -= Time.deltaTime;

        

        if (_Timer <=0)
        {

            if (ListOf_Movements.Count == 0)
            {
                Destroy(gameObject);
            }
            else
            {

                transform.position = ListOf_Movements[ListOf_Movements.Count - 1];

                ListOf_Movements.RemoveAt(ListOf_Movements.Count - 1);


                _Timer = 1;
            }
        }
    }
}
