using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public QuestObject[] quests;
    public bool[] questCompleted;

    // show message when starting/ending quest
    public DialogueManager theDM;

    // show message when picking item
    public string itemCollected;

    // show message when enemy killed
    public string enemyKilled;
    
    	
	void Start () {
        questCompleted = new bool[quests.Length];        
		
	}
		
	void Update () {
		
	}

    // show message when starting/ending quest
    public void ShowQuestText(string questText)
    {
        theDM.dialogueLines = new string[1];
        theDM.dialogueLines[0] = questText;
        theDM.currentLine = 0;
        theDM.ShowDialogue();
    }
}
