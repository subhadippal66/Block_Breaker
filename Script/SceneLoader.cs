using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameStatus gameObj;

    private void Start()
    {
        gameObj = FindObjectOfType<GameStatus>();
    }
    public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1 );
       
    }

    public void Restart()
    {
        gameObj.DestroyYourself();
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
    }
    public void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public void Level3()
    {
        SceneManager.LoadScene(4);
    }
    public void Level4()
    {
        SceneManager.LoadScene(5);
    }
    public void Level5()
    {
        SceneManager.LoadScene(6);
    }
}
