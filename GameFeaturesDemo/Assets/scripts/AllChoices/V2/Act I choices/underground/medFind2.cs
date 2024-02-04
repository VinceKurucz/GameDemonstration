using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class medFind2 : MonoBehaviour
{
    private DialogueMAnager dMan;


    // what image shows up while talking
    public Sprite image;


    public string[] dialogueLines;

    public string[] secondDialogueLines;

    private PlayerHealthManager med2;
    private Decisions dec;
    private medFind ez;

    // To fix a minor issue
    private bool inZone;

    //Check if the dialogue is played once
    private bool onceOver = false;

    // to fix an issue with the letters from the previous line still beeing rendered
    private string[] ogdialogueLines = new string[1];

    void Start()
    {
        dMan = FindObjectOfType<DialogueMAnager>();
        med2= FindObjectOfType<PlayerHealthManager>();
        ez = FindObjectOfType<medFind>();
        dec = FindObjectOfType<Decisions>();
        if (dec.Med2 == true)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inZone = true;
        }
        dMan = FindObjectOfType<DialogueMAnager>();


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inZone = false;
        }
    }
    private void Update()
    {

        if (dialogueLines[0] != " ")
        {
            ogdialogueLines[0] = secondDialogueLines[0];
        }



        if (Input.GetButtonDown("Submit") && inZone == true)
        {


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

                if (dec.Med2 == false)
                {
                    med2.numberOfMeds++;
                    dec.Med2 = true;
                    gameObject.SetActive(false);
                }

            }
            if (!dMan.dialogueActive && onceOver == true)
            {
                secondDialogueLines[0] = ogdialogueLines[0];
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
