using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_GlobalObjectScript : MonoBehaviour
{
    public GameObject player;
    public GameObject hand;
    public GameObject objectInHand;

    Collider collide;
    FCO_SpecificObjectScript specific;
    public bool canDoInteraction = false;
    bool isInTheHand = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collide = GetComponentInChildren<Collider>();
        if(GetComponent<FCO_SpecificObjectScript>())
        {
            canDoInteraction = true;
        }


        if(canDoInteraction && GetComponent<FCO_SpecificObjectScript>() != null)
        {
            specific = GetComponent<FCO_SpecificObjectScript>();
        }
    }

    public void UseTheObject(GameObject touchedObject)
    {
        if(canDoInteraction && isInTheHand)
        {
            specific.UseBehaviour(touchedObject, this.gameObject);
        }
    }

    public void TakeTheObject()
    {
        isInTheHand = true;
        transform.SetParent(hand.transform);
        transform.localPosition = new Vector3(0, 0, 0);
    }

    public void PlaceTheObject(Pose destination)
    {
        transform.SetParent(null);
        isInTheHand = false;
        transform.SetPositionAndRotation(destination.position, destination.rotation);
    }
}