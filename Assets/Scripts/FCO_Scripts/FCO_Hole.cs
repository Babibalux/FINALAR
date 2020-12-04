using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_Hole : MonoBehaviour
{
    public int positiveValue;
    public int negativeValue;

    public int Offrande(List<FCO_ItemsScriptableObjects.IngredientType> types, List<bool> etats)
    {
        if (types.Count == 1)
        {
            if (types[0] == FCO_ItemsScriptableObjects.IngredientType.Ame && etats[0] == true)
            {
                return positiveValue;
            }
            else return negativeValue;
        }
        else if (types.Count == 2)
        {
            FCO_ItemsScriptableObjects.IngredientType element1Type = types[0];
            bool element1State = etats[0];
            FCO_ItemsScriptableObjects.IngredientType element2Type = types[1];
            bool element2State = etats[1];

            if ((element1Type == FCO_ItemsScriptableObjects.IngredientType.Ame && element2Type == FCO_ItemsScriptableObjects.IngredientType.Ame) &&
                (element1State == false && element2State == false))
            {
                return positiveValue;
            }
            else return negativeValue;
        }
        else if (types.Count == 3)
        {
            if (SearchCorrespondingIn(types, etats, FCO_ItemsScriptableObjects.IngredientType.Fleur, false) && SearchCorrespondingIn(types, etats, FCO_ItemsScriptableObjects.IngredientType.Sel, false))
            {
                int nbr = 0;
                for (int i = 0; i < types.Count; i++)
                {
                    if (types[i] == FCO_ItemsScriptableObjects.IngredientType.Fleur && etats[i] == false)
                    {
                        nbr++;
                    }
                }

                if (nbr == 2)
                {
                    return positiveValue;
                } 
                return negativeValue;
            }
            if (SearchCorrespondingIn(types, etats, FCO_ItemsScriptableObjects.IngredientType.Ame, true) && SearchCorrespondingIn(types, etats, FCO_ItemsScriptableObjects.IngredientType.Sel, false))
            {
                int nbr = 0;
                for (int i = 0; i < types.Count; i++)
                {
                    if (types[i] == FCO_ItemsScriptableObjects.IngredientType.Ame && etats[i] == true)
                    {
                        nbr++;
                    }
                }

                if (nbr == 2)
                {
                    return positiveValue;
                }
                return negativeValue;
            }
            if (SearchCorrespondingIn(types, etats, FCO_ItemsScriptableObjects.IngredientType.Cendres, false) && SearchCorrespondingIn(types, etats, FCO_ItemsScriptableObjects.IngredientType.Fleur, false))
            {
                int nbr = 0;
                for (int i = 0; i < types.Count; i++)
                {
                    if (types[i] == FCO_ItemsScriptableObjects.IngredientType.Cendres && etats[i] == false)
                    {
                        nbr++;
                    }
                }

                if (nbr == 2)
                {
                    return positiveValue;
                }
                return negativeValue;
            }
            
            return negativeValue;
        }
        else return 0;
    }

    public bool SearchCorrespondingIn(List<FCO_ItemsScriptableObjects.IngredientType> checkedType, List<bool> checkedState, FCO_ItemsScriptableObjects.IngredientType researchedType, bool researchedState)
    {
        bool isVerified = false;

        for (int i = 0; i < checkedState.Count; i++)
        {
            if (checkedType[i] == researchedType && checkedState[i] == researchedState)
            {
                isVerified = true;
            }
        }
        if (isVerified) return true;
        else return false;
    }

}
