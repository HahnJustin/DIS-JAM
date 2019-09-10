using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{

    public Sprite unpressedsprite;
    public Sprite pressedsprite;
    public GameObject spawner;
    public GameObject player;
    

    float pressSpeed;
    int presscount;
    SpriteRenderer sr;
    bool pressed = false;
    

    //Player stuff

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        pressSpeed = spawner.GetComponent<LineSpawner>().spawntime;
        presscount = 0;
    }
    bool isIN;
    GameObject hitObject;
    // Update is called once per frame
    void Update()
    {
        pressSpeed = spawner.GetComponent<LineSpawner>().spawntime;

        if(Input.anyKeyDown && presscount > 0 && hitObject)
        {
            switch (presscount)
            {
                case 1:
                    print("twice");
                    player.GetComponent<boxPlayerMovement>().CoolJump();

                    break;
                case 2:
                    print("thrice");
                    //Do something
                    break;
                case 3:
                    print("quice");
                    //Do something else
                    break;
                default:
                    //Lol
                    break;
            }
            presscount++;
        }

        if (Input.anyKeyDown && hitObject && !pressed)
        {
            hitObject.gameObject.GetComponent<RhythmLineMove>().Hit();
            player.GetComponent<boxPlayerMovement>().CoolJump();
            presscount = 1;
            StartCoroutine(ButtonPress());
        }
        else 
            if(Input.anyKeyDown && !pressed)
                StartCoroutine(ButtonPress());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hitObject = other.gameObject;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        hitObject = null;
    }
    IEnumerator ButtonPress()
    {
        sr.sprite = pressedsprite;
        pressed = true;
        yield return new WaitForSeconds(pressSpeed*.75f);
        sr.sprite = unpressedsprite;
        pressed = false;
        presscount = 0;
    }
}
