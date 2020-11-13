using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dialogueManager;

    // multiple line dialogue
    public string[] dialogueLines;
 
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Legion")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //dialogueManager.ShowBox(dialogue); // single line dialogue

                // multiple line dialogue
                if (!dialogueManager.dialogueActive)  // avoid opening dialogue box again instead of skip lines
                {
                    dialogueManager.dialogueLines = dialogueLines;
                    dialogueManager.currentLine = 0;
                    dialogueManager.ShowDialogue();
                }

                // avoid movement when dialogue
                if(transform.parent.GetComponent<LadyMovement>() != null)
                {
                    transform.parent.GetComponent<LadyMovement>().canMove = false;
                }
            }
        }
    }
}
