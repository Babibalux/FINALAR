using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_Brazero : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item") && other.GetComponent<FCO_IAmABuche>() && !other.GetComponent<FCO_IAmABuche>().burned)
        {
            other.GetComponent<FCO_IAmABuche>().burned = true;
            other.GetComponent<FCO_SpecificObjectScript>().burned = true;
            other.gameObject.GetComponent<MeshRenderer>().material = other.GetComponent<FCO_SpecificObjectScript>().burnedMaterial;

            other.GetComponent<MeshFilter>().mesh = other.GetComponent<FCO_IAmABuche>().cendre3D;
        }
        else if(other.CompareTag("Item") && other.GetComponent<FCO_SpecificObjectScript>() && !other.GetComponent<FCO_SpecificObjectScript>().burned)
        {
            other.GetComponent<FCO_SpecificObjectScript>().burned = true;
            other.gameObject.GetComponent<MeshRenderer>().material = other.GetComponent<FCO_SpecificObjectScript>().burnedMaterial;
        }
    }
}
