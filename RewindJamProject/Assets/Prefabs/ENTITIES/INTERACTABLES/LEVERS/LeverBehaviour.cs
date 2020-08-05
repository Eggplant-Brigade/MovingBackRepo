using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehaviour : MonoBehaviour
{

    public GameObject NotActivatedSprite;
    public GameObject ActivatedSprite;

    public List<GameObject> ListOf_ActivateObjects;
    public List<GameObject> ListOf_DeactivateObject;

    GameObject CloneNearMe;

    public int _Time;

    bool _PlayerNear = false;
    bool _CloneNear = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _PlayerNear = true;
        }

        if (collision.CompareTag("clone"))
        {
            _CloneNear = true;
            CloneNearMe = collision.gameObject;
        }

       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _PlayerNear = false;
        }

        if (collision.CompareTag("clone"))
        {
            _CloneNear = false;
            CloneNearMe = null;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown("space") && _PlayerNear)
        {
            NotActivatedSprite.SetActive(false);
            ActivatedSprite.SetActive(true);

            foreach (GameObject item in ListOf_ActivateObjects)
            {
                item.SetActive(true);
            }

            foreach (GameObject item in ListOf_DeactivateObject)
            {
                item.SetActive(false);
            }

            StartCoroutine(ResetAfterSeconds(_Time));

            GetComponent<AudioSource>().Play();
        }


        if (_CloneNear && CloneNearMe.GetComponent<CloneBehaviour>().IsInteracting)
        {
            CloneNearMe.GetComponent<CloneBehaviour>().IsInteracting = false;

            NotActivatedSprite.SetActive(false);
            ActivatedSprite.SetActive(true);

            foreach (GameObject item in ListOf_ActivateObjects)
            {
                item.SetActive(true);
            }

            foreach (GameObject item in ListOf_DeactivateObject)
            {
                item.SetActive(false);
            }

            StartCoroutine(ResetAfterSeconds(_Time));
        }
    }

    IEnumerator ResetAfterSeconds(float TheSecs)
    {
        yield return new WaitForSeconds(TheSecs);

        foreach (GameObject item in ListOf_ActivateObjects)
        {
            item.SetActive(false);
        }

        foreach (GameObject item in ListOf_DeactivateObject)
        {
            item.SetActive(true);
        }

        NotActivatedSprite.SetActive(true);
        ActivatedSprite.SetActive(false);
    }
}
