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

    public Sprite MoveUpSprite;
    public Sprite MoveDownSprite;
    public Sprite MoveLeftSprite;
    public Sprite MoveRightSprite;
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
    
    #endregion

    #region Timers
    public static float _Timer = 0;
    
    #endregion

    #region Liste
    [HideInInspector]
    public List<Vector3> ListOf_Movements;
    [HideInInspector]
    public List<float> ListOf_Timing;
    [HideInInspector]
    public List<bool> ListOf_Interaction;
    #endregion

    #endregion

    #region Behaviours

    private void Start()
    {
        Spawn = transform.position;
    }

    private void Update()
    {
        
        _Timer += Time.deltaTime;

        if (_Timer >= GameManager._RewindTime)
        {
            Rewind();
        }


        #region Input Handling
        if (Input.GetKeyDown(MoveUp)|| Input.GetKeyDown(MoveUp_Alt))
        {
            Move(0, _Step);

            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().sprite = MoveUpSprite;
        }
        else if (Input.GetKeyDown(MoveLeft) || Input.GetKeyDown(MoveLeft_Alt))
        {
            Move(-_Step, 0);

            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().sprite = MoveRightSprite;
            
        }
        else if (Input.GetKeyDown(MoveRight) || Input.GetKeyDown(MoveRight_Alt))
        {
            Move(_Step, 0);

            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().sprite = MoveRightSprite;
        }
        else if (Input.GetKeyDown(MoveDown) || Input.GetKeyDown(MoveDown_Alt))
        {
            Move(0, -_Step);

            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().sprite = MoveDownSprite;
        }
        else if (Input.GetKeyDown("space"))
        {
            ListOf_Movements.Add(transform.position);
            float currentTime = _Timer;
            ListOf_Timing.Add(currentTime);

            ListOf_Interaction.Add(true);
        }
        #endregion
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("clone"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        else if (collision.gameObject.layer == 8)
        {
            Rewind();
        }
    }

    #endregion

    #region Methods
    public void Move(float horizontal, float vertical)
    {
        #region Check Movement Line

        GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position + new Vector3(horizontal, vertical));

        if (hit.transform != null && hit.collider.gameObject.CompareTag("interactable"))
        {
            Collider2D CollidedInteractable = hit.collider;
            CollidedInteractable.enabled = false;
            hit = Physics2D.Linecast(transform.position, transform.position + new Vector3(horizontal, vertical));
            CollidedInteractable.enabled = true;
        }
        GetComponent<BoxCollider2D>().enabled = true;

        #endregion

        if (hit.transform == null || hit.collider.gameObject.layer != 8 )
        {
            #region Movable Object
            if (hit.transform != null && hit.collider.gameObject.CompareTag("movable"))
            {
                if(!hit.collider.gameObject.GetComponent<MovableObjectBehaviour>().AttemptMove(vertical, horizontal))
                {
                    return;
                }
            }
            #endregion

            transform.position = transform.position + new Vector3(horizontal, vertical);

            #region Aggiorna Lista
            ListOf_Movements.Add(transform.position);

            float currentTime = _Timer;
            ListOf_Timing.Add(currentTime);

            ListOf_Interaction.Add(false);
            #endregion
        }

    }

    public void Rewind()
    {
        if (ListOf_Movements.Count > 0) //Se mi sono mosso almeno una volta
        {
            #region Crea Clone
            GameObject newClone = Instantiate(Clone, transform.position, Quaternion.identity); //creo clone
            newClone.transform.localScale = transform.localScale; //rendo della stessa misura del Player

            newClone.GetComponent<CloneBehaviour>().ListOf_Movements = new List<Vector3>(ListOf_Movements); //gli do la lista dei movimenti
            newClone.GetComponent<CloneBehaviour>().ListOf_Timing = new List<float>(ListOf_Timing); //e la lista dei tempi
            
            
            newClone.GetComponent<CloneBehaviour>().ListOf_Interactions = new List<bool>(ListOf_Interaction);
            #endregion

            #region Resetta Player
            //Riporta giocatore alla partenza
            transform.position = Spawn;

            //Pulisco liste
            for (int i = ListOf_Movements.Count - 1; i > -1; i--)
            {
                ListOf_Movements.RemoveAt(i);
                ListOf_Timing.RemoveAt(i);
                ListOf_Interaction.RemoveAt(i);
            }
            #endregion
        }

        _Timer = 0;
    }

    #endregion
}
