using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotDialogueMAnager : MonoBehaviour
{
    public GameObject dBox;

    public GameObject dImageToUse;

    public Text dText;
    public bool dialogueActive;

    public string[] dialogueLines;

    public int currentLine;

    // Another bool cus I can't write proper codes
    [HideInInspector]
    public bool firstup;

    private DialogueMAnager dman;

    



    private void Start()
    {
        dman = FindObjectOfType<DialogueMAnager>();
    }

    void Update()
    {

        if (dialogueActive && Input.GetKeyUp(KeyCode.F) && firstup == true && dman.dialogueActive == false)
        {
            // dBox.SetActive(false);
            // dialogueActive = false;

            currentLine++;
            StopAllCoroutines();

        }
        if (dialogueActive && Input.GetKeyUp(KeyCode.F) && currentLine == 0 && dman.dialogueActive == false)
        {
            firstup = true;

        }

        if (currentLine >= dialogueLines.Length)
        {
            /*
            dBox.SetActive(false);
            dImageToUse.SetActive(false);
            dialogueActive = false;
            currentLine = 0;
            firstup = false;
            */

            EndDialogue();

        }

        // to fix an issue with the letters from the previous line still beeing rendered

        if (Input.GetKeyUp(KeyCode.F) && dialogueActive == false) 
        {
            dialogueLines[0] = " ";
        }


        // dText.text = dialogueLines[currentLine];

        StartCoroutine(type(dialogueLines[currentLine]));

    }

    public void showbox(string dialogue)
    {
        if (Time.timeScale != 0f && dman.dialogueActive == false)
        {
           
            dialogueActive = true;
            dBox.SetActive(true);
            dImageToUse.SetActive(true);
            dText.text = dialogue;
        }

    }
    public void ShowDialogue()
    {
        if (Time.timeScale != 0f && dman.dialogueActive == false)
        {

            dialogueActive = true;
            dBox.SetActive(true);
            dImageToUse.SetActive(true);
        }
    }

    public void EndDialogue()
    {
        dBox.SetActive(false);
        dImageToUse.SetActive(false);
        dialogueActive = false;
        currentLine = 0;
        firstup = false;
    }

    //So the text will look better

    IEnumerator type(string dialogeLines)
    {
        dText.text = "";
        foreach (char letter in dialogeLines.ToCharArray())
        {
            dText.text += letter;
            yield return null;
        }
    }

}
