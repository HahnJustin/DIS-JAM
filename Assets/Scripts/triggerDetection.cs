using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        gameObject.transform.parent.GetComponent<enemyScript>().flipBool();
    }

}
