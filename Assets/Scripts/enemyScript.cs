﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{

    public float speed;
    public float movementRadius;


    System.Random ran = new System.Random();
    public bool goRight;
    private Vector2 enemyStartPosition;
    private Vector2 enemyCurrentPosition;

    private Rigidbody2D rb;
    private SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        enemyStartPosition = gameObject.transform.position;
        if (ran.Next(2) == 0)
        {
            goRight = true;
        }
        else
        {
            goRight = false;
        }
        enemyCurrentPosition = enemyStartPosition;
    }

    // Update is called once per frame
    void Update()
    {

        enemyCurrentPosition = rb.transform.position;
        //print(goRight);
        Vector2 vel = rb.velocity;



        double distanceFromStart = System.Math.Sqrt(((enemyCurrentPosition.x - enemyStartPosition.x) * (enemyCurrentPosition.x - enemyStartPosition.x)) + ((enemyCurrentPosition.y - enemyStartPosition.y) * (enemyCurrentPosition.y - enemyStartPosition.y)));

        //print(distanceFromStart);

        float temp = (float)distanceFromStart;

        distanceFromStart = Mathf.Abs(temp);
        //print(distanceFromStart + "\n" + goRight);
        if (distanceFromStart + speed >= movementRadius)
        {
            if (goRight)
            {
                vel.x = -1;
            }
            else
            {
                vel.x = 1;
            }
            flipBool();
        }

        if (goRight)
        {
            vel.x = speed;
        }
        else
        {
            vel.x = -speed;
        }
        rb.velocity = vel;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    public void flipBool()
    {
        if (goRight)
        {
            goRight = false;
            render.flipX = true;
        }
        else
        {
            goRight = true;
            render.flipX = false;
        }
    }


    


}
