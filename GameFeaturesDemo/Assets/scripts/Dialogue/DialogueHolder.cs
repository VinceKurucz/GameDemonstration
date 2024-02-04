using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour
{
   
    private DialogueMAnager dMan;


    // what image shows up while talking
    public Sprite image;
    

    public string[] dialogueLines;

    // To fix a minor issue
    private bool inZone;

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueMAnager>();
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
    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.E) && inZone == true)
        {
            // dMan.showbox(Dialogue);
            

            if (!dMan.dialogueActive)
            {
                dMan.dialogueLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                dMan.dImageToUse.GetComponent<Image>().sprite = image;
            }

        }
    }
} 

