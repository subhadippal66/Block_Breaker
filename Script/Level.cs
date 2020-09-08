using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]int breakableObject; //to see in the inspector
    SceneLoader sceneLoader;
    public void CountBreakableObject()
    {
        breakableObject++;
    }

    public void BlockDestroyed()
    {
        breakableObject--;
        if(breakableObject<=0)
        {
            sceneLoader.LoadNextScene();
        }
    }
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
}
