using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_Bol : MonoBehaviour
{
    public List<FCO_ItemsScriptableObjects.IngredientType> typeContenu = new List<FCO_ItemsScriptableObjects.IngredientType>();
    public List<bool> etatContenu = new List<bool>();

    public void PutInTheBowl(FCO_ItemsScriptableObjects.IngredientType type, bool etat)
    {
        typeContenu.Add(type);
        etatContenu.Add(etat);

        
    }

    public void TransferContent(List<FCO_ItemsScriptableObjects.IngredientType> destinationType, List<bool> destinationState)
    {
        for (int i = 0; i < typeContenu.Count; i++)
        {
            destinationType.Add(typeContenu[i]);
            destinationState.Add(etatContenu[i]);
        }

        typeContenu = new List<FCO_ItemsScriptableObjects.IngredientType>();
        etatContenu = new List<bool>();
    }
}
