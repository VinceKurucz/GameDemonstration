using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;


public class Options : MonoBehaviour
{
    public AudioMixer MainMixer;

    Resolution[] Resolutions;

    public TMPro.TMP_Dropdown ResDropdown;
    public Toggle FpsLimitToggle;

    int currentRes = 0;
    int altRes = 0;


    private string Optionsfile;
    public const string saveSeparator = "#Save-Value#";

    [HideInInspector]
    public string qsaveString;
    [HideInInspector]
    public string vsaveString;
    [HideInInspector]
    public string fsaveString;
    [HideInInspector]
    public string rsaveString;
    [HideInInspector]
    public string lsaveString;

    private void Start()
    {
        Optionsfile = Application.persistentDataPath + "/Options.file";

        ResDropdown.ClearOptions();
        Resolutions = Screen.resolutions;

        List<string> options = new List<string>();

        for (int i = 0; i < Resolutions.Length; i++)
        {
            string option = Resolutions[i].width + "x" + Resolutions[i].height;
            options.Add(option);


            //Alternative way of setting the resolution
            /*
            if (File.Exists(Optionsfile) == false)
            {
                if (Resolutions[i].width == Screen.currentResolution.width && Resolutions[i].height == Screen.currentResolution.height)
                {
                    currentRes = i;
                }
              
                if (Resolutions[i].width == 1920 && Resolutions[i].height == 1080)
                {
                    altRes = i;
                }

            }
            */
        }

        if(File.Exists(Optionsfile) == false)
        {
            qsaveString = string.Join(saveSeparator, "0");
            vsaveString = string.Join(saveSeparator, "0");
            fsaveString = string.Join(saveSeparator, "True");
            rsaveString = string.Join(saveSeparator, Resolutions.Length);
            lsaveString = string.Join(saveSeparator, "False");

            FpsLimit(false);

        }

        if(File.Exists(Optionsfile))
        {
            string optionsfile2 = File.ReadAllText(Application.persistentDataPath + "/Options.file");

            string[] pcontents = optionsfile2.Split(new[] { saveSeparator }, System.StringSplitOptions.None);


            qsaveString = string.Join(saveSeparator, int.Parse(pcontents[0]));
            vsaveString = string.Join(saveSeparator, float.Parse(pcontents[1]));
            fsaveString = string.Join(saveSeparator, bool.Parse(pcontents[2]));
            rsaveString = string.Join(saveSeparator, int.Parse(pcontents[3]));
            lsaveString = string.Join(saveSeparator, bool.Parse(pcontents[4]));

            QualitySettings.SetQualityLevel(int.Parse(pcontents[0]));

            MainMixer.SetFloat("Volume", float.Parse(pcontents[1]));

            Screen.fullScreen = bool.Parse(pcontents[2]);
           
            Resolution resolution = Resolutions[int.Parse(pcontents[3])];
            
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);


            FpsLimit(bool.Parse(pcontents[4]));
            FpsLimitToggle.isOn = bool.Parse(pcontents[4]);

        }
     

        ResDropdown.AddOptions(options);

        if(altRes != 0)
        {
            ResDropdown.value = altRes;
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        }
        else
        {
            ResDropdown.value = currentRes;
        }



        ResDropdown.RefreshShownValue();
    }

    public void Quality(int Quality)
    {
        QualitySettings.SetQualityLevel(Quality);

        qsaveString = string.Join(saveSeparator, Quality);



    }

    public void AudioAdjust(float volume)
    {
        MainMixer.SetFloat("Volume", volume);

        vsaveString = string.Join(saveSeparator, volume);

    }

    public void FullScreen(bool IsfullScreen)
    {
        Screen.fullScreen = IsfullScreen;

        fsaveString = string.Join(saveSeparator, IsfullScreen);


    }

    public void SetResolution(int res)
    {
        Resolution resolution = Resolutions[res];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        rsaveString = string.Join(saveSeparator, res);



    }
    public void FpsLimit(bool LimitOn)
    {
        if(LimitOn == true)
        {
            Application.targetFrameRate = 60;
        }
        else
        {
            Application.targetFrameRate = 200;
        }

        

        lsaveString = string.Join(saveSeparator, LimitOn);
    }


    public void SaveOptions()
    {    
        string[] Settings = new string[]
        {
            ""+qsaveString,
            ""+vsaveString,
            ""+fsaveString,
            ""+rsaveString,
            ""+lsaveString
        };

        string settings = string.Join(saveSeparator, Settings);

        File.WriteAllText(Application.persistentDataPath + "/Options.file", settings);

        


    }

}
