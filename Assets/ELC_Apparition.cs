using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Apparition : MonoBehaviour
{
    private bool isActive = false;
    void ActivateBook()
    {
        isActive = !isActive;
        this.gameObject.SetActive(isActive);
    }
}
