using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionChanger : MonoBehaviour
{

    public Vector2 _CameraPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Camera.main.transform.position = _CameraPosition;

        } 
    }
}
