using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KillWall : MonoBehaviour
{
    public float speed = 2;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;

        velocity.x = speed;

        rb.velocity = velocity;


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RhythmLine")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }
}
