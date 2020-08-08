using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingObject : MonoBehaviour
{

    public Sprite SpriteA;
    public Sprite SpriteB;

    float _Timer;

    // Update is called once per frame
    void Update()
    {
        _Timer += Time.deltaTime;


    }
}
