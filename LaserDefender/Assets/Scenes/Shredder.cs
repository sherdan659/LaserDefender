using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnTriggerEnter2D() is bult in method (so the unity compiler know when this method 
    // needs to be called with another collider.


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    /* This collision method is used when the current object colliders is not a trigger
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    */
}
