using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaveFungus : MonoBehaviour
{
    //idk what is this, but Im afraid to delete it
    public string Dialogue;

    private DialogueMAnager dMan;
    private v2ChoiceManager cMan;

    //checking if the choice is made
    private bool cmade;

    // what image shows up while talking
    public Sprite image;

    //Lines Before the choice
    public string[] dialogueLines;

    // Lines after the choice

    public string[] CdialogueLines1;
    //text to show after the choice is made and once over (option1)
    public string[] CdialogueLines1_2;

    public string[] CdialogueLines2;
    //- || - (option2)
    public string[] CdialogueLines2_2;

    //Lines if the player has no choice
    public string[] NoChoiceLines1;
    public string[] NoChoiceLines2;

    //explained in an other script
    private string[] ogdialogueLines = new string[1];
    private string[] ogdialogueLines2 = new string[1];
    private string[] NoogdialogueLines = new string[1];

    // To fix a minor issue
    private bool inZone;

    // what choice did the player made
    private float whatChoice;
    private float Nochoice;

    // text to show up in the choicebox
    public string buttom1Text;
    public string buttom2Text;
    public string choiceText;

    private Decisions dec;

    void Start()
    {
        dMan = FindObjectOfType<DialogueMAnager>();
        cMan = FindObjectOfType<v2ChoiceManager>();
        dec = FindObjectOfType<Decisions>();
        ogdialogueLines[0] = CdialogueLines1_2[0];
        ogdialogueLines2[0] = CdialogueLines2_2[0];
        NoogdialogueLines[0] = NoChoiceLines2[0];
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inZone = false;
        }
    }
    //I cant even explain at this point
    private void Update()
    {

        if (dec.GaveFungus == false && dec.KeepFungus == false)
        {
            if (Input.GetButtonDown("Submit") && inZone == true)
            {

                if (dMan.dialogueActive == false && cmade == false)
                {
                    dMan.dialogueLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();

                    if (image == false)
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    }
                    else
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(0.8649376f, 0.8679245f, 0.741011f, 1f);
                    }
                    dMan.dImageToUse.GetComponent<Image>().sprite = image;

                }
                if (dMan.currentLine + 1 == dialogueLines.Length && cmade == false && dec.FungusPickedUp == true)
                {
                    cMan.cText.text = choiceText;
                    cMan.Buttom1Text.text = buttom1Text;
                    cMan.Buttom2Text.text = buttom2Text;

                    cMan.choiceActivate();
                    cmade = true;
                }
                else if (dMan.currentLine + 1 == dialogueLines.Length && cmade == false && dec.FungusPickedUp == false && Nochoice == 0f)
                {
                    dMan.dialogueLines = NoChoiceLines1;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                    ogdialogueLines[0] = NoChoiceLines2[0];
                    Nochoice = 1f;
                    cmade = true;

                    dec.KeepFungus = true;
                    dec.GaveFungus = true;



                    if (image == false)
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    }
                    else
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(0.8649376f, 0.8679245f, 0.741011f, 1f);
                    }
                    dMan.dImageToUse.GetComponent<Image>().sprite = image;
                }




                //Adding choice consequences here

                if (dMan.dialogueActive == false && whatChoice == 1f && cMan.choiceActive == false)
                {
                    dMan.dialogueLines = CdialogueLines1_2;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                    CdialogueLines1_2[0] = ogdialogueLines[0];




                    // faiding the image if there is no image to use in this dialogue
                    if (image == false)
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    }
                    else
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(0.8649376f, 0.8679245f, 0.741011f, 1f);
                    }
                    dMan.dImageToUse.GetComponent<Image>().sprite = image;
                }

                if (dMan.dialogueActive == false && whatChoice == 2f && cMan.choiceActive == false)
                {
                    dMan.dialogueLines = CdialogueLines2_2;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                    CdialogueLines2_2[0] = ogdialogueLines[0];




                    if (image == false)
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    }
                    else
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(0.8649376f, 0.8679245f, 0.741011f, 1f);
                    }
                    dMan.dImageToUse.GetComponent<Image>().sprite = image;
                }

                if (dMan.dialogueActive == false && Nochoice == 1f && cMan.choiceActive == false)
                {
                    dMan.dialogueLines = NoChoiceLines2;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                    NoChoiceLines2[0] = ogdialogueLines[0];




                    if (image == false)
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    }
                    else
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(0.8649376f, 0.8679245f, 0.741011f, 1f);
                    }
                    dMan.dImageToUse.GetComponent<Image>().sprite = image;
                }
            }

            //help
            if (cMan.choice == 1f && dMan.dialogueActive == false && whatChoice == 0f && inZone == true && Input.GetButtonUp("Submit"))
            {
                dMan.dialogueLines = CdialogueLines1;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                whatChoice = 1f;
                cMan.choice = 0f;
                ogdialogueLines[0] = CdialogueLines1_2[0];
                dMan.firstup = true;

                dec.GaveFungus = true;
                dec.KeepFungus = false;

            }

            if (cMan.choice == 2f && dMan.dialogueActive == false && whatChoice == 0f && inZone == true && Input.GetButtonUp("Submit"))
            {
                dMan.dialogueLines = CdialogueLines2;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                whatChoice = 2f;
                cMan.choice = 0f;
                ogdialogueLines[0] = CdialogueLines2_2[0];
                dMan.firstup = true;

                dec.KeepFungus = true;
                dec.GaveFungus = false;
            }
        }
        // if the player gave the mushroom to the NPC
        //These are needed if the player talks to the NPC after making decision

        else if (dec.GaveFungus == true && dec.KeepFungus == false)
        {
            

            if (Input.GetButtonDown("Submit") && inZone == true)
            {

                if (dMan.dialogueActive == false)
                {
                    dMan.dialogueLines = CdialogueLines1_2;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                    CdialogueLines1_2[0] = ogdialogueLines[0];

                    if (image == false)
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    }
                    else
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(0.8649376f, 0.8679245f, 0.741011f, 1f);
                    }
                    dMan.dImageToUse.GetComponent<Image>().sprite = image;

                }
            }
        }

        //if the player kept the mushroom
        else if (dec.GaveFungus == false && dec.KeepFungus == true)
        {


            if (Input.GetButtonDown("Submit") && inZone == true)
            {

                if (dMan.dialogueActive == false)
                {
                    dMan.dialogueLines = CdialogueLines2_2;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                    CdialogueLines2_2[0] = ogdialogueLines2[0];

                    if (image == false)
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    }
                    else
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(0.8649376f, 0.8679245f, 0.741011f, 1f);
                    }
                    dMan.dImageToUse.GetComponent<Image>().sprite = image;

                }
            }
        }

        //if the player never had the mushroom
        else if (dec.GaveFungus == true && dec.KeepFungus == true)
        {


            if (Input.GetButtonDown("Submit") && inZone == true)
            {

                if (dMan.dialogueActive == false)
                {
                    dMan.dialogueLines = NoChoiceLines2;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                    NoChoiceLines2[0] = NoogdialogueLines[0];

                    if (image == false)
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    }
                    else
                    {
                        dMan.dImageToUse.GetComponent<Image>().color = new Color(0.8649376f, 0.8679245f, 0.741011f, 1f);
                    }
                    dMan.dImageToUse.GetComponent<Image>().sprite = image;

                }
            }
        }
    }
}
