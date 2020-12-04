using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_GlobalObjectScript : MonoBehaviour
{
    public GameObject trucdanlbolTEST;

    public FCO_ItemsScriptableObjects itemSO;
    public GameObject cendres;
    MeshRenderer renderer;

    [System.NonSerialized] public ELC_hand hand;

    public enum ItemType { Ingredient, Buche, Bol, Mortier };
    public ItemType type;

    string braseroTag = "Brasero";
    string bolTag = "Bol";
    string mortierTag = "Mortier";
    string puitsTag = "Puits";

    [System.NonSerialized] public bool burned = false;
    bool isInTheHand = false;

    private void Start()
    {
        hand = FindObjectOfType<ELC_hand>();
        renderer = GetComponent<MeshRenderer>();
    }

    public void UseBehaviour(GameObject touchedObject, GameObject equippedObject)
    {
        switch (type)
        {
            case ItemType.Ingredient:
                {
                    if (touchedObject.CompareTag(mortierTag))
                    {
                        touchedObject.GetComponent<FCO_Bol>().PutInTheBowl(itemSO.ingredientType, burned);

                        GameObject instantruc = Instantiate<GameObject>(trucdanlbolTEST, touchedObject.transform);
                        instantruc.GetComponent<MeshFilter>().mesh = hand.inHandObject.GetComponent<MeshFilter>().mesh;
                        instantruc.GetComponent<MeshRenderer>().material = hand.inHandObject.GetComponent<MeshRenderer>().material;
                        instantruc.transform.localPosition = Vector3.zero;

                        hand.DestroyHandObject();
                    }
                    else if (touchedObject.CompareTag(braseroTag))
                    {
                        if (itemSO.brulable)
                        {
                            burned = true;
                            renderer.material = itemSO.burnedVersion;
                        }
                    }
                    else if (touchedObject.CompareTag(puitsTag))
                    {
                        List<FCO_ItemsScriptableObjects.IngredientType> inHoleType = new List<FCO_ItemsScriptableObjects.IngredientType>();
                        inHoleType.Add(itemSO.ingredientType);
                        List<bool> inHoleState = new List<bool>();
                        inHoleState.Add(burned);

                        hand.GetComponent<FCO_ContentementManagement>().contentement = touchedObject.GetComponent<FCO_Hole>().Offrande(inHoleType, inHoleState);

                        hand.DestroyHandObject();
                    }
                    break;
                }
            case ItemType.Buche:
                {
                    if (touchedObject.CompareTag(braseroTag))
                    {
                        hand.DestroyHandObject();

                        GameObject cendresTemporaires = Instantiate(cendres);
                        hand.AddObjectToHand(cendresTemporaires);
                    }
                    else if (touchedObject.CompareTag(puitsTag))
                    {
                        hand.GetComponent<FCO_ContentementManagement>().contentement = touchedObject.GetComponent<FCO_Hole>().Offrande(new List<FCO_ItemsScriptableObjects.IngredientType>(0), new List<bool>(0));
                        hand.DestroyHandObject();
                    }
                    break;
                }
            case ItemType.Bol:
                {
                    if (touchedObject.CompareTag(puitsTag))
                    {
                        hand.GetComponent<FCO_ContentementManagement>().contentement = touchedObject.GetComponent<FCO_Hole>().Offrande(GetComponent<FCO_Bol>().typeContenu, GetComponent<FCO_Bol>().etatContenu);
                        hand.inHandObject.GetComponent<MeshRenderer>().material = itemSO.burnedVersion;
                        hand.DestroyHandObject();
                    }
                    break;
                }
            case ItemType.Mortier:
                {
                    if (touchedObject.CompareTag(bolTag))
                    {
                        GetComponent<FCO_Bol>().TransferContent(touchedObject.GetComponent<FCO_Bol>().typeContenu, touchedObject.GetComponent<FCO_Bol>().etatContenu, touchedObject);
                    }
                    break;
                }
        }
    }
}