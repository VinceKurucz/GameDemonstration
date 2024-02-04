using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle1 : MonoBehaviour
{
    private float switch1;
    private float switch2;
    private float switch3;
    private float switch4;

    public Riddle1Switch sw1;
    public Riddle1Switch sw2;
    public Riddle1Switch sw3;
    public Riddle1Switch sw4;

    public BoxCollider2D coll;

    public Animator anim;

    public GameObject sparkle1;
    public GameObject sparkle2;

    private void Update()
    {
        switch1 = sw1.current;
        switch2 = sw2.current;
        switch3 = sw3.current;
        switch4 = sw4.current;

        if (switch1 == 4 && switch2 == 1 && switch3 == 2 && switch4 == 3)
        {
            Open();
        }
        else
        {
            Close();
        }
    }
    private void Open()
    {
        coll.enabled = false;
        sparkle1.SetActive(false);
        sparkle2.SetActive(false);
        anim.SetFloat("Open", 2f);
    }
    private void Close()
    {
        coll.enabled = true;
        sparkle1.SetActive(true);
        sparkle2.SetActive(true);
        anim.SetFloat("Open", 0f);
    }


}
