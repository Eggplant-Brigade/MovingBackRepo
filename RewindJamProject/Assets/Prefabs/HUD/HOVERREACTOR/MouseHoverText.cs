using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject ObjectToAppear;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ObjectToAppear.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ObjectToAppear.SetActive(false);
    }
}
