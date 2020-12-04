using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDO_DialogueUpdateBoard : MonoBehaviour
{
    HDO_Dialogues dialogues;

    // Start is called before the first frame update
    void Start()
    {
        dialogues = GameObject.FindObjectOfType<HDO_Dialogues>();
        dialogues.sequence = 2;
        dialogues.shouldWrite = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
