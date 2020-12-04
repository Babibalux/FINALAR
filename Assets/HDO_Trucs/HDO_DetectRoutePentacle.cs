using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDO_DetectRoutePentacle : MonoBehaviour
{
    public bool detected = false;
    Collider box;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cursor"))
        {
            detected = true;
            box.enabled = false;
        }
    }
}
