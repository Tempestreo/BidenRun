using HyperCasual.Runner;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class WaveManager : MonoBehaviour
{

    VoteManager scVote;
    PlayerController scPlayer;
    public GameObject PnlEscape;

    public GameObject[] objects = new GameObject[5];
    public Vector3 checkLinePosition;
    public Vector3[] positions;

    public bool IsGameStarted;

    public int wave;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        IsGameStarted = false;
        scPlayer = FindObjectOfType<PlayerController>();
        scVote = FindObjectOfType<VoteManager>();
        Time.timeScale = 0;
        wave = 3;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PnlEscape.activeSelf == false)
        {
            PnlEscape.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void GameStarts()
    {
        Time.timeScale = 1;
        IsGameStarted = true;
        Destroy(EventSystem.current.currentSelectedGameObject);
    }
    public void NewWave()
    {
        scPlayer.m_TargetSpeed += (scVote.age *0.005f);
        bool found = false;
        positions = new Vector3[10];
        positions[0] = new Vector3(Random.Range(20, 25) / 7, 0.26f, checkLinePosition.z + 25 + Random.Range(45, 50));
        positions[1] = new Vector3(Random.Range(15, 20) / 7, 0.26f, checkLinePosition.z + 25 + Random.Range(40, 45));
        positions[2] = new Vector3(Random.Range(10, 15) / 7, 0.26f, checkLinePosition.z + 25 + Random.Range(35, 40));
        positions[3] = new Vector3(Random.Range(5, 10) / 7, 0.26f, checkLinePosition.z + 25 + Random.Range(30, 35));
        positions[4] = new Vector3(Random.Range(0, 5) / 7, 0.26f, checkLinePosition.z + 25 + Random.Range(25, 30));
        positions[5] = new Vector3(Random.Range(-5, 0) / 7, 0.26f, checkLinePosition.z + 25 + Random.Range(20, 25));
        positions[6] = new Vector3(Random.Range(-10, -5) / 7, 0.26f, checkLinePosition.z + 25 + Random.Range(15, 20));
        positions[7] = new Vector3(Random.Range(-15, -10) / 7, 0.26f, checkLinePosition.z + 25 + Random.Range(10, 15));
        positions[8] = new Vector3(Random.Range(-20, -15) / 7, 0.26f, checkLinePosition.z + 25 + Random.Range(5, 10));
        positions[9] = new Vector3(Random.Range(-25, -20) / 7, 0.26f, checkLinePosition.z + 25 + Random.Range(0, 5));
        if (count < 10)
        {
            count = Mathf.RoundToInt(wave / 3);
        }
        Vector3[] selectedPositions = new Vector3[count];
        for (int i = 0; i < count; i++)
        {
            int a = Random.Range(0, objects.Length);
            if (a == 0 || a==1)
            {
                a = Random.Range(0, objects.Length);
            }
            int b = Random.Range(0, positions.Length);
            for (int j = 0; j < i; j++)
            {
                if (selectedPositions[j] == positions[b])
                {
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                i--;
                found = false;
                continue;
            }
            else
            {
                objects[a].transform.position = positions[b];
                selectedPositions[i] = positions[b];
                Instantiate(objects[a]);
            }
        }
    }
}
