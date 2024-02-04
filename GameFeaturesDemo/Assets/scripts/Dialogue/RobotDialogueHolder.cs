using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotDialogueHolder : MonoBehaviour
{

    private RobotDialogueMAnager dMan;
    private DialogueMAnager dManOG;


    // what image shows up while talking
    public Sprite image;

    public AudioSource click;


    public string[] dialogueLines;

    public string[] secondDialogueLines;

     public PlayerHealthManager health;

    // To fix a minor issue
    private bool inZone;

    //Check if the dialogue is played once
    [HideInInspector]
    public bool onceOver = false;

    // to fix an issue with the letters from the previous line still beeing rendered

    
    private string[] ogdialogueLines = new string[1];
    
    private string[] ogdialogueLines2 = new string[1];




    void Start()
    {
        dMan = FindObjectOfType<RobotDialogueMAnager>();
        dManOG = FindObjectOfType<DialogueMAnager>();
        health = FindObjectOfType<PlayerHealthManager>();

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "PlatformPlayer")
        {
            inZone = true;
        }


        // dMan = FindObjectOfType<DialogueMAnager>();

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "PlatformPlayer")
        {
            inZone = false;
        }
    }
    private void Update()
    {

        if(dialogueLines[0] != " ")
        {
            ogdialogueLines2[0] = dialogueLines[0];
        }

        if (secondDialogueLines[0] != " ")
        {
            ogdialogueLines[0] = secondDialogueLines[0];
            
        }

        if (health != null)
        {
            if (health.playerCurrentHealth <= 0)
            {
                dMan.EndDialogue();
            }
        }


        if (Input.GetKeyDown(KeyCode.F) && inZone == true && dManOG.dialogueActive == false)
        {

            if (click != null)
            {
                click.Play();
            }


            if (!dMan.dialogueActive && onceOver == false)
            {
                dMan.dialogueLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();

                // faiding the image if there is no image to use in this dialogue
                if (image == false)
                {
                    dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                }
                else
                {
                    dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                }
                dMan.dImageToUse.GetComponent<Image>().sprite = image;
                onceOver = true;
            }
            if (!dMan.dialogueActive && onceOver == true)
            {
                secondDialogueLines[0] = ogdialogueLines[0];
                dialogueLines[0] = ogdialogueLines2[0];
                dMan.dialogueLines = secondDialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();

                if (image == false)
                {
                    dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                }
                else
                {
                    dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                }

                dMan.dImageToUse.GetComponent<Image>().sprite = image;
            }
        }
    }
}
