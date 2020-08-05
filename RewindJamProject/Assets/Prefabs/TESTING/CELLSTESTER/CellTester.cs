using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellTester : MonoBehaviour
{
        #region Variables

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
    #endregion


    #endregion

    #region Behaviours

    private void Start()
    {
        
    }

    private void Update()
    {

        #region Input Handling
        if (Input.GetKeyDown(MoveUp) || Input.GetKeyDown(MoveUp_Alt))
        {
            Move(0, _Step);
        }
        else if (Input.GetKeyDown(MoveLeft) || Input.GetKeyDown(MoveLeft_Alt))
        {
            Move(-_Step, 0);
        }
        else if (Input.GetKeyDown(MoveRight) || Input.GetKeyDown(MoveRight_Alt))
        {
            Move(_Step, 0);
        }
        else if (Input.GetKeyDown(MoveDown) || Input.GetKeyDown(MoveDown_Alt))
        {
            Move(0, -_Step);
        }
        #endregion
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GetComponent<SpriteRenderer>().color = new Color(1,0,0);
        }
        else if (collision.gameObject.CompareTag("interactable"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);
        }
        else if (collision.gameObject.CompareTag("destination"))
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        
    }

    #endregion

    #region Methods
    public void Move(float horizontal, float vertical)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position + new Vector3(horizontal, vertical));
        GetComponent<BoxCollider2D>().enabled = true;

        if (hit.transform == null || hit.collider.gameObject.layer != 8)
        {
            transform.position = transform.position + new Vector3(horizontal, vertical);
        }
    }

    

    #endregion
}
