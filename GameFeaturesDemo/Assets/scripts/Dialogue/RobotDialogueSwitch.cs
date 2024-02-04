using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDialogueSwitch : MonoBehaviour
{
    private RobotDialogueHolder RobotDialogue;
    private RobotDialogueMAnager Manager;

    public string[] dialogueLines;

    public string[] secondDialogueLines;

    public string[] ogdialogueLines = new string[1];
    public string[] ogdialogueLines2 = new string[1];




    void Start()
    {
        RobotDialogue = FindObjectOfType<RobotDialogueHolder>();

        Manager = FindObjectOfType<RobotDialogueMAnager>();

        ogdialogueLines[0] = secondDialogueLines[0];
        ogdialogueLines2[0] = dialogueLines[0];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "PlatformPlayer")
        {
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "PlatformPlayer")
        {
            RobotDialogue = FindObjectOfType<RobotDialogueHolder>();
            if (RobotDialogue != null)
            {

                if (RobotDialogue.dialogueLines != dialogueLines && RobotDialogue.secondDialogueLines != secondDialogueLines)
                {
                    secondDialogueLines[0] = ogdialogueLines[0];
                    dialogueLines[0] = ogdialogueLines2[0];

                    RobotDialogue.dialogueLines = dialogueLines;
                    RobotDialogue.secondDialogueLines = secondDialogueLines;
                    //  RobotDialogue.ogdialogueLines[0] = secondDialogueLines[0];

                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "PlatformPlayer")
        {
            RobotDialogue.onceOver = false;
            Manager.dialogueLines[0] = " ";
        }
    }

    private void OnDestroy()
    {
        if (RobotDialogue != null)
        {
            RobotDialogue.onceOver = false;
        }
        
    }
}
