using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_ObjectInteract : MonoBehaviour
{
    public GameObject Hand;
    public LayerMask interact;
    public float touchHeight;
    public float touchWidth;

    Vector2 objectInHandTouchMin;
    Vector2 objectInHandTouchMax;

    void Start()
    {
        objectInHandTouchMin.x = Screen.width - touchHeight;
        objectInHandTouchMax.y = touchWidth;
    }

    void Update()
    {
        if(GetComponentInChildren<FCO_GlobalObjectScript>() && Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount > 0)
        {
            Hand.GetComponent<FCO_GlobalObjectScript>().PlaceTheObject(new Pose(new Vector3(0,0,0), this.transform.rotation));
        }
    }

    public bool ObjectInHandTouchCompare(Vector2 position)
    {
        bool isIn;

        if(position.x > objectInHandTouchMin.x &&
            position.y < objectInHandTouchMax.y)
        {
            isIn = true;
        }
        else
        {
            isIn = false;
        }

        return isIn;
    }
}
