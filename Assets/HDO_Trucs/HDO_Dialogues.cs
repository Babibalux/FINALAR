using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HDO_Dialogues : MonoBehaviour
{
    Text text;
    public Button btn;
    public int sentenceNumber = 0;
    public int sequence = 0;
    public int numberOfSequences;

    public List<string> usedList = null;

    public List<string> introduction = null;
    public List<string> initialisation = null;
    


    void Start()
    {
        text = btn.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        ChooseList();
        text.text = usedList[sentenceNumber];

        
    }

    void ChooseList()
    {
        if (sequence == 0)
        {
            usedList = introduction;
        }
        else if(sequence == 1)
        {
            usedList = initialisation;
        }
    }

    public void ChangeDialogue()
    {
        if (sentenceNumber >= usedList.Count - 1)
        {
            sequence += 1;
            Debug.Log("samer");
            sentenceNumber = -1;
        }

        sentenceNumber += 1;

        

        if(sequence > numberOfSequences - 1)
        {
            sequence = 0;
            Debug.Log("no more dialogues");
        }
    }

    
}
