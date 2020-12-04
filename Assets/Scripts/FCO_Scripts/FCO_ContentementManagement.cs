using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_ContentementManagement : MonoBehaviour
{
    public int contentement;
    HDO_Dialogues dialogues;

    public GameObject demonBG;
    public GameObject demimonde;

    private void Start()
    {
        dialogues = GameObject.FindObjectOfType<HDO_Dialogues>();
    }

    public void Invocation()
    {
        if (FindObjectOfType<ELC_PlacementManager>() != null && FindObjectOfType<HDO_RoutePentacle>() != null)
        {
            ELC_PlacementManager placementManager = FindObjectOfType<ELC_PlacementManager>();

            if (placementManager.objectsAreGood)
            {
                contentement++;
            }
            else contentement--;

            if (placementManager.candlesAreGood)
            {
                contentement++;
            }
            else contentement--;

            HDO_RoutePentacle routePentacle = FindObjectOfType<HDO_RoutePentacle>();

            if (routePentacle.GoodDessin)
            {
                contentement++;
            }
            else if (routePentacle.pentacleFail)
            {
                contentement--;
            }            
        }
        else contentement--;

        if(GameObject.FindGameObjectWithTag("Puits"))
        {
            if (contentement >= 0)
            {
                Instantiate<GameObject>(demonBG, GameObject.FindGameObjectWithTag("Puits").transform);
                dialogues.sequence = 5;
                dialogues.shouldWrite = true;
            }
            else
            {
                Instantiate<GameObject>(demimonde, GameObject.FindGameObjectWithTag("Puits").transform);
                dialogues.sequence = 6;
                dialogues.shouldWrite = true;
            }
        }
        else
        {
                Instantiate<GameObject>(demimonde, null);
                dialogues.sequence = 6;
                dialogues.shouldWrite = true;
        }
        
    }
}
