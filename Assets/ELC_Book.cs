using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Book : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        this.transform.rotation = Quaternion.Inverse(GameObject.FindWithTag("Cursor").transform.rotation);
    }
    void Update()
    {
        cam = FindObjectOfType<Camera>();
        this.transform.localPosition = new Vector3(transform.localPosition.x, GameObject.FindWithTag("Puits").transform.localPosition.y, transform.localPosition.z);
        
    }
}
