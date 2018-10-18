using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float xVel= 2f;
    [SerializeField] float yVel= 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFacotor = .02f;
    AudioSource myAudioScource;
    Rigidbody2D myRigidBody;
  

    Vector2 paddleToBallVector;
    bool hasStarted = false;
   

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAudioScource = GetComponent<AudioSource>();        
        paddleToBallVector = transform.position - paddle.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBalltoPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody.velocity = new Vector2(xVel, yVel);
        }
    }    
        
    private void LockBalltoPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0, randomFacotor), UnityEngine.Random.Range(0, randomFacotor));
      if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioScource.PlayOneShot(clip);
            myRigidBody.velocity += velocityTweak;
        }
    }
}
