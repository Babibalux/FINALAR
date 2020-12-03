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
    public float touchRange;

    Camera cam;
    Vector2 objectInHandTouchMin;
    Vector2 objectInHandTouchMax;
    private ARRaycastManager arRaycastManager;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        hand = GameObject.FindGameObjectWithTag("Hand");
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if(GetComponentInChildren<FCO_GlobalObjectScript>() != null)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount > 0)
            {
                GameObject touchedObject = TouchRaycast(cam.ScreenToWorldPoint(Input.GetTouch(0).position), interact).collider.gameObject;

                if (touchedObject != GetComponentInChildren<FCO_GlobalObjectScript>().gameObject && hand.GetComponentInChildren<FCO_SpecificObjectScript>() == true)
                {
                    hand.GetComponentInChildren<FCO_GlobalObjectScript>().UseTheObject(touchedObject);
                }
            }
        }
        else if(hand.GetComponentInChildren<FCO_GlobalObjectScript>() == null)
        {
            Collider touchedObject = TouchRaycast(cam.ScreenToWorldPoint(Input.GetTouch(0).position), interact).collider;

            if (Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount > 0 && touchedObject != null)
            {
                TouchRaycast(cam.ScreenToWorldPoint(Input.GetTouch(0).position), interact).collider.GetComponent<FCO_GlobalObjectScript>().TakeTheObject();
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
        Ray ray = cam.ScreenPointToRay(touchPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,touchRange, layerMask))
        {
            return hit;
        }
        else
        {
            return hit;
        }        
    }
}
