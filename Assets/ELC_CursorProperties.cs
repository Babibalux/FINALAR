using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_CursorProperties : MonoBehaviour
{
    public bool cursorTouchEmplacement;
    public GameObject touchedObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Emplacement"))
        {
            cursorTouchEmplacement = true;
            touchedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Emplacement"))
        {
            cursorTouchEmplacement = false;
            touchedObject = null;
        }
    }
}
