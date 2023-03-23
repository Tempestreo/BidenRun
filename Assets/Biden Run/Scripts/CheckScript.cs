using UnityEngine;
using TMPro;
public class CheckScript : MonoBehaviour
{
    //the check line script 
    public GameObject prefabOfThis;
    public GameObject Trump;

    VoteManager scVote;
    WaveManager scWave;
    void Start()
    {
        scVote = FindObjectOfType<VoteManager>();
        scWave = FindObjectOfType<WaveManager>();
        //Achievement checker. (Able to make a single method)
        if (scVote.age == 99 && PlayerPrefs.GetInt("OldestPresident") == 0) //oldest president
        {
            GameObject achievementBar = FindObjectOfType<AchievementBarScript>().gameObject;
            achievementBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Oldest President";
            PlayerPrefs.SetInt("OldestPresident", 1);
            achievementBar.SetActive(false);
            achievementBar.SetActive(true);
        }
        if (scVote.age == 171 && PlayerPrefs.GetInt("TrumpDeath") == 0) //Trump's death
        {
            GameObject achievementBar = FindObjectOfType<AchievementBarScript>().gameObject;
            achievementBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Trump's Death";
            PlayerPrefs.SetInt("TrumpDeath", 1);
            achievementBar.SetActive(false);
            achievementBar.SetActive(true);
        }
        if (scVote.age == 92 && PlayerPrefs.GetInt("LongestServingPresident") == 0) //Longest-Serving president
        {
            GameObject achievementBar = FindObjectOfType<AchievementBarScript>().gameObject;
            achievementBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Longest-serving president";
            PlayerPrefs.SetInt("LongestServingPresident", 1);
            achievementBar.SetActive(false);
            achievementBar.SetActive(true);
        }
        if (scVote.age == 123 && PlayerPrefs.GetInt("OldestPerson") == 0) //oldest person
        {
            GameObject achievementBar = FindObjectOfType<AchievementBarScript>().gameObject;
            achievementBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Oldest Person";
            PlayerPrefs.SetInt("OldestPerson", 1);
            achievementBar.SetActive(false);
            achievementBar.SetActive(true);
        }
        if (scVote.age == 150 && PlayerPrefs.GetInt("Reptillian") == 0) //Reptillian
        {
            GameObject achievementBar = FindObjectOfType<AchievementBarScript>().gameObject;
            achievementBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am i .. Reptillian?";
            PlayerPrefs.SetInt("Reptillian", 1);
            achievementBar.SetActive(false);
            achievementBar.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the player reach check line then create new wave
        if (other.tag == "Player")
        {
            if (scVote.bidenVote >= scVote.trumpVote)
            {
                scWave.checkLinePosition = this.gameObject.transform.position;
                scWave.NewWave();
                scVote.age++;
                scWave.wave++;
                scVote.txtAge.text = scVote.age.ToString();
                prefabOfThis.transform.position = new Vector3(0, -0.48f, this.transform.position.z + 100);
                Instantiate(prefabOfThis);
                Destroy(this.gameObject);
            }
            else if (scVote.bidenVote < scVote.trumpVote && scVote.age > 170)
            {
                PlayerPrefs.SetInt("DeadTrumpVictory", 1);
                FindObjectOfType<AchievementBarScript>().transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "what did it cost..";
                FindObjectOfType<AchievementBarScript>().gameObject.SetActive(true);
                scVote.GameOver();
            }
            else
            {
                Trump.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z + 2);
                Instantiate(Trump);
                scVote.GameOver();
            }
        }
    }
}
