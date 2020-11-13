using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBox;
    public Text dialogueText;
    public bool dialogueActive;

    // multiple line dialogue
    public string[] dialogueLines;
    public int currentLine;

    // avoid movement when dialogue
    private LegionController theLegion;
    	
	void Start () {
        // avoid movement when dialogue
        theLegion = FindObjectOfType<LegionController>();
		
	}
		
	void Update () {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            //dialogueBox.SetActive(false);  // single line dialogue
            //dialogueActive = false;        // single line dialogue

            // multiple line dialogue
            currentLine++;
        }		

        // multiple line dialogue
        if(currentLine >= dialogueLines.Length)
        {
            dialogueBox.SetActive(false);  
            dialogueActive = false;
            currentLine = 0;

            // allow movement after dialogue
            theLegion.canMove = true;
        }
        dialogueText.text = dialogueLines[currentLine];
    }

    // single line dialogue
    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
    }

    // multiple line dialogue
    public void ShowDialogue()
    {
        dialogueActive = true;
        dialogueBox.SetActive(true);

        // avoid movement when dialogue
        theLegion.canMove = false;
    }
}
