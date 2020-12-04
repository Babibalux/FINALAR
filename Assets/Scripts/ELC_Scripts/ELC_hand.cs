using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_hand : MonoBehaviour
{

    public GameObject hand; //Le GameObject
    public GameObject inHandObject;
    public AddObjectToPosition interactScript;

    public bool playerHoldSomething;


    public void AddObjectToHand(GameObject GO)
    {
        if (inHandObject == null)
        {
            GO.transform.SetParent(hand.transform);
            GO.transform.position = hand.transform.position;
            inHandObject = GO;
            playerHoldSomething = true;
        }
    }

    public void PutObjectOnGround()
    {
        if (playerHoldSomething == true)
        {
            interactScript.PlaceObjectOnCursor(inHandObject);
            inHandObject = null;
            playerHoldSomething = false;
        }
    }



}
