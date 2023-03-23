using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseThePanel : MonoBehaviour
{
    WaveManager scWave;
    private void Start()
    {
        scWave = FindObjectOfType<WaveManager>();
    }
    public void Close()
    {
        if (scWave.IsGameStarted == true)
        {
            Time.timeScale = 1;
            this.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            this.transform.parent.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
}
