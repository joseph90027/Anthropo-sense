using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;


public class PrintPointerEvent : MonoBehaviour, IMixedRealityPointerHandler
{

    void Update()
    {
        //OnPointerDown();

    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        Debug.Log(eventData + " OnPointerDown");
        
        if (eventData.Pointer is SpherePointer)
        {
            Debug.Log($"Grab start from {eventData.Pointer.PointerName}");
        }
        if (eventData.Pointer is PokePointer)
        {
            Debug.Log($"Touch start from {eventData.Pointer.PointerName}");
        }
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData) { Debug.Log(eventData + " OnPointerClicked"); }
    public void OnPointerDragged(MixedRealityPointerEventData eventData) { Debug.Log(eventData + " OnPointerDragged"); }
    public void OnPointerUp(MixedRealityPointerEventData eventData) { Debug.Log(eventData + " OnPointerUp"); }
}
