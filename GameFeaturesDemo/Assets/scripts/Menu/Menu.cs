using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject confirm;
    public GameObject Options;


    public Button ContinueButtom;
    public Button OptionsContinueButtom;

    public void coninue()
    {
        string SsaveString = File.ReadAllText(Application.persistentDataPath + "/Ssave.file");
        SceneManager.LoadScene("LoadScene");
    }
    public void quit()
    {
        Application.Quit();

    }
    public void newgame()
    {
        SceneManager.LoadScene("LoadScene");
        FindObjectOfType<NewGame>().newGame = true;

        // meds

        File.WriteAllText(Application.persistentDataPath + "/NEWmsave.file", "1");

        //position

        File.WriteAllText(Application.persistentDataPath + "/NEWpsave.file", "17,45564#Save-Value#4,784679");

        //scene

        File.WriteAllText(Application.persistentDataPath + "/NEWSsave.file", "Home");
    }

    public void newGameConfirm()
    {
        confirm.SetActive(true);
    }
    public void cancel()
    {
        confirm.SetActive(false);
        ContinueButtom.Select();
    }

    public void OptionsOpen()
        {
        Options.SetActive(true);
        }
    public void OptionsClose()
    {
        Options.SetActive(false);
        OptionsContinueButtom.Select();
    }



}
      