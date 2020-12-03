using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_SpecificObjectScript : MonoBehaviour
{
    public enum ItemType {Ingredient, Recipient, None};
    public ItemType type;

    public bool burnable = false;
    [System.NonSerialized] public bool burned = false;
    public Material burnedMaterial;

    public void UseBehaviour(GameObject touchedObject)
    {
        switch (type)
        {
            case ItemType.Ingredient:
                {
                    if(touchedObject.GetComponent<FCO_Brazero>() != null && burnable && !GetComponent<FCO_IAmABuche>() && !burned)
                    {
                        burned = true;
                        GetComponent<MeshRenderer>().material = GetComponent<FCO_SpecificObjectScript>().burnedMaterial;
                    }
                    else if (touchedObject.GetComponent<FCO_Brazero>() != null && burnable && GetComponent<FCO_IAmABuche>() && !burned)
                    {

                        GetComponent<FCO_IAmABuche>().burned = true;
                        GetComponent<FCO_SpecificObjectScript>().burned = true;
                        gameObject.GetComponent<MeshRenderer>().material = GetComponent<FCO_SpecificObjectScript>().burnedMaterial;

                        GetComponent<MeshFilter>().mesh = GetComponent<FCO_IAmABuche>().cendre3D;
                    }

                    break;
                }
            case ItemType.Recipient:
                {

                    break;
                }
        }
    }

}