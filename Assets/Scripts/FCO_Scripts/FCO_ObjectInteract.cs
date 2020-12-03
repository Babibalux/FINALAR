using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class FCO_ObjectInteract : MonoBehaviour
{
    public GameObject hand;
    public GameObject cursor;
    public LayerMask interact;
    public LayerMask brazero;

    Camera cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        hand = GameObject.FindGameObjectWithTag("Hand");
    }

    void Update()
    {
        if(hand.transform.childCount >= 2)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount > 0)
            {
                

                if (hand.GetComponentInChildren<FCO_SpecificObjectScript>() == true)
                {
                    GameObject touchedObject = TouchRaycast(Input.GetTouch(0).position, interact).collider.gameObject;

                    if(touchedObject != null && !touchedObject.GetComponentInChildren<FCO_GlobalObjectScript>()) hand.GetComponentInChildren<FCO_GlobalObjectScript>().UseTheObject(touchedObject);
                }               

                if (hand.GetComponentInChildren<FCO_SpecificObjectScript>() == true)
                {
                    GameObject touchedBrazero = TouchRaycast(Input.GetTouch(0).position, brazero).collider.gameObject;

                    if (touchedBrazero != null) hand.GetComponentInChildren<FCO_GlobalObjectScript>().UseTheObject(touchedBrazero);
                }
            }
        }
        else
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount > 0)
            {
                Collider touchedObject = TouchRaycast(Input.GetTouch(0).position, interact).collider;
                if (touchedObject != null) touchedObject.GetComponent<FCO_GlobalObjectScript>().TakeTheObject();
            }
        }
    }

    public void PlaceTheObject()
    {
        if(hand.GetComponentInChildren<FCO_GlobalObjectScript>() != null)
        {
            hand.GetComponentInChildren<FCO_GlobalObjectScript>().PlaceTheObject(new Pose(cursor.transform.position, cursor.transform.rotation));
        }
    }

    public RaycastHit TouchRaycast(Vector3 touchPosition, LayerMask layerMask)
    {
        Ray ray = Camera.current.ScreenPointToRay(touchPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            return hit;
        }
        else
        {
            return hit;
        }
    }
}
