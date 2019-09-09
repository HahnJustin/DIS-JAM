using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public float jumpSpeed = 20;
    public Rigidbody2D rb;
    public GameObject player;
    public bool jumped = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = Vector2.zero;
        Vector3 currentPosition = new Vector3(Mathf.Round(player.transform.position.x), Mathf.Round(player.transform.position.y), Mathf.Round(player.transform.position.z));

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {


            if (velocity.y == 0 && jumped == true && player.transform.position.y <= -2.86)
            {
                jumped = false;
            }

            if (jumped == false)
            {
                velocity.y = jumpSpeed;
                jumped = true;
                Debug.Log(velocity.y);
            }

            


        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            velocity.x = speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed;
        }

        rb.velocity = velocity;
    }
}
