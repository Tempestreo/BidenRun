using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;
using TMPro;

public class VolumeScript : MonoBehaviour
{
    public Volume volume;

    public Image eyeImage;
    public Image brainImage;

    VoteManager scVote;
    Vignette vinyet;
    DepthOfField blur;
    void Start()
    {
        scVote = FindObjectOfType<VoteManager>();
        volume.profile.TryGet<Vignette>(out vinyet);
        volume.profile.TryGet<DepthOfField>(out blur);
        vinyet.intensity.value = 0;
        StartCoroutine(BlinkEffect());
        StartCoroutine(BlurEffect());
    }
    IEnumerator BlinkEffect()
    {
        // if the player doesnt click on eye for a while, than he/she will get blind slowly
        for (; vinyet.intensity.value < 1.2f; vinyet.intensity.value+= scVote.age *0.00004f)
        {
            if (vinyet.intensity.value > 0.3)
            {
                eyeImage.DOColor(Color.red, 1);
                if (vinyet.intensity.value  >= 0.95f && PlayerPrefs.GetInt("BlindRush") == 0)
                {
                    GameObject achievementBar = FindObjectOfType<AchievementBarScript>().gameObject;
                    achievementBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Blind Rush";
                    PlayerPrefs.SetInt("BlindRush", 1);
                    achievementBar.SetActive(false);
                    achievementBar.SetActive(true);
                }
                if (vinyet.intensity.value >= 0.95f && PlayerPrefs.GetInt("BlinkCounter") >= 10 && PlayerPrefs.GetInt("BlindOrNot") == 0)
                {
                    GameObject achievementBar = FindObjectOfType<AchievementBarScript>().gameObject;
                    achievementBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Advanced sixth sense";
                    PlayerPrefs.SetInt("BlindOrNot", 1);
                    achievementBar.SetActive(false);
                    achievementBar.SetActive(true);
                }
            }
            else
            {
                eyeImage.DOColor(Color.white, 1);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator BlurEffect()
    {
        // if the player doesnt click on brain for a while, than his/her vision is gonna get blur slowly
        for (; blur.focusDistance.value > 0; blur.focusDistance.value -= scVote.age * 0.0007f)
        {
            if (blur.focusDistance.value < 2)
            {
                brainImage.DOColor(Color.white, 1);
                if (blur.focusDistance.value <= 0.05f && PlayerPrefs.GetInt("FishVision") == 0)
                {
                    GameObject achievementBar = FindObjectOfType<AchievementBarScript>().gameObject;
                    achievementBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Fish Vision";
                    PlayerPrefs.SetInt("FishVision", 1);
                    achievementBar.SetActive(false);
                    achievementBar.SetActive(true);
                }
                if (blur.focusDistance.value <= 0.05f && PlayerPrefs.GetInt("FocusCounter") >= 10 && PlayerPrefs.GetInt("ItsNotThatBad") == 0)
                {
                    GameObject achievementBar = FindObjectOfType<AchievementBarScript>().gameObject;
                    achievementBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Its not that bad";
                    PlayerPrefs.SetInt("ItsNotThatBad", 1);
                    achievementBar.SetActive(false);
                    achievementBar.SetActive(true);
                }
            }
            else
            {
                Color32 red = new Color32(147, 109, 109, 255);
                brainImage.DOColor(red, 1);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void Blink()
    {
        PlayerPrefs.SetInt("BlinkCounter", 0);
        vinyet.intensity.value -=0.5f;
    }
    public void Focus()
    {
        if (blur.focusDistance.value < 5)
        {
            PlayerPrefs.SetInt("FocusCounter", 0);
            blur.focusDistance.value += 1.5f;
        }
    }
}
