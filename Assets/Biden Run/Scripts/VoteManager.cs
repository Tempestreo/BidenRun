using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.VFX;
using Unity.VisualScripting;
using HyperCasual.Runner;

public class VoteManager : MonoBehaviour
{
    #region Components
    PlayerController scPlayer;
    CheckScript scCheck;
    InputManager scInput;
    AdManager scAd;
    Camera cam;
    AudioSource audio;
    #endregion

    #region Audios
    public AudioClip happyCatSound;
    public AudioClip madCatSound;
    public AudioClip crashSound;
    public AudioClip collectibleSound;
    public AudioClip madManSound;
    public AudioClip poopSound;
    public AudioClip trumpLaugh;
    public AudioClip startsound;
    #endregion

    #region variables
    public Animator anim;

    public Image imgEmoji;

    public Sprite imgHandshake;
    public Sprite imgHeart;
    public Sprite imgMadman;
    public Sprite imgPoop;
    public Sprite imgMadcat;
    public Sprite imgCrash;

    public ParticleSystem handshakePFX;
    public ParticleSystem heartPFX;
    public ParticleSystem madmanPFX;
    public ParticleSystem poopPFX;
    public ParticleSystem madcatPFX;
    public ParticleSystem crashPFX;

    public VisualEffect crashAnimVFX;

    public TextMeshProUGUI txtTrumpVote;
    public TextMeshProUGUI txtBidenVote;
    public TextMeshProUGUI txtAge;
    public TextMeshProUGUI bidenAge;
    public TextMeshProUGUI trumpAge;
    public TextMeshProUGUI electionCount;
    public TextMeshProUGUI endTitle;

    public GameObject pnlGameOver;

    public int trumpVote;
    public int bidenVote;
    public int age;

    public bool isFinished;
    bool isLost;
    #endregion


    void Start()
    {
        #region Linking Components
        scAd = FindObjectOfType<AdManager>();
        cam = FindObjectOfType<Camera>();
        audio = GetComponent<AudioSource>();
        scInput = FindObjectOfType<InputManager>();
        scCheck = FindObjectOfType<CheckScript>();
        scPlayer = GetComponent<PlayerController>();

        #endregion

        isFinished = false;
        audio.clip = startsound;
        audio.Play();
        age = 80;
        trumpVote = 50;
        bidenVote = 50;
        txtTrumpVote.text = trumpVote.ToString();
        txtBidenVote.text = bidenVote.ToString();
        txtAge.text = age.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if the player reach finish line and win the game
        if (other.tag == "Finish")
        {
            cam.fieldOfView = 21;
            cam.farClipPlane = 100f;
            cam.nearClipPlane = 8f;
            audio.clip = trumpLaugh;
            audio.Play();
            isFinished = true;
            anim.SetBool("isFinished",isFinished);
            scInput.enabled = false;
            scPlayer.ResetSpeed();
            scPlayer.StopSpeed();
            Input.ResetInputAxes();
            scPlayer.m_AutoMoveForward = false;
            Time.timeScale = 0;
            bidenAge.text = age.ToString();
            trumpAge.text = (age - 4).ToString();
            electionCount.text = (age - 79).ToString();
            PlayerPrefs.SetInt("GameCount", PlayerPrefs.GetInt("GameCount") + 1);
            scAd.RequestInterstitial();
            pnlGameOver.SetActive(true);
            pnlGameOver.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Congratulations! Biden Won!";
        }
        if (other.tag == "handshake")
        {
            audio.clip = collectibleSound;
            audio.Play();
            imgEmoji.sprite = imgHandshake;
            handshakePFX.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z + 5);
            Instantiate(handshakePFX);
            RightMove();
        }
        if (other.tag == "cat")
        {
            audio.clip = happyCatSound;
            audio.Play();
            imgEmoji.sprite = imgHeart;
            heartPFX.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z + 5);
            Instantiate(heartPFX);
            RightMove(); 
        }
        if (other.tag == "poop")
        {
            audio.clip = poopSound;
            audio.Play();
            imgEmoji.sprite = imgPoop;
            poopPFX.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z+5);
            Instantiate(poopPFX);
            WrongMove(); 
        }
        if (other.tag == "bike")
        {
            audio.clip = crashSound;
            audio.Play();
            imgEmoji.sprite = imgCrash;
            crashPFX.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z + 5);
            Instantiate(crashPFX);
            crashAnimVFX.transform.position = new Vector3(other.gameObject.transform.position.x,other.gameObject.transform.position.y+1,other.gameObject.transform.position.z) ;
            Instantiate(crashAnimVFX);
            Destroy(other.gameObject);
            WrongMove();
        }
    }
    //if the player reach checkline and lose the game
    public void GameOver()
    {
        audio.clip = trumpLaugh;
        audio.Play();
        scInput.enabled = false;
        scPlayer.m_AutoMoveForward = false;
        scPlayer.ResetSpeed();
        scPlayer.StopSpeed();
        Input.ResetInputAxes();
        cam.fieldOfView = 21;
        cam.farClipPlane = 100f;
        cam.nearClipPlane = 8f;
        isLost = true;
        Invoke("SetActive", 0.7f);
        anim.SetBool("isLost",isLost);
    }
    void SetActive()
    {
        Time.timeScale = 0f;
        bidenAge.text = age.ToString();
        trumpAge.text = (age-4).ToString();
        electionCount.text = (age-79).ToString();
        PlayerPrefs.SetInt("GameCount", PlayerPrefs.GetInt("GameCount") + 1);
        scAd.RequestInterstitial();
        pnlGameOver.SetActive(true);
    }

    public void MissHandShake()
    {
        audio.clip = madManSound;
        audio.Play();
        imgEmoji.sprite = imgMadman;
        madmanPFX.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z + 5);
        Instantiate(madmanPFX);
        WrongMove();
    }
    public void MissCatPetting()
    {
        audio.clip = madCatSound;
        audio.Play();
        imgEmoji.sprite = imgMadcat;
        madcatPFX.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z + 5);
        Instantiate(madcatPFX);
        WrongMove();
    }

    private void RightMove()
    {
        PlayerPrefs.SetInt("FocusCounter", PlayerPrefs.GetInt("FocusCounter") + 1);
        PlayerPrefs.SetInt("BlinkCounter", PlayerPrefs.GetInt("BlinkCounter") + 1);
        trumpVote--;
        bidenVote++;
        txtTrumpVote.text = trumpVote.ToString();
        txtBidenVote.text = bidenVote.ToString();
    }
    private void WrongMove()
    {
        PlayerPrefs.SetInt("FocusCounter", 0);
        PlayerPrefs.SetInt("BlinkCounter", 0);
        trumpVote++;
        bidenVote--;
        txtTrumpVote.text = trumpVote.ToString();
        txtBidenVote.text = bidenVote.ToString();
    }
}
