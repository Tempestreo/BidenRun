using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MenuScript : MonoBehaviour
{
    public AudioSource SFX;
    public AudioSource Music;
    public GameObject PnlSettings;
    private void Start()
    {
        //option elements
        this.gameObject.transform.GetChild(9).GetChild(0).GetChild(0).GetComponent<TMP_Dropdown>().value = PlayerPrefs.GetInt("Quality");
        this.gameObject.transform.GetChild(9).GetChild(1).GetComponent<Toggle>().isOn = PlayerPrefs.GetInt("MuteMusic") == 0 ? true : false;
        this.gameObject.transform.GetChild(9).GetChild(2).GetComponent<Toggle>().isOn = PlayerPrefs.GetInt("MuteSound") == 0 ? true : false;
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        SFX.mute = PlayerPrefs.GetInt("MuteSound") == 0 ? true : false; 
        Music.mute = PlayerPrefs.GetInt("MuteMusic") == 0 ? true : false;
    }
    public void SetQuality(int QualityValue)
    {
        PlayerPrefs.SetInt("Quality", QualityValue);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
    }
    public void SetSFX(bool Muted)
    {
        PlayerPrefs.SetInt("MuteSound", (Muted) ? 0:1);
        SFX.mute = PlayerPrefs.GetInt("MuteSound") == 0 ? true:false;
    }
    public void SetMusic(bool Muted)
    {
        PlayerPrefs.SetInt("MuteMusic", (Muted) ? 0 : 1);
        Music.mute = PlayerPrefs.GetInt("MuteMusic") == 0 ? true : false;
    }
    public void OpenSettings() 
    {
        PnlSettings.gameObject.SetActive(true);
    }
}
