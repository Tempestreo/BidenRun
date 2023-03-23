using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AchievementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //achievement description list
        List<string> descriptions = new List<string>() {
            "If this is truly your first time, good luck!", 
            "You are the first president who serve for USA that long! So u can retire now.",
            "You are the oldest president in history of america! So from now on you can plan your retire." ,
            "You are the oldest person in history of the world! Please Retire.",
            "You are the!!.. Are you... Are you even human? Im grandson of the announcer. i beg you, please leave our planet alone!!!",
            "There is an eye at bottom right of your screen which turns red. Please click on it...",
            "You are blind, Right? You are not monk or something like that so how can u see while you are blind!?",
            "Now you know how the fish see. So please click the brain image at the bottom right of your screen.",
            "Why did the man with blurred vision laugh? Things always looked a bit hazy! haha ha ha. Click on the brain image please.",
            "One reptillian down, its your turn now. Please leave here.",
            "You lost an election against a dead guy, right? So you can go back to your planet with the shame now mr reptillian!"
        };
        

        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (PlayerPrefs.GetInt(this.transform.GetChild(i).name) == 0)
            {
                Color bar = this.transform.GetChild(i).GetComponent<Image>().color;
                bar.a = 0.1f;
                this.transform.GetChild(i).GetComponent<Image>().color = bar;
            }
            else
            {
                this.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.transform.GetChild(i).name;
                this.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = descriptions[i];
            }
            
        }
        
    }
}
