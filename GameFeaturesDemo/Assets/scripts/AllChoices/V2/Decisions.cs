using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Decisions : MonoBehaviour
{
    //This script is storing the decisions the player has made during the game 
   

    private PlayerHealthManager health;
    public const string saveSeparator = "#Save-Value#";

    private NonSavableChoices nonSavable;

    //Act I
    [HideInInspector]
    public bool CrystalPickedUp;
    [HideInInspector]
    public bool EnterWithCrystal;
    [HideInInspector]
    public bool Med1;

    [HideInInspector]
    public bool FungusPickedUp;
    [HideInInspector]
    public bool GaveFungus;
    [HideInInspector]
    public bool KeepFungus;

    [HideInInspector]
    public bool Med2;

    [HideInInspector]
    public bool TakeRobot;

    [HideInInspector]
    public bool Phish;





    //(note to self) For new every decision, you must write in the "save" script as well

    public void Start()
    {
        health = FindObjectOfType<PlayerHealthManager>();
        nonSavable = FindObjectOfType<NonSavableChoices>();
    }
    public void FixedUpdate()
    {
        // Deleting all progress if the player dies, restoring it from the save file on load. 
        if (health.playerCurrentHealth <= 0)
        {
    
            nonSavable.nonSavableReset();

            CrystalPickedUp = false;
            EnterWithCrystal = false;
            Med1 = false;
            
            FungusPickedUp = false;
            GaveFungus = false;
            KeepFungus = false;

            Med2 = false;

            TakeRobot = false;

            Phish = false;
        }
    }
    //errort fogsz kapni, ha a betöltésnél úgy próbálja meg kiolvasni a progress fájl ból az adatokat, hogy még az nincs benne az újonnan hozzáadott változó. Vagyis bele kell írnod a txt-be, vagy menteni (játékon belül)
    public void Load()
    {
        string progress = File.ReadAllText(Application.persistentDataPath + "/Progress.file");

        string[] pcontents = progress.Split(new[] { saveSeparator }, System.StringSplitOptions.None);

        //First decision
        CrystalPickedUp = bool.Parse(pcontents[0]);
        EnterWithCrystal = bool.Parse(pcontents[1]);
        Med1 = bool.Parse(pcontents[2]);

        //Second decision
        FungusPickedUp = bool.Parse(pcontents[3]);
        GaveFungus = bool.Parse(pcontents[4]);
        KeepFungus = bool.Parse(pcontents[5]);

        //Med2
        Med2 = bool.Parse(pcontents[6]);

        //Finding the companion
        TakeRobot = bool.Parse(pcontents[7]);

        //Pushing back the fish
        Phish = bool.Parse(pcontents[8]);
    }
}
