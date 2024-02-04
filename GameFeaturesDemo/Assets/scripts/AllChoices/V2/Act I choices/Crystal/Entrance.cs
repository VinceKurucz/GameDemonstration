using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{

    private DialogueMAnager dMan;



    private Decisions decision;

    public GameObject entrance;
    public GameObject Coll;

    public SpriteRenderer door;
    public Sprite door2;

    public Entrance script;

    // what image shows up while talking
    public Sprite image;


    public string[] dialogueLines;


    public string[] secondDialogueLines;

    public string[] secondDialogueLines2;

    // To fix a minor issue
    private bool inZone;

    //Check if the dialogue is played once
    private bool onceOver = false;

    // to fix an issue with the letters from the previous line still beeing rendered
    private string[] ogdialogueLines = new string[1];
    private string[] ogdialogueLines2 = new string[1];

    void Start()
    {
        dMan = FindObjectOfType<DialogueMAnager>();
        decision = FindObjectOfType<Decisions>();
        if(decision.EnterWithCrystal == true)
        {
            entrance.SetActive(true);
            Coll.SetActive(false);
            door.sprite = door2;
            script.enabled = false;
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
            ogdialogueLines2[0] = secondDialogueLines2[0];
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
            }

            if (!dMan.dialogueActive && onceOver == true && decision.CrystalPickedUp == true)
            {
                secondDialogueLines[0] = ogdialogueLines[0];
                dMan.dialogueLines = secondDialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                



                entrance.SetActive(true);
                Coll.SetActive(false);
                door.sprite = door2;
                decision.EnterWithCrystal = true;

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

            if (!dMan.dialogueActive && onceOver == true && decision.CrystalPickedUp == false )
            {
                secondDialogueLines2[0] = ogdialogueLines2[0];
                dMan.dialogueLines = secondDialogueLines2;
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
