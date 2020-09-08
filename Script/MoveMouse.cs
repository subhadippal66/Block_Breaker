using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMouse : MonoBehaviour
{
    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    void Start()
    {
        
    }
    void Update()
    {
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;

    }

    public float GetXPos()
    {
        float mousePosInUnit = Input.mousePosition.x / Screen.width * screenWidthInUnit - 8f;
        if (FindObjectOfType<GameStatus>().IsAutoplayerEnable())
        {
           return FindObjectOfType<Ball>().transform.position.x;
        }

        else
        {
           return mousePosInUnit;
        }
    }
}
