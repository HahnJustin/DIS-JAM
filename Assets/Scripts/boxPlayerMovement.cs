using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class boxPlayerMovement : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private int count;

    public float speed;
    public float jumpSpeed;
    private float moveInput;
    private int extraJumps;
    public int extraJumpsValue;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    int counter = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = gameObject.GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //moveInput = Input.GetAxis("Horizontal");
        moveInput = 1;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        counter++;
        if(counter % 500 ==0)
        {
            speed *= 1.1f;
        }


        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if (isGrounded == true)
        {
            extraJumps = 2;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            Jump(rb, jumpSpeed);
            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            Jump(rb, jumpSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hi");
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Debug.Log("inside loop");
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 5)
        {
            winText.text = "You Win!";
        }
    }

    void Jump(Rigidbody2D rb, float jumpSpeed)
    {
        rb.velocity = Vector2.up * jumpSpeed;
    }

    public void CoolJump()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        rb.velocity = Vector2.up * jumpSpeed;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
