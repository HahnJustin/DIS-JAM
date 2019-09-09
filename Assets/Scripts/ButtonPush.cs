using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{

    public Sprite unpressedsprite;
    public Sprite pressedsprite;
    public GameObject spawner;

    float pressSpeed;
    SpriteRenderer sr;
    bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        pressSpeed = spawner.GetComponent<LineSpawner>().spawntime;
    }
    bool isIN;
    GameObject hitObject;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && hitObject && !pressed)
        {
            hitObject.gameObject.GetComponent<RhythmLineMove>().Hit();

            StartCoroutine(ButtonPress());

        }
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
    }
}
