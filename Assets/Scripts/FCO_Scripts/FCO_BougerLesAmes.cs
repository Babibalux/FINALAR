using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_BougerLesAmes : MonoBehaviour
{
    FCO_GlobalObjectScript global;

    public float speed;
    private float waitTime;
    public float startWaitTime;
    bool isInMovement = true;

    public Transform moveSpots;
    Vector3 startPosition;

    public Vector3 leftUpCorner;
    public Vector3 rightDownCorner;

    void Start()
    {
        global = GetComponent<FCO_GlobalObjectScript>();
        waitTime = startWaitTime;
        startPosition = moveSpots.position;
        moveSpots.position = new Vector3(Random.Range(leftUpCorner.x, rightDownCorner.x), Random.Range(leftUpCorner.y, rightDownCorner.y), Random.Range(leftUpCorner.z, rightDownCorner.z));
    }

    void Update()
    {
        if(global.hand.inHandObject != this.gameObject)
        {
            if (isInMovement)
            {
                if (Vector3.Distance(transform.position, moveSpots.position) < 0.2f)
                {
                    IdleStateEnter();
                    Debug.Log("IdleEnter");
                }
                else
                {
                    Move();
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    isInMovement = true;
                }
            }
        }        
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);
        transform.LookAt(moveSpots);
    }

    public void IdleStateEnter()
    {
        isInMovement = false;
        waitTime = startWaitTime;
        moveSpots.position = new Vector3(Random.Range(leftUpCorner.x, rightDownCorner.x), Random.Range(leftUpCorner.y, rightDownCorner.y), Random.Range(leftUpCorner.z, rightDownCorner.z));
    }
}
