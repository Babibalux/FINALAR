using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_GlobalObjectScript : MonoBehaviour
{
    public FCO_ItemsScriptableObjects itemSO;

    public enum ItemType { Ingredient, Buche, Bol, Mortier };
    public ItemType type;

    public string braseroTag;
    public string bolTag;
    public string mortierTag;
    public string puitsTag;

    public GameObject player;
    public GameObject objectInHand;

    public bool canDoInteraction = false;
    bool isInTheHand = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void UseBehaviour(GameObject touchedObject, GameObject equippedObject)
    {
        switch (type)
        {
            case ItemType.Ingredient:
                {
                    if (touchedObject.CompareTag(mortierTag))
                    {
                        PlaceAsSiblingOf(equippedObject, touchedObject);
                    }
                    else if (touchedObject.CompareTag(braseroTag))
                    {
                        if (itemSO.brulable)
                        {
                            //Instantiate<GameObject>(itemSO.burnedVersion, hand.transform).transform.SetPositionAndRotation(equippedObject.transform.position, equippedObject.transform.rotation);
                            //Destroy(equippedObject);
                        }
                    }
                    else if (touchedObject.CompareTag(puitsTag))
                    {
                        VerificationContentement();
                        Destroy(equippedObject);
                    }
                    else if (touchedObject.CompareTag(bolTag))
                    {
                        //Placer dans le bol
                    }
                    break;
                }
            case ItemType.Buche:
                {
                    if (touchedObject.CompareTag(braseroTag))
                    {
                        //Instantiate<GameObject>(itemSO.burnedVersion, hand.transform).transform.SetPositionAndRotation(equippedObject.transform.position, equippedObject.transform.rotation);
                        //Destroy(equippedObject);
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

    public void PlaceAsSiblingOf(GameObject objectToMove, GameObject newParent)
    {
        objectToMove.transform.SetParent(newParent.transform);
        //Retirer l'objet de la variable hand
        //Reset son transform local ?
    }

    public void ItemTransfer()
    {
        //Transférer les données de la liste de composants vers une autre
        //Vider la liste de composants du bol ou mortier en main
    }



}