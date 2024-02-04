using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonSaveTalks : MonoBehaviour
{
    public NonSavableChoices nonSavable;

    public bool AltTalkNpc1;

    private NPC1Diallogue FirstDialogue;

    private void Start()
    {
        nonSavable = FindObjectOfType<NonSavableChoices>();
        FirstDialogue = FindObjectOfType<NPC1Diallogue>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "PlatformPlayer" && Input.GetButtonDown("Submit")) 
        {

            
            // for every new option add this line plus a new bool

            if(AltTalkNpc1 == true && FirstDialogue.onceOver == true)
            {
                nonSavable.TalkNpc1 = true;
            }

        }
    }
}
