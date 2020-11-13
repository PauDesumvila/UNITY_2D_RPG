using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

    public int questNumber;
    public QuestManager theQM;

    // show message when starting/ending quest
    public string startText;
    public string endText;

    // for item quests
    public bool isItemQuest;
    public string targetItem;

    // for hunt enemy quest
    public bool isEnemyQuest;
    public string targetEnemy;
    public int enemiesToKill;
    private int enemyKillCounter;

    void Start () {
		
	}
		
	void Update () {
        // for item quests
        if (isItemQuest)
        {
            if(theQM.itemCollected == targetItem)
            {
                theQM.itemCollected = null;
                EndQuest();
            }
        }

        // for hunt enemy quest
        if (isEnemyQuest)
        {
            if(theQM.enemyKilled == targetEnemy)
            {
                theQM.enemyKilled = null;
                enemyKillCounter++;
            }

            if(enemyKillCounter >= enemiesToKill)
            {
                EndQuest();
            }
        }

    }

    public void StartQuest()
    {
        // show message when starting quest
        theQM.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        // show message when ending quest
        theQM.ShowQuestText(endText);

        theQM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}
