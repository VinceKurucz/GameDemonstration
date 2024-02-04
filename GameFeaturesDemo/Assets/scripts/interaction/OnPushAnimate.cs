using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPushAnimate : MonoBehaviour
{

    public string AnimationBoolName;
    public Animator anim;
    public GameObject Obj;
    private bool On;
    private bool inZone;

    void Start()
    {
        anim = anim.GetComponent<Animator>();
    }

    void Update()
    {
        if (inZone == true)
        {
            if (Input.GetButtonDown("Submit") && On == false)
            {
                anim.SetBool(AnimationBoolName, true);
                Obj.SetActive(true);
                On = true;
            }
            else if (Input.GetButtonDown("Submit") && On == true)
            {
                anim.SetBool(AnimationBoolName, false);
                Obj.SetActive(false);
                On = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inZone = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inZone = false;
        }
    }



}
