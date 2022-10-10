using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwmp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy the other object
            Destroy(collision.gameObject);
        }
    }

    //Will work with collisions instead of just triggers
    //A little more complicated to use, though not terribly so
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
