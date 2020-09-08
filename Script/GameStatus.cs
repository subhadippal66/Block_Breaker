using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float gamespeed;
    [SerializeField] int perblockScore;
    int currentScore = 0;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] bool isAutoplayEnable;
    [SerializeField] int perBlockScore_1;
    [SerializeField] TextMeshProUGUI level_;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        Level_seen();
        if (gameStatusCount >1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
       

    }
    void Start()
    {
        score.text = currentScore.ToString();
        Level_seen();
    }

    public void AddToScore()
    {
        currentScore = currentScore + perblockScore;
        score.text = currentScore.ToString();
       
    }

    public void AddToScore_1()
    {
        currentScore = currentScore + perBlockScore_1;
        score.text = currentScore.ToString();
        
    }
    
    void Update()
    {
        Time.timeScale = gamespeed;
        
    }

    public void DestroyYourself()
    {
        Destroy(gameObject);
    }

    public bool IsAutoplayerEnable()
    {
        return isAutoplayEnable;
    }

   

    public void Level_seen()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex - 1;
        level_.text = "Level " + currentScene.ToString();
        
    }
}
