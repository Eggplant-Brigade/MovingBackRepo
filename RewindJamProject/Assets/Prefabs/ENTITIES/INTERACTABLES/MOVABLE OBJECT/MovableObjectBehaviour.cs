using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectBehaviour : MonoBehaviour
{
    public bool AttemptMove(float vertical, float horizontal)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position + new Vector3(horizontal, vertical));
        GetComponent<BoxCollider2D>().enabled = true;

        if (hit.transform == null || hit.collider.gameObject.layer != 8 && !hit.collider.gameObject.CompareTag("movable"))
        {

            transform.position = transform.position + new Vector3(horizontal, vertical);

            return true;
        }
        else
        {
            return false;
        }
    }
}
