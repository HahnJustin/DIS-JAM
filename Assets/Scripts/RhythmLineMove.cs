using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmLineMove : MonoBehaviour
{
    public float speed = 0;
    public Sprite hitsprite;

    Rigidbody2D rb;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;

        velocity.x = -speed;

        rb.velocity = velocity;
    }

    public void Hit()
    {
        sr.sprite = hitsprite;
    }
}
