using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDO_Dessinage : MonoBehaviour
{
    public TrailRenderer trail;
    public bool dessinage = true;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if(Input.touchCount > 0 && dessinage)
        {
            trail.emitting = true;
        }
        else
        {
            trail.emitting = false;
        }
        trail.time += Time.deltaTime;
    }
}
