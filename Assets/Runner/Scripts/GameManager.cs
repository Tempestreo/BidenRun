using System.Collections;
using System.Collections.Generic;
using HyperCasual.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HyperCasual.Runner
{
    /// <summary>
    /// A class used to store game state information, 
    /// load levels, and save/load statistics as applicable.
    /// The GameManager class manages all game-related 
    /// state changes.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static Material TerrainMaterial;
        public Material thematerial;
        /// <summary>
        /// Returns the GameManager.
        /// </summary>
        public static GameManager Instance => s_Instance;
        static GameManager s_Instance;


        

        /// <summary>
        /// Returns true if the game is currently active.
        /// Returns false if the game is paused, has not yet begun,
        /// or has ended.
        /// </summary>
        public bool IsPlaying => m_IsPlaying;
        bool m_IsPlaying;
        GameObject m_CurrentTerrainGO;
        public GameObject pnlAchievements;

#if UNITY_EDITOR
        bool m_LevelEditorMode;
#endif

        void Awake()
        {
            if (!PlayerPrefs.HasKey("TrumpDeath"))
            {
                PlayerPrefs.SetInt("FirstTime", 0);                //First Game
                PlayerPrefs.SetInt("LongestServingPresident", 0);  //stay president for 12 years
                PlayerPrefs.SetInt("OldestPresident", 0);          //99 y.o
                PlayerPrefs.SetInt("OldestPerson", 0);             //123 y.o oldest person
                PlayerPrefs.SetInt("Reptillian", 0);               //150 y.o
                PlayerPrefs.SetInt("BlindRush", 0);                //blindest
                PlayerPrefs.SetInt("BlindOrNot", 0);               //dont do anything bad while blind
                PlayerPrefs.SetInt("FishVision", 0);               //fully blurred vision
                PlayerPrefs.SetInt("ItsNotThatBad", 0);            //dont do anything bad while blurred
                PlayerPrefs.SetInt("TrumpDeath", 0);               //trump will die about 171
                PlayerPrefs.SetInt("DeadTrumpVictory", 0);         //trump will win presidency after his death
                PlayerPrefs.SetInt("BlinkCounter", 0);             //Blindness counter
                PlayerPrefs.SetInt("FocusCounter", 0);             //Blurness counter
                PlayerPrefs.SetInt("MuteMusic", 1);
                PlayerPrefs.SetInt("MuteSound",1);
                PlayerPrefs.SetInt("Quality", 1);
                PlayerPrefs.SetInt("GameCount", 1);
            }
            GameObject achievementsBar = FindObjectOfType<AchievementBarScript>().gameObject;
            if (PlayerPrefs.GetInt("FirstTime") == 0)
            {
                GameObject achievementBar = FindObjectOfType<AchievementBarScript>().gameObject;
                PlayerPrefs.SetInt("FirstTime", 1);
                achievementBar.SetActive(false);
                achievementBar.SetActive(true);
            }
            TerrainMaterial = thematerial;
            CreateTerrain(ref m_CurrentTerrainGO);
            if (s_Instance != null && s_Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            s_Instance = this;

#if UNITY_EDITOR
#endif
        }
        public void TurnOnAchievements()
        {
            pnlAchievements.SetActive(true);
        }
        public static void CreateTerrain(ref GameObject terrainGameObject)
        {
            TerrainGenerator.TerrainDimensions terrainDimensions = new TerrainGenerator.TerrainDimensions()
            {
                Width = 8,
                Length = 10000,
                StartBuffer = 5,
                EndBuffer = 5,
                Thickness = 0
            };
            TerrainGenerator.CreateTerrain(terrainDimensions, TerrainMaterial, ref terrainGameObject);
        }
        public void Restart()
        {
            SceneManager.LoadScene("RunnerLevelEditor");
        }
    }
}