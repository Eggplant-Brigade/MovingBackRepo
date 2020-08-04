using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float _SecondsBeforeRewind;

    public static float _RewindTime;
    private void Start()
    {
        _RewindTime = _SecondsBeforeRewind;
    }
}
