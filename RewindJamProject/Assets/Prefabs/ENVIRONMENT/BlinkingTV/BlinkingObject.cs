using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingObject : MonoBehaviour
{

    public Sprite SpriteA;
    public Sprite SpriteB;

    float _Timer;

    bool Phase=false;

    // Update is called once per frame
    void Update()
    {
        _Timer += Time.deltaTime;

        if (!Phase && _Timer >= 1)
        {
            

            GetComponent<SpriteRenderer>().sprite = SpriteB;

            if (_Timer >= 2)
            {
                GetComponent<SpriteRenderer>().sprite = SpriteA;

                Phase = true;
                _Timer = 0;
            }
        }
        else if (Phase && _Timer >= 1)
        {

            GetComponent<SpriteRenderer>().sprite = SpriteB;

            if (_Timer >= 1.2)
            {
                GetComponent<SpriteRenderer>().sprite = SpriteA;
            }

            if (_Timer >= 1.4)
            {
                GetComponent<SpriteRenderer>().sprite = SpriteB;
            }

            if (_Timer >= 1.6)
            {
                GetComponent<SpriteRenderer>().sprite = SpriteA;
                Phase = false;
                _Timer = 0;
            }
        }

    }
}
