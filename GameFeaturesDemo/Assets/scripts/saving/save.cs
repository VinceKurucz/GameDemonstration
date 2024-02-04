using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class save : MonoBehaviour
{
   [HideInInspector]
    public Scene cscene;

    public const string saveSeparator = "#Save-Value#";

    private Decisions decisions;
    private PlayerHealthManager med;

    public Animator anim;
    private GameObject obj;

    // To fix a minor issue
   private bool isinZone;

    private GameObject saveanim;
    private Animator SaveAnimator;

    private void Start()
    {
        //these are needed for a text to fade in and out when player in range
        obj = GameObject.Find("saveText");

        anim = obj.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            isinZone = true;          
            decisions = FindObjectOfType<Decisions>();
            med = FindObjectOfType<PlayerHealthManager>();

            saveanim = GameObject.Find("SaveAnimator");
            SaveAnimator = saveanim.GetComponent<Animator>();

            Save();

            anim.SetFloat("fadeIn", 2f);
        }          

    }
    void OnTriggerExit2D(Collider2D other)
    {
        isinZone = false;

        anim.SetFloat("fadeIn", 0f);
    }

     void Update()
    {

        //Load in the PlayerHealthManager 
        if (Input.GetKeyDown(KeyCode.Q) && isinZone == true)
        {
            Save();
            SaveAnimator.SetFloat("start", 2f);
         }
        else if(SaveAnimator != null)
        {          
            SaveAnimator.SetFloat("start", 0f);
        }      
    }

    private void Save()
    {



        int saveMed = med.numberOfMeds;

        Vector2 playerposition = ControllerScript.Pos;
        cscene = ControllerScript.scene;

        string[] pcontents = new string[]
{
            ""+playerposition.x,
            ""+playerposition.y,
};
        //meds
        string msaveString = "" + saveMed;
        File.WriteAllText(Application.persistentDataPath + "/msave.file", msaveString);

        

        //position
        string psaveString = string.Join(saveSeparator, pcontents);
        File.WriteAllText(Application.persistentDataPath + "/psave.file", psaveString);

        //scene
        string SsaveString = "" + cscene.name;
        File.WriteAllText(Application.persistentDataPath + "/Ssave.file", SsaveString);


        //decisions
        //(note to self) for every decision in the "decisions" script, you must write a line here as well
        string[] Progress = new string[]
        {
            ""+decisions.CrystalPickedUp,
            ""+decisions.EnterWithCrystal,
            ""+decisions.Med1,

            ""+decisions.FungusPickedUp,
            ""+decisions.GaveFungus,
            ""+decisions.KeepFungus,

            ""+decisions.Med2,

            ""+decisions.TakeRobot,

            ""+decisions.Phish,
        };


        string progress = string.Join(saveSeparator, Progress);
        

        File.WriteAllText(Application.persistentDataPath + "/Progress.file", progress);

   

    }
   



}
