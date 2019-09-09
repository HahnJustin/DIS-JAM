using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{

    public GameObject rhythmline;
    public float spawntime = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
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
