using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueMAnager : MonoBehaviour
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




    void Update()
    {

        if (dialogueActive && Input.GetButtonUp("Submit") && firstup == true)
        {
            // dBox.SetActive(false);
            // dialogueActive = false;

            currentLine++;
            StopAllCoroutines();
            
        }
        if (dialogueActive && Input.GetButtonUp("Submit") && currentLine == 0)
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

       if (Input.GetButtonUp("Submit") && dialogueActive == false)
       {
           
           dialogueLines[0] = " ";
       }
 

        // dText.text = dialogueLines[currentLine];

        StartCoroutine(type(dialogueLines[currentLine]));

    }

    public void showbox(string dialogue)
    {
        if (Time.timeScale != 0f)
        {

            dialogueActive = true;
            dBox.SetActive(true);
            dImageToUse.SetActive(true);
            dText.text = dialogue;
        }
        
    }
    public void ShowDialogue()
    {
        if (Time.timeScale != 0f)
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

    IEnumerator type (string dialogeLines)
    {
        dText.text = "";
        foreach (char letter in dialogeLines.ToCharArray())
        {
            dText.text += letter;
            yield return null;
        }
    }




    //kill me





}
