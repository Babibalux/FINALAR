using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class FCO_ItemsScriptableObjects : ScriptableObject
{
    public enum IngredientType {None, Cendres, Sel, Fleur, BougieNoire, BougieVerte, BougieViolette, BougieBlanche, BougieRouge, Ame};
    public IngredientType ingredientType;

    public bool brulable;
    public GameObject burnedVersion;
}
