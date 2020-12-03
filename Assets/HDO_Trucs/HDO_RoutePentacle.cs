using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDO_RoutePentacle : MonoBehaviour
{
    ParticleSystem particles;
    public HDO_Dessinage dessinage;
    public List<HDO_DetectRoutePentacle> route = null;
    public List<HDO_DetectRoutePentacle> chemin = null;
    int nextPoint;
    int iteration;
    bool pentacleFail = false;

    // Start is called before the first frame update
    void Start()
    {        
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
        dessinage = GameObject.Find("dessinage").GetComponent<HDO_Dessinage>();
    }

    // Update is called once per frame
    void Update()
    {
        DecideRouteOK();
    }

    void DecideRouteOK()
    {
        foreach(HDO_DetectRoutePentacle point in route)
        {
            if(iteration > 4)
            {
                iteration = 0;
            }
            if (point.detected)
            {
                chemin.Add(point);
                if(route[nextPoint] != route[iteration])
                {
                    pentacleFail = true;
                    iteration = -1;
                }
                else
                {
                    nextPoint = iteration + 1;
                }
                point.detected = false;

            }
            iteration++;
        }

        if(chemin.Count >= 5)
        {
            dessinage.dessinage = false;
            particles.Play();
        }
    }
}
