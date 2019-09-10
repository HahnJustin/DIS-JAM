using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KillWall : MonoBehaviour
{
    public float speed = 2;

    Rigidbody2D rb;

    int counter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;

        velocity.x = speed;

        rb.velocity = velocity;

        counter++;
        if (counter % 500 == 0)
        {
            //counter = 0;
           // speed *= 1.1f;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RhythmLine")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
