﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Emplacement : MonoBehaviour
{
    public GameObject objectPlaced;


    public void placeObject(GameObject GO)
    {
        if (GO.CompareTag("WhiteCandle") || GO.CompareTag("GreenCandle") || GO.CompareTag("BlackCandle") || GO.CompareTag("PurpleCandle") || GO.CompareTag("RedCandle")) objectPlaced = GO;
    }
}
