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
    public List<string> espaceInvoqued = null;
    public List<string> correctPentacle = null;
    public List<string> ratedPentacle = null;

    public bool shouldWrite = true;
    


    void Start()
    {
        text = btn.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        ChooseList();

        if (shouldWrite)
        {
            btn.gameObject.SetActive(true);
            text.text = usedList[sentenceNumber];
        }
        else
        {
            btn.gameObject.SetActive(false);
            text.text = "";
        }


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
        else if(sequence == 2)
        {
            usedList = espaceInvoqued;
        }
        else if(sequence == 3)
        {
            usedList = correctPentacle;
        }
        else if(sequence == 4)
        {
            usedList = ratedPentacle;
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
