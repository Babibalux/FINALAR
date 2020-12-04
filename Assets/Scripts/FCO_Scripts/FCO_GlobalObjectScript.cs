using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_GlobalObjectScript : MonoBehaviour
{
    public GameObject trucdanlbolTEST;

    public FCO_ItemsScriptableObjects itemSO;
    public GameObject cendres;
    MeshRenderer renderer;

    ELC_hand hand;

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
                        //Donner contenu à Mortier
                        //Retirer objet de la main
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
                        VerificationContentement();
                        Destroy(equippedObject);
                    }
                    else if (touchedObject.CompareTag(bolTag))
                    {
                        touchedObject.GetComponent<FCO_Bol>().PutInTheBowl(itemSO.ingredientType, burned);

                        GameObject instantruc = Instantiate<GameObject>(trucdanlbolTEST, touchedObject.transform);
                        instantruc.GetComponent<MeshFilter>().mesh = hand.inHandObject.GetComponent<MeshFilter>().mesh;
                        instantruc.transform.localPosition = Vector3.zero;

                        hand.DestroyHandObject();
                    }
                    break;
                }
            case ItemType.Buche:
                {
                    if (touchedObject.CompareTag(braseroTag))
                    {
                        hand.PutObjectOnGround();
                        GameObject cendresTemporaires = Instantiate(cendres);
                        hand.AddObjectToHand(cendresTemporaires);
                    }
                    else if (touchedObject.CompareTag(puitsTag))
                    {
                        VerificationContentement();
                        Destroy(equippedObject);
                    }
                    break;
                }
            case ItemType.Bol:
                {
                    if (touchedObject.CompareTag(puitsTag))
                    {
                        VerificationContentement();
                        //retirer le contenu du bol
                    }
                    break;
                }
            case ItemType.Mortier:
                {
                    if (touchedObject.CompareTag(puitsTag))
                    {
                        VerificationContentement();
                        //retirer le contenu du mortier
                    }
                    else if (touchedObject.CompareTag(bolTag))
                    {
                        //donner au bol le contenu du mortier
                        //retirer le contenu du mortier
                    }
                    break;
                }
        }
    }

    public void VerificationContentement()
    {

    }

    public void ItemTransfer()
    {
        //Transférer les données de la liste de composants vers une autre
        //Vider la liste de composants du bol ou mortier en main
    }
}