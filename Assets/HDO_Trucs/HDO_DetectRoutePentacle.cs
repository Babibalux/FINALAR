﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDO_DetectRoutePentacle : MonoBehaviour
{
    public bool detected = false, hasDetected = false;
    HDO_Dessinage dessinage;
    ParticleSystem particles;
    Collider box;
    Rigidbody rb;
    float waitStart = 2;

    // Start is called before the first frame update
    void Start()
    {
        dessinage = GameObject.Find("dessinage").GetComponent<HDO_Dessinage>();
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
        box = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        waitStart -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cursor") && !hasDetected && dessinage.trail.emitting && waitStart <=0)
        {
            detected = true;
            particles.Play();
            hasDetected = true;
            box.enabled = false;
        }
    }
}
