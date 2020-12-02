using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_SpecificObjectScript : MonoBehaviour
{
    public enum ItemType {Ingredient, Recipient, None};
    public ItemType type;

    public bool burnable = false;

    public void UseBehaviour()
    {
        switch (type)
        {
            case ItemType.Ingredient:
                {

                    break;
                }
            case ItemType.Recipient:
                {

                    break;
                }
        }
    }

}
