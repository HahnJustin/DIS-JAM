using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class thwomp : MonoBehaviour
{

    public float thwompSpeed;
    public float thwompDelay;

    private bool thwompGoDown;
    private Rigidbody2D rb;
    private bool inDelay;
    private bool reloading;
    private Vector2 thwompStartPos;
    private SpriteRenderer renderer;

    public Sprite angryThwomp;
    public Sprite sleepThwomp;
    public Sprite awakeThwomp;



    // Start is called before the first frame update
    void Start()
    {
        thwompGoDown = false;
        rb = GetComponent<Rigidbody2D>();
        inDelay = false;
        thwompStartPos.y = gameObject.transform.position.y;
        reloading = false;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;


        if ((thwompGoDown) && (!inDelay))
        {
            StartCoroutine(thwompDown());
        }
        else if (reloading)
        {
            if (gameObject.transform.position.y >= thwompStartPos.y)
            {
                reloading = false;
                inDelay = false;
                vel.y = 0;
                rb.velocity = vel;
            }
        }
    }

    public void flipBool()
    {
        if (thwompGoDown)
        {
            thwompGoDown = false;
        }
        else
        {
            thwompGoDown = true;
        }
    }

    public void thwompMoveDown()
    {
        Vector2 vel = rb.velocity;
        vel.y = -thwompSpeed;
        rb.velocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("MattLevel");
        }
        else
        {
            thwompReload();
        }
    }

    public void thwompReload()
    {
        renderer.sprite = sleepThwomp;
        reloading = true;
        thwompGoDown = false;
        Vector2 vel = rb.velocity;
        vel.y = thwompSpeed;
        rb.velocity = vel;
    }


    public IEnumerator thwompDown()
    {
        renderer.sprite = awakeThwomp;
        inDelay = true;
        yield return new WaitForSeconds(thwompDelay);
        renderer.sprite = angryThwomp;
        thwompMoveDown();
    }





}
