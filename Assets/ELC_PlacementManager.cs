using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_PlacementManager : MonoBehaviour
{
    private int verifiedObjects;
    private int verifiedCandles;

    public List<GameObject> objectsPlacements = new List<GameObject>(); //Sud, Ouest, Nord-Ouest, Nord-Est, Est
    public List<GameObject> candlesPlacements = new List<GameObject>(); //Nord, Est, Sud-Est, Sud-Ouest, Ouest

    public List<string> objectsOrder = new List<string>();
    public List<string> candlesTagOrder = new List<string>();


    private void Update()
    {
        verifiedCandles = 0;
        verifiedObjects = 0;

        for (int i = 0; i < objectsPlacements.Count; i++)
        {
            if (objectsPlacements[i].GetComponent<ELC_Emplacement>().objectPlaced != null && objectsOrder[i] != null)
            {
                if (objectsPlacements[i].GetComponent<ELC_Emplacement>().objectPlaced.GetComponent<FCO_ItemsScriptableObjects>().ingredientType.ToString() == objectsOrder[i]) verifiedObjects++;
            }

            if (candlesPlacements[i].GetComponent<ELC_Emplacement>().objectPlaced != null)
            {
                if (candlesTagOrder[i] == candlesPlacements[i].GetComponent<ELC_Emplacement>().objectPlaced.GetComponent<FCO_ItemsScriptableObjects>().ingredientType.ToString()) verifiedCandles++;
            }
        }

        if(verifiedCandles >= 5)
        {
            //Bougies vérifiées
        }

        if(verifiedObjects >= 3)
        {
            //Objets vérifiés
        }

    }

}
