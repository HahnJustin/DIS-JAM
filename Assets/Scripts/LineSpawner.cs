using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{

    public GameObject rhythmline;
    public float spawntime = 1;

    int counter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if(counter % 500 == 0)
        {
            counter = 0;
            spawntime *= .9f;
        }
    }
    
    IEnumerator Spawn()
    {
        while(true)
        {
            Instantiate(rhythmline, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawntime);
        }
    }
}
