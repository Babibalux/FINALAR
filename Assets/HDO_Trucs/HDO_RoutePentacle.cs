using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDO_RoutePentacle : MonoBehaviour
{
    ParticleSystem particles;
    public HDO_Dessinage dessinage;
    HDO_Dialogues dialogues;
    public List<HDO_DetectRoutePentacle> route = null;
    public List<HDO_DetectRoutePentacle> chemin = null;
    public List<GameObject> objectsToActivate = new List<GameObject>();
    int nextPointR, nextPointL;
    int iteration;
    public bool pentacleFail = false, checkPentacle = true, pentacleDone = false;

    public bool GoodDessin;

    int routeType = -1;
    int checkedRoute = 0;
    public float timeForPentacle;

    // Start is called before the first frame update
    void Start()
    {        
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
        dessinage = GameObject.FindObjectOfType<HDO_Dessinage>();
        dialogues = GameObject.FindObjectOfType<HDO_Dialogues>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkPentacle) 
            DecideRouteOK(); 
        
        if(pentacleDone) 
            PentacleEnded();

        timeForPentacle -= Time.deltaTime;

        if(timeForPentacle <= 0)
        {
            pentacleFail = true;
            PentacleEnded();
        }

        foreach(HDO_DetectRoutePentacle point in route)
        {
            if (point.hasDetected) checkedRoute++;
            else checkedRoute = 0;
        }

        if (checkedRoute == 5) pentacleDone = true;
        
    }

    void PentacleEnded()
    {
        foreach (GameObject GO in objectsToActivate)
        {
            GO.SetActive(true);
        }
        if (pentacleFail)
        {
            dialogues.shouldWrite = true;
            dialogues.sequence = 4;
        }
        else
        {
            dialogues.shouldWrite = true;
            dialogues.sequence = 3;
        }
        dessinage.dessinage = false;

        if (pentacleFail)
        {
            Destroy(gameObject);
            GoodDessin = false;
        }
        else GoodDessin = true;
        particles.Play();
        pentacleDone = false;
    }

    void DecideRouteOK()
    {
        if(routeType == -1)
        {
            if (route[0].hasDetected)
            {
                chemin.Add(route[0]);
                nextPointL = 4;
                nextPointR = 1;
                routeType = 0;
            }
            if (route[1].hasDetected)
            {
                chemin.Add(route[1]);
                nextPointL = 2;
                nextPointR = 0;
                routeType = 1;
            }
            if (route[2].hasDetected)
            {
                chemin.Add(route[2]);
                nextPointL = 3;
                nextPointR = 2;
                routeType = 2;
            }
            if (route[3].hasDetected)
            {
                chemin.Add(route[3]);
                nextPointL = 4;
                nextPointR = 2;
                routeType = 3;
            }
            if (route[4].hasDetected)
            {
                chemin.Add(route[4]);
                nextPointL = 3;
                nextPointR = 0;
                routeType = 4;
            }
        }
        else
        {
            if(chemin.Count >= 5)
            {
                pentacleDone = true;
            }

            foreach (HDO_DetectRoutePentacle point in route)
            {
                if (point.hasDetected)
                {
                    if (!(chemin.Contains(point))) chemin.Add(point);
                    else
                    {
                        return;
                    }
                    point.detected = false;
                    if (point == route[nextPointL] || point == route[nextPointR])
                    {
                       
                        if (point == route[1])
                        {
                            nextPointL = 2;
                            nextPointR = 0;
                        }
                        if (point == route[2])
                        {
                            nextPointL = 3;
                            nextPointR = 2;
                        }
                        if (point == route[3])
                        {
                            nextPointL = 2;
                            nextPointR = 4;
                        }
                        if (point == route[4])
                        {
                            nextPointL = 3;
                            nextPointR = 0;
                        }
                        if (point == route[0])
                        {
                            nextPointL = 4;
                            nextPointR = 1;
                        }
                    }
                    else
                    {
                        pentacleFail = true;
                        checkPentacle = false;
                        pentacleDone = true;
                    }
                }
            }
        }
        
    }
}
