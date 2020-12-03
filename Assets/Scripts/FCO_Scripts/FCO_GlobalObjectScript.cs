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
    bool isInTheHand = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collide = GetComponentInChildren<Collider>();

        if(canDoInteraction && GetComponent<FCO_SpecificObjectScript>() != null)
        {
            specific = GetComponent<FCO_SpecificObjectScript>();
        }
    }

    public void UseTheObject()
    {
        if(canDoInteraction && isInTheHand)
        {
            specific.UseBehaviour();
        }
    }

    public void TakeTheObject()
    {
        isInTheHand = true;
        Instantiate(this.gameObject, hand.transform).GetComponent<FCO_GlobalObjectScript>().isInTheHand = true;
        Destroy(this.gameObject);
    }

    public void PlaceTheObject(Pose destination)
    {
        Instantiate(this.gameObject, destination.position, destination.rotation).GetComponent<FCO_GlobalObjectScript>().isInTheHand = false;
        Destroy(this.gameObject);
    }
}