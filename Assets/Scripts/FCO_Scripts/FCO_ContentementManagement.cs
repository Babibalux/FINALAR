using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCO_ContentementManagement : MonoBehaviour
{
    public int contentement;
    HDO_Dialogues dialogues;

    private void Start()
    {
        dialogues = GameObject.FindObjectOfType<HDO_Dialogues>();
    }

    public void Invocation()
    {
        if(contentement >= 0)
        {
            //pliz déplacer ça A LINTERIEUR du moment ou on INVOQUE EL DEMONO DE LA CASA
            dialogues.sequence = 5;
            dialogues.shouldWrite = true;
            //invoquer beau démon
        }
        else
        {
            //pliz déplacer ça A LINTERIEUR du moment ou on INVOQUE EL DEMONO DE LA CASA
            dialogues.sequence = 6;
            dialogues.shouldWrite = true;
            //invoquer moche démon
        }
    }
}
