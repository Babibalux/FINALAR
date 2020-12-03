using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDO_RoutePentacle : MonoBehaviour
{
    ParticleSystem particles;
    public HDO_Dessinage dessinage;
    Collider box;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        box = GetComponent<Collider>();
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cursor")
        {
            if (dessinage.dessinage && dessinage.trail.emitting)
            {
                particles.Play();
            }
        }
    }
}
