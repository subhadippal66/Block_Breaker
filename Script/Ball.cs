using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] MoveMouse paddle1;
    Vector2 paddleToBallPos;
    [SerializeField] float velX;
    [SerializeField] float velY;
    bool hasStarted = true;
    [SerializeField] AudioClip[] ballSound;
    AudioSource myAudioSource;
    Rigidbody2D ballRigidbody2d;
    [SerializeField] float randomVelocity;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        paddleToBallPos = transform.position - paddle1.transform.position;
        ballRigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            LockBallInPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LockBallInPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallPos;
    }
    private void LaunchBallOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = false;
            ballRigidbody2d.velocity = new Vector2(velX , velY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 updatedVelocity = new Vector2(Random.Range(0f, randomVelocity), Random.Range(0f,randomVelocity));
        
        if (!hasStarted)
        {
            AudioClip clip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];
            myAudioSource.PlayOneShot(clip,.6f);
            ballRigidbody2d.velocity += updatedVelocity;
            Debug.Log(ballRigidbody2d.velocity.x);    //for debugging purpose
        }
    }
}
