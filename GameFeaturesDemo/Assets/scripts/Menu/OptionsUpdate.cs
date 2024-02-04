using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUpdate : MonoBehaviour
{
    public TMPro.TMP_Dropdown QualitiDropdown;
    public TMPro.TMP_Dropdown ResolutionDropdown;
    public Toggle FullscreenToggle;
    public Slider AudioSlider;

    private string qsaveString;
    private string vsaveString;
    private string fsaveString;
    private string rsaveString;



    private void Awake()
    {

        qsaveString = FindObjectOfType<Options>().qsaveString;
        vsaveString = FindObjectOfType<Options>().vsaveString;
        fsaveString = FindObjectOfType<Options>().fsaveString;
        rsaveString = FindObjectOfType<Options>().rsaveString;

        QualitiDropdown.value = int.Parse(qsaveString);
        ResolutionDropdown.value = int.Parse(rsaveString);
        FullscreenToggle.isOn = bool.Parse(fsaveString);
        AudioSlider.value = float.Parse(vsaveString);
    }
}
